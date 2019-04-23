using System;
using System.Windows;
using Animals;
using Reproducers;

namespace ZooScenario
{
    /// <summary>
    /// Interaction logic for AnimalWindow.xaml.
    /// </summary>
    public partial class AnimalWindow : Window
    {
        /// <summary>
        /// The animal.
        /// </summary>
        private Animal animal;

        /// <summary>
        /// Initializes a new instance of the AnimalWindow class.
        /// </summary>
        /// <param name="animal"> The animal to create. </param>
        public AnimalWindow(Animal animal)
        {
            this.animal = animal;
            this.InitializeComponent();
        }

        /// <summary>
        /// Loads the window for the events.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.nameTextBox.Text = this.animal.Name;
            this.ageTextBox.Text = this.animal.Age.ToString();
            this.weightTextBox.Text = this.animal.Weight.ToString();
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            this.genderComboBox.SelectedItem = this.animal.Gender;
            this.pregnancyStatusLabel.Content = this.animal.IsPregnant ? "Yes" : "No";
        }

        /// <summary>
        /// The ok button to click.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// The name box of the animal window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.animal.Name = this.nameTextBox.Text;
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        /// <summary>
        /// The age box of the animal window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void AgeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.animal.Age = int.Parse(ageTextBox.Text);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        /// <summary>
        /// The weight box of the animal window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void WeightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.animal.Weight = double.Parse(weightTextBox.Text);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        /// <summary>
        /// The gender selection box of the animal window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void GenderComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.animal.Gender = (Gender)genderComboBox.SelectedItem;
            this.makePregnantButton.IsEnabled = (this.animal.Gender == Gender.Female) ? true : false;
        }

        /// <summary>
        /// The make pregnant button of the animal window.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void MakePregnantButton_Click(object sender, RoutedEventArgs e)
        {
            this.animal.MakePregnant();
            this.makePregnantButton.IsEnabled = false;
            this.pregnancyStatusLabel.Content = "Yes";
        }
    }
}
