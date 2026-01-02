namespace ErasmusBudgetTracker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTargetTitle = new Label();
            lblBalanceTitle = new Label();
            lblCurrentBalance = new Label();
            groupBox1 = new GroupBox();
            rbIncome = new RadioButton();
            rbExpense = new RadioButton();
            btnAddTransaction = new Button();
            numAmount = new NumericUpDown();
            txtDescription = new TextBox();
            lstTransactions = new ListBox();
            btnSave = new Button();
            btnLoad = new Button();
            numTargetGoal = new NumericUpDown();
            btnUpdateGoal = new Button();
            lblEquivalent = new Label();
            lblLiveRate = new Label();
            btnReset = new Button();
            pbGoalProgress = new ProgressBar();
            cbCurrency = new ComboBox();
            lblInfo = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTargetGoal).BeginInit();
            SuspendLayout();
            // 
            // lblTargetTitle
            // 
            lblTargetTitle.AutoSize = true;
            lblTargetTitle.Font = new Font("Segoe UI", 12F);
            lblTargetTitle.Location = new Point(12, 9);
            lblTargetTitle.Name = "lblTargetTitle";
            lblTargetTitle.Size = new Size(178, 28);
            lblTargetTitle.TabIndex = 0;
            lblTargetTitle.Text = "Target Safety Fund:";
            // 
            // lblBalanceTitle
            // 
            lblBalanceTitle.AutoSize = true;
            lblBalanceTitle.Font = new Font("Segoe UI", 12F);
            lblBalanceTitle.Location = new Point(74, 45);
            lblBalanceTitle.Name = "lblBalanceTitle";
            lblBalanceTitle.Size = new Size(116, 28);
            lblBalanceTitle.TabIndex = 2;
            lblBalanceTitle.Text = "Total Saved:";
            // 
            // lblCurrentBalance
            // 
            lblCurrentBalance.AutoSize = true;
            lblCurrentBalance.Font = new Font("Segoe UI", 12F);
            lblCurrentBalance.Location = new Point(196, 45);
            lblCurrentBalance.Name = "lblCurrentBalance";
            lblCurrentBalance.Size = new Size(34, 28);
            lblCurrentBalance.TabIndex = 3;
            lblCurrentBalance.Text = "0€";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(rbIncome);
            groupBox1.Controls.Add(rbExpense);
            groupBox1.Controls.Add(btnAddTransaction);
            groupBox1.Controls.Add(numAmount);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Location = new Point(12, 116);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(516, 148);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add New Expense/Income";
            // 
            // rbIncome
            // 
            rbIncome.AutoSize = true;
            rbIncome.Checked = true;
            rbIncome.Location = new Point(6, 100);
            rbIncome.Name = "rbIncome";
            rbIncome.Size = new Size(79, 24);
            rbIncome.TabIndex = 13;
            rbIncome.TabStop = true;
            rbIncome.Text = "Income";
            rbIncome.UseVisualStyleBackColor = true;
            // 
            // rbExpense
            // 
            rbExpense.AutoSize = true;
            rbExpense.Location = new Point(91, 100);
            rbExpense.Name = "rbExpense";
            rbExpense.Size = new Size(84, 24);
            rbExpense.TabIndex = 14;
            rbExpense.TabStop = true;
            rbExpense.Text = "Expense";
            rbExpense.UseVisualStyleBackColor = true;
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.Location = new Point(181, 95);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(109, 34);
            btnAddTransaction.TabIndex = 2;
            btnAddTransaction.Text = "Add";
            btnAddTransaction.UseVisualStyleBackColor = true;
            btnAddTransaction.Click += btnAddTransaction_Click;
            // 
            // numAmount
            // 
            numAmount.DecimalPlaces = 2;
            numAmount.Location = new Point(6, 62);
            numAmount.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numAmount.Minimum = new decimal(new int[] { 10000000, 0, 0, int.MinValue });
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(284, 27);
            numAmount.TabIndex = 1;
            numAmount.Enter += numAmount_Enter;
            numAmount.MouseUp += numAmount_MouseUp;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(6, 26);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(284, 27);
            txtDescription.TabIndex = 0;
            // 
            // lstTransactions
            // 
            lstTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstTransactions.FormattingEnabled = true;
            lstTransactions.Location = new Point(12, 270);
            lstTransactions.Name = "lstTransactions";
            lstTransactions.Size = new Size(516, 184);
            lstTransactions.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(544, 270);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLoad.Location = new Point(544, 310);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 34);
            btnLoad.TabIndex = 7;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // numTargetGoal
            // 
            numTargetGoal.Font = new Font("Segoe UI", 12F);
            numTargetGoal.Location = new Point(196, 7);
            numTargetGoal.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numTargetGoal.Name = "numTargetGoal";
            numTargetGoal.Size = new Size(204, 34);
            numTargetGoal.TabIndex = 8;
            numTargetGoal.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            // 
            // btnUpdateGoal
            // 
            btnUpdateGoal.Location = new Point(405, 7);
            btnUpdateGoal.Name = "btnUpdateGoal";
            btnUpdateGoal.Size = new Size(123, 34);
            btnUpdateGoal.TabIndex = 9;
            btnUpdateGoal.Text = "Set";
            btnUpdateGoal.UseVisualStyleBackColor = true;
            btnUpdateGoal.Click += btnUpdateGoal_Click;
            // 
            // lblEquivalent
            // 
            lblEquivalent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEquivalent.AutoSize = true;
            lblEquivalent.ForeColor = SystemColors.ControlDarkDark;
            lblEquivalent.Location = new Point(278, 52);
            lblEquivalent.Name = "lblEquivalent";
            lblEquivalent.Size = new Size(122, 20);
            lblEquivalent.TabIndex = 10;
            lblEquivalent.Text = "(Checking Rate...)";
            // 
            // lblLiveRate
            // 
            lblLiveRate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLiveRate.AutoSize = true;
            lblLiveRate.ForeColor = SystemColors.ControlDarkDark;
            lblLiveRate.Location = new Point(401, 52);
            lblLiveRate.Name = "lblLiveRate";
            lblLiveRate.Size = new Size(52, 20);
            lblLiveRate.TabIndex = 11;
            lblLiveRate.Text = "Rate: -";
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReset.Location = new Point(544, 420);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 34);
            btnReset.TabIndex = 12;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // pbGoalProgress
            // 
            pbGoalProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbGoalProgress.Location = new Point(18, 81);
            pbGoalProgress.Name = "pbGoalProgress";
            pbGoalProgress.Size = new Size(382, 29);
            pbGoalProgress.TabIndex = 3;
            // 
            // cbCurrency
            // 
            cbCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCurrency.FormattingEnabled = true;
            cbCurrency.Location = new Point(406, 82);
            cbCurrency.Name = "cbCurrency";
            cbCurrency.Size = new Size(122, 28);
            cbCurrency.TabIndex = 15;
            cbCurrency.SelectedIndexChanged += cbCurrency_SelectedIndexChanged;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 9.5F);
            lblInfo.Location = new Point(544, 84);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(94, 21);
            lblInfo.TabIndex = 16;
            lblInfo.Text = "FX Selection";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 480);
            Controls.Add(lblInfo);
            Controls.Add(cbCurrency);
            Controls.Add(pbGoalProgress);
            Controls.Add(btnReset);
            Controls.Add(lblLiveRate);
            Controls.Add(lblEquivalent);
            Controls.Add(btnUpdateGoal);
            Controls.Add(numTargetGoal);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(lstTransactions);
            Controls.Add(groupBox1);
            Controls.Add(lblCurrentBalance);
            Controls.Add(lblBalanceTitle);
            Controls.Add(lblTargetTitle);
            MinimumSize = new Size(660, 500);
            Name = "Form1";
            Text = "Erasmus Security Fund Tracker";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTargetGoal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTargetTitle;
        private Label lblBalanceTitle;
        private Label lblCurrentBalance;
        private GroupBox groupBox1;
        private Button btnAddTransaction;
        private NumericUpDown numAmount;
        private TextBox txtDescription;
        private ListBox lstTransactions;
        private Button btnSave;
        private Button btnLoad;
        private NumericUpDown numTargetGoal;
        private Button btnUpdateGoal;
        private Label lblEquivalent; // İsmi değiştirdik
        private Label lblLiveRate;
        private Button btnReset;
        private ProgressBar pbGoalProgress;
        private RadioButton rbIncome;
        private RadioButton rbExpense;
        private ComboBox cbCurrency; // YENİ
        private Label lblInfo;
    }
}