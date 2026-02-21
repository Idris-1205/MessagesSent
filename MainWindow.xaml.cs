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
    /// The app validates input, displays daily entries, calculates the average,
    /// and disables input until the user resets the application.
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
            ResetApp();
        }

        // Runs when the user clicks the Enter button
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (!TryGetValidInput(out int value))
                return;

            totalMessages += value;
            AddEntryToLog(value);

            if (currentDay < MaxDays)
            {
                currentDay++;
                UpdateDayDisplay();
                txtInput.Clear();
                txtInput.Focus();
            }
            else
            {
                ShowAverageAndLock();
            }
        }

        // Runs when the user clicks the Reset button
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetApp();
        }

        // Runs when the user clicks the Exit button
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Resets app back to Day 1
        private void ResetApp()
        {
            currentDay = 1;
            totalMessages = 0;

            txtDayDisplay.Text = "Day 1";
            txtLog.Clear();
            txtAverage.Text = "";
            txtInput.Clear();

            txtInput.IsEnabled = true;
            btnEnter.IsEnabled = true;

            txtInput.Focus();
        }

        // Updates Day label
        private void UpdateDayDisplay()
        {
            txtDayDisplay.Text = $"Day {currentDay}";
        }

        // Validates input
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

        // Adds one entry to the log
        private void AddEntryToLog(int value)
        {
            string line = $"Day {currentDay}: {value}";

            if (txtLog.Text.Length == 0)
                txtLog.Text = line;
            else
                txtLog.Text += Environment.NewLine + line;
        }

        // Calculates average and locks input
        private void ShowAverageAndLock()
        {
            double average = totalMessages / (double)MaxDays;
            txtAverage.Text = $"Messages per day: {average:F1}";

            txtInput.IsEnabled = false;
            btnEnter.IsEnabled = false;

            btnReset.Focus();
        }
    }
}