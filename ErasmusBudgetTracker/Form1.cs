#nullable disable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SaveSystemFramework.Providers;
using SaveSystemFramework.Core;
using System.Threading.Tasks;
using System.Globalization;
using System.Net.Http;

namespace ErasmusBudgetTracker
{
    public partial class Form1 : Form
    {
        // ---------------------------------------------------------
        // 1. CLASS VARIABLES
        // ---------------------------------------------------------

        private ISaveManager _saveManager;
        private ErasmusData _appData;
        private const string SAVE_FILE_NAME = "erasmus_budget_v1";

        // Anlık kur değeri
        private decimal _currentRate = 0;

        // Seçili olan para birimi (Varsayılan TRY)
        private string _selectedCurrency = "TRY";

        public Form1()
        {
            InitializeComponent();
            InitializeApp();
        }

        // ---------------------------------------------------------
        // 2. INITIALIZATION
        // ---------------------------------------------------------
        private void InitializeApp()
        {
            _saveManager = new JsonSaveProvider("ErasmusTrackerData");
            _appData = new ErasmusData();

            numTargetGoal.Value = _appData.TargetBudget;
            numTargetGoal.Maximum = 100000;
            numAmount.Maximum = 100000;

            // --- YENİ: Para Birimlerini Listeye Ekle ---
            cbCurrency.Items.AddRange(new object[] {
                "TRY", "USD", "GBP", "PLN", "NOK", "SEK", "DKK", "CHF"
            });
            cbCurrency.SelectedIndex = 0; // Varsayılan olarak ilkini (TRY) seç

            FetchExchangeRate();
            UpdateUI();
        }

        // ---------------------------------------------------------
        // 3. UI UPDATE LOGIC
        // ---------------------------------------------------------
        private void UpdateUI()
        {
            lblCurrentBalance.Text = $"{_appData.CurrentBalance} €";

            // Progress Bar Logic
            if (_appData.TargetBudget > 0)
            {
                int progress = (int)((_appData.CurrentBalance / _appData.TargetBudget) * 100);
                if (progress < 0) progress = 0;
                if (progress > 100) progress = 100;
                pbGoalProgress.Value = progress;
            }
            else
            {
                pbGoalProgress.Value = 0;
            }

            // Color Logic
            if (_appData.CurrentBalance >= _appData.TargetBudget)
            {
                lblCurrentBalance.ForeColor = Color.Green;
                pbGoalProgress.Value = 100;
            }
            else
            {
                lblCurrentBalance.ForeColor = Color.OrangeRed;
            }

            UpdateEquivalentValue();

            // Update List
            lstTransactions.Items.Clear();
            var reversedHistory = _appData.TransactionHistory.AsEnumerable().Reverse();
            foreach (var item in reversedHistory)
            {
                lstTransactions.Items.Add(item);
            }
        }

        // ---------------------------------------------------------
        // 4. API & CURRENCY LOGIC (GÜNCELLENDİ)
        // ---------------------------------------------------------
        private async void FetchExchangeRate()
        {
            lblLiveRate.Text = "Rate: Updating...";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Seçilen para birimine göre URL oluştur
                    // Örn: https://api.frankfurter.app/latest?from=EUR&to=PLN
                    string url = $"https://api.frankfurter.app/latest?from=EUR&to={_selectedCurrency}";
                    string response = await client.GetStringAsync(url);

                    // JSON Parse (Seçilen birime göre dinamik)
                    // Örn: "TRY" veya "PLN" kelimesini arıyoruz
                    if (response.Contains(_selectedCurrency))
                    {
                        int index = response.IndexOf(_selectedCurrency) + 5; // "XXX": kısmını geç
                        // JSON cevabının sonundaki süslü parantezleri temizle
                        string rateStr = response.Substring(index).Replace("}", "").Replace("]", "").Replace("\"", "");

                        // Virgülden sonrasını kesip sayıya çevirelim
                        // Bazen API yanına başka şeyler ekleyebilir, garantilemek için virgüle kadar alalım
                        if (rateStr.Contains(","))
                            rateStr = rateStr.Substring(0, rateStr.IndexOf(","));

                        if (decimal.TryParse(rateStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal rate))
                        {
                            _currentRate = rate;
                            lblLiveRate.Text = $"1 EUR = {_currentRate:F2} {_selectedCurrency}";
                            UpdateEquivalentValue();
                        }
                    }
                }
            }
            catch
            {
                lblLiveRate.Text = "Rate: Offline";
                lblEquivalent.Text = "(Offline)";
            }
        }

        private void UpdateEquivalentValue()
        {
            if (_currentRate > 0)
            {
                decimal convertedValue = _appData.CurrentBalance * _currentRate;
                // Ekranda "(≈ 3400.50 PLN)" gibi görünecek
                lblEquivalent.Text = $"(≈ {convertedValue:N2} {_selectedCurrency})";
            }
        }

        // --- YENİ EVENT: Para Birimi Değişince ---
        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen birimi değişkene ata (Örn: "PLN")
            _selectedCurrency = cbCurrency.SelectedItem.ToString();

            // Kuru yeniden çek
            FetchExchangeRate();
        }

        // ---------------------------------------------------------
        // 5. INPUT UX IMPROVEMENTS (OTOMATİK SEÇME)
        // ---------------------------------------------------------

        // Kutuya "Tab" ile girince veya odaklanınca
        private void numAmount_Enter(object sender, EventArgs e)
        {
            numAmount.Select(0, numAmount.Text.Length);
        }

        // Kutuya fare ile tıklayınca
        private void numAmount_MouseUp(object sender, MouseEventArgs e)
        {
            // Bazen MouseUp olayı seçimi iptal edebilir, o yüzden burada tekrar seçiyoruz
            // Ancak sadece ilk odaklanmada yapsın diye kontrol edilebilir ama basitlik için direkt seçelim.
            if (numAmount.Focused && numAmount.Text != "")
            {
                numAmount.Select(0, numAmount.Text.Length);
            }
        }

        // ---------------------------------------------------------
        // 6. BUTTON EVENTS
        // ---------------------------------------------------------
        private void btnAddTransaction_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text;
            decimal amount = numAmount.Value;

            if (string.IsNullOrEmpty(description) || amount == 0)
            {
                MessageBox.Show("Please enter a valid description and amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rbExpense.Checked)
            {
                amount = -Math.Abs(amount);
            }
            else
            {
                amount = Math.Abs(amount);
            }

            _appData.CurrentBalance += amount;

            string tag = amount >= 0 ? "[+]" : "[-]";
            string log = $"{tag} {DateTime.Now.ToShortDateString()} | {description}: {amount} €";

            _appData.TransactionHistory.Add(log);

            txtDescription.Clear();
            numAmount.Value = 0;
            rbIncome.Checked = true;

            // İşlem bitince odağı tekrar Description kutusuna ver, seri giriş yapılsın
            txtDescription.Focus();

            UpdateUI();
        }

        private void btnUpdateGoal_Click(object sender, EventArgs e)
        {
            _appData.TargetBudget = numTargetGoal.Value;
            UpdateUI();
            MessageBox.Show("Target goal updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Text = "Saving...";
            btnSave.Enabled = false;

            try
            {
                bool success = await _saveManager.SaveAsync(SAVE_FILE_NAME, _appData);

                if (success)
                    MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to save data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Critical Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Text = "Save";
                btnSave.Enabled = true;
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Text = "Loading...";
            btnLoad.Enabled = false;

            try
            {
                bool exists = await _saveManager.SaveExistsAsync(SAVE_FILE_NAME);

                if (exists)
                {
                    var loadedData = await _saveManager.LoadAsync<ErasmusData>(SAVE_FILE_NAME);

                    if (loadedData != null)
                    {
                        _appData = loadedData;
                        numTargetGoal.Value = _appData.TargetBudget;
                        UpdateUI();
                        MessageBox.Show("Data loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No save file found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoad.Text = "Load";
                btnLoad.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure? This will clear current data.", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _appData = new ErasmusData();
                numTargetGoal.Value = _appData.TargetBudget;
                UpdateUI();
            }
        }
    }
}