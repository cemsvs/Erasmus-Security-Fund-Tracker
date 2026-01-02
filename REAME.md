# 🌍 Erasmus Security Fund Tracker (v1.1)

> A smart financial planning tool designed for students to bridge the gap between Erasmus grants and real-world expenses.

![Project Screenshot](screenshot_placeholder)

## 📖 Project Overview
Preparing for an Erasmus exchange program requires more than just a grant. Students often face startup costs (deposit, visa, flight) and monthly gaps due to exchange rate fluctuations. 

**Erasmus Security Fund Tracker** is a desktop application engineered to:
1.  **Calculate & Track** a personal "Safety Fund" goal.
2.  **Monitor** real-time currency values (**EUR to TRY, USD, PLN, etc.**) to make informed financial decisions.
3.  **Simulate** professional data persistence using a custom-built framework.

## 🚀 Key Features

* **🌍 Multi-Currency Support:** Now supports 8+ major currencies (TRY, USD, GBP, PLN, NOK, SEK, DKK, CHF) with automatic exchange rate fetching.
* **⚡ Smart Input UX:** Enhanced data entry with auto-select numeric fields and intuitive income/expense toggles.
* **💰 Dynamic Goal Setting:** Users can configure their target fund based on the destination country's economic conditions.
* **📡 Live FX Rate API:** Integrates with the **Frankfurter REST API** to display real-time exchange rates via asynchronous calls.
* **💾 Custom Persistence Layer:** Utilizes the custom **[SaveSystemFramework](https://github.com/cemsvs/SaveSystemFramework)** for JSON-based data storage.
* **📊 Transaction History:** A reverse-chronological list of all deposits with visual tags ([+] Income / [-] Expense).
* **🎨 Responsive UI:** Built with Windows Forms using professional anchoring for full-screen support.

## 🛠️ Technical Stack

| Category | Technology |
|----------|------------|
| **Language** | C# (.NET 6.0 / 8.0) |
| **Framework** | Windows Forms (WinForms) |
| **Networking** | System.Net.Http (Async/Await) |
| **Data Format** | JSON (Serialization) |
| **Architecture** | OOP, Modular Design |

## 📦 How to Run

1.  Clone the repository:
    ```bash
    git clone [https://github.com/cemsvs/Erasmus-Security-Fund-Tracker.git](https://github.com/cemsvs/Erasmus-Security-Fund-Tracker.git)
    ```
2.  Open `ErasmusBudgetTracker.sln` in **Visual Studio 2022**.
3.  Build solution (Ctrl+Shift+B).
4.  Run (F5).

## 👨‍💻 Author

**Hayri Cem Sivas** *Computer Programming Student & Aspiring Software Engineer* [LinkedIn](https://www.linkedin.com/in/hayricemsivas) | [YouTube](https://www.youtube.com/@CemOver)

---
*Built as a showcase of C# capabilities, REST API integration, and system design patterns.*