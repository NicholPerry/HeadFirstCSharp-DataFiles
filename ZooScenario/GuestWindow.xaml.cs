using System;
using System.Windows;
using System.Windows.Controls;
using People;
using Reproducers;

namespace ZooScenario
{
    /// <summary>
    /// Interaction logic for GuestWindow.xaml.
    /// </summary>
    public partial class GuestWindow : Window
    {
        /// <summary>
        /// The guest.
        /// </summary>
        private Guest guest;

        /// <summary>
        /// Initializes a new instance of the GuestWindow class.
        /// </summary>
        /// <param name="guest"> Passes in the guest. </param>
        public GuestWindow(Guest guest)
        {
            this.guest = guest;
            this.InitializeComponent();
        }

        /// <summary>
        /// The window loaded events.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.nameTextBox.Text = this.guest.Name;
            this.ageTextBox.Text = this.guest.Age.ToString();
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            this.genderComboBox.SelectedItem = this.guest.Gender;
            this.walletColorComboBox.ItemsSource = Enum.GetValues(typeof(WalletColor));
            this.walletColorComboBox.SelectedItem = this.guest.Wallet.Color;
            this.moneyBalanceLabel.Content = this.guest.Wallet.MoneyBalance.ToString("C");
            this.accountBalanceLabel.Content = this.guest.CheckingAccount.MoneyBalance.ToString("C");
            moneyBalanceComboBox.Items.Add(1);
            moneyBalanceComboBox.Items.Add(5);
            moneyBalanceComboBox.Items.Add(10);
            moneyBalanceComboBox.Items.Add(20);
            this.moneyBalanceComboBox.SelectedItem = this.moneyBalanceComboBox.Items[0];
            accountBalanceComboBox.Items.Add(1);
            accountBalanceComboBox.Items.Add(5);
            accountBalanceComboBox.Items.Add(10);
            accountBalanceComboBox.Items.Add(20);
            accountBalanceComboBox.Items.Add(50);
            accountBalanceComboBox.Items.Add(100);
            this.accountBalanceComboBox.SelectedItem = this.accountBalanceComboBox.Items[0];
        }

        /// <summary>
        /// The ok button of the guest window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// The name box of the guest window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.guest.Name = this.nameTextBox.Text;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The age box of the guest window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void AgeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.guest.Age = int.Parse(ageTextBox.Text);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The gender box of the guest window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void GenderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.guest.Gender = (Gender)genderComboBox.SelectedItem;
        }

        /// <summary>
        /// The wallet color box of the guest window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void WalletColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.guest.Wallet.Color = (WalletColor)walletColorComboBox.SelectedItem;
        }

        /// <summary>
        /// Adds money to the guests wallet.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void AddMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            this.guest.Wallet.AddMoney(decimal.Parse(moneyBalanceComboBox.Text));
            this.moneyBalanceLabel.Content = this.guest.Wallet.MoneyBalance.ToString("C");
        }

        /// <summary>
        /// Subtracts money from the guests wallet.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void SubtractMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            this.guest.Wallet.RemoveMoney(decimal.Parse(moneyBalanceComboBox.Text));
            this.moneyBalanceLabel.Content = this.guest.Wallet.MoneyBalance.ToString("C");
        }

        /// <summary>
        /// Adds money to the guests checking account.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void AddAccountButton_Click(object sender, RoutedEventArgs e)
        {
            this.guest.CheckingAccount.AddMoney(decimal.Parse(accountBalanceComboBox.Text));
            this.accountBalanceLabel.Content = this.guest.CheckingAccount.MoneyBalance.ToString("C");
        }

        /// <summary>
        /// Subtracts money from the guests checking account.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void SubtractAccountButton_Click(object sender, RoutedEventArgs e)
        {
            this.guest.CheckingAccount.RemoveMoney(decimal.Parse(accountBalanceComboBox.Text));
            this.accountBalanceLabel.Content = this.guest.CheckingAccount.MoneyBalance.ToString("C");
        }
    }
}
