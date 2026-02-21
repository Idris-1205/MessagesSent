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
        // Constructor: runs when the window is first created
        public MainWindow()
        {
            InitializeComponent(); // Loads the UI defined in MainWindow.xaml
        }

        // Runs when the user clicks the Enter button
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            // To be added
        }

        // Runs when the user clicks the Reset button
        // Will reset the application back to its initial state
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            // To be added
        }

        // Runs when the user clicks the Exit button
        // Closes the application
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}