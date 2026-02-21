using System;
using System.Windows;

namespace MessagesSent
{
    /// <summary>
    /// Name: Aidress Qadeer
    /// Course: COSC2100 – Object-Oriented Programming 2
    /// Assignment: Assignment 1 – Messages Sent
    /// Date: 2026-02-20
    /// Description:
    /// WPF app that collects the number of messages sent over seven days.
    /// The app validates input and displays daily entries.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Rules
        private const int MaxDays = 7;
        private const int MinValue = 0;
        private const int MaxValue = 10000;

        // Tracking
        private int currentDay = 1;
        private int totalMessages = 0;

        // Constructor
        public MainWindow()
        {
            InitializeComponent();
            UpdateDayDisplay();
        }

        // Runs when the user clicks the Enter button
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (!TryGetValidInput(out int value))
                return;

            // Store value
            totalMessages += value;

            // Display value in log
            AddEntryToLog(value);

            // Move to next day (stop at Day 7 for now)
            if (currentDay < MaxDays)
            {
                currentDay++;
                UpdateDayDisplay();
                txtInput.Clear();
                txtInput.Focus();
            }
            else
            {
                // Day 7 reached — average comes later
                txtInput.Clear();
                txtInput.Focus();
            }
        }

        // Runs when the user clicks the Reset button
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            currentDay = 1;
            totalMessages = 0;

            txtLog.Clear();
            txtAverage.Text = "";
            txtInput.Clear();

            UpdateDayDisplay();
            txtInput.Focus();
        }

        // Runs when the user clicks the Exit button
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Updates the Day label
        private void UpdateDayDisplay()
        {
            txtDayDisplay.Text = $"Day {currentDay}";
        }

        // Checks input is a whole number between 0 and 10000
        private bool TryGetValidInput(out int value)
        {
            value = 0;
            string raw = txtInput.Text.Trim();

            if (!int.TryParse(raw, out value))
            {
                MessageBox.Show("Enter a whole number.", "Input Error");
                txtInput.Focus();
                txtInput.SelectAll();
                return false;
            }

            if (value < MinValue || value > MaxValue)
            {
                MessageBox.Show("Enter a value from 0 to 10000.", "Input Error");
                txtInput.Focus();
                txtInput.SelectAll();
                return false;
            }

            return true;
        }

        // Adds a line to the log textbox
        private void AddEntryToLog(int value)
        {
            string line = $"Day {currentDay}: {value}";

            if (txtLog.Text.Length == 0)
                txtLog.Text = line;
            else
                txtLog.Text += Environment.NewLine + line;
        }
    }
}