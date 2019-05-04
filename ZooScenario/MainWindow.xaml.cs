using System;
using System.Windows;
using System.Windows.Media;
using Accounts;
using Animals;
using BirthingRooms;
using People;
using Reproducers;
using Zoos;

namespace ZooScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Minnesota's Como Zoo.
        /// </summary>
        private Zoo comoZoo;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

#if DEBUG
            this.Title += " [DEBUG]";
#endif
        }
               
        /// <summary>
        /// Creates the admit guest events.
        /// </summary>
        /// <param name="sender"> The object that initiated the event. </param>
        /// <param name="e"> The event arguments for the event. </param>
        private void AdmitGuestButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {                
                Guest guest = new Guest("Ethel", 42, 30.00m, WalletColor.Salmon, Gender.Female, new Account());

                try
                {
                    this.comoZoo.AddGuest(guest, this.comoZoo.SellTicket(guest));
                    this.PopulateGuestListBox();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message + "\n" + ex.InnerException.GetType().ToString() + ": " + ex.InnerException.Message);
                }
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("The guest couldn't be admitted because they did not have a ticket.");
            }
        }

        /// <summary>
        /// Creates the feed animal events.
        /// </summary>
        /// <param name="sender"> The object that initiated the event. </param>
        /// <param name="e"> The event arguments for the event. </param>
        private void FeedAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            Guest guest = this.guestListBox.SelectedItem as Guest;
            Animal animal = this.animalListBox.SelectedItem as Animal;

            if (guest != null && animal != null)
            {
                guest.FeedAnimal(animal, this.comoZoo.AnimalSnackMachine);
                this.PopulateAnimalListBox();
                this.PopulateGuestListBox();
            }
            else if (guest == null || animal == null)
            {
                MessageBox.Show("You must choose both a guest and an animal to feed an animal.");
            }

            guestListBox.SelectedItem = guest;
            animalListBox.SelectedItem = animal;
        }

        /// <summary>
        /// Increases the temperature in the zoo.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void IncreaseTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.comoZoo.BirthingRoomTemperature++;
                this.ConfigureBirthingRoomControls();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Decreases the temperature in the zoo.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void DecreaseTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.comoZoo.BirthingRoomTemperature--;
                this.ConfigureBirthingRoomControls();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Configures the controls of the birthing room.
        /// </summary>
        private void ConfigureBirthingRoomControls()
        {
            double temperature = this.comoZoo.BirthingRoomTemperature;
            string result = string.Format("{0:0.0°}", temperature);

            temperatureBorder.Height = this.comoZoo.BirthingRoomTemperature * 2;
            temperatureLabel.Content = result;

            double colorLevel = ((this.comoZoo.BirthingRoomTemperature - BirthingRoom.MinTemperature) * 255) / (BirthingRoom.MaxTemperature - BirthingRoom.MinTemperature);

            this.temperatureBorder.Background = new SolidColorBrush(Color.FromRgb(
                Convert.ToByte(colorLevel),
                Convert.ToByte(255 - colorLevel),
                Convert.ToByte(255 - colorLevel)));
        }

        /// <summary>
        /// Populates the list box with the animals of the zoo.
        /// </summary>
        private void PopulateAnimalListBox()
        {
            animalListBox.ItemsSource = null;
            animalListBox.ItemsSource = this.comoZoo.Animals;
        }

        /// <summary>
        /// Populates the list box with the guests of the zoo.
        /// </summary>
        private void PopulateGuestListBox()
        {
            guestListBox.ItemsSource = null;
            guestListBox.ItemsSource = this.comoZoo.Guests;
        }

        /// <summary>
        /// Loads the window for the events.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.comoZoo = Zoo.NewZoo();

            this.ConfigureBirthingRoomControls();
            this.PopulateAnimalListBox();
            this.PopulateGuestListBox();
            this.animalTypeComboBox.ItemsSource = Enum.GetValues(typeof(AnimalType));
            this.changeMoveBehaviorComboBox.ItemsSource = Enum.GetValues(typeof(MoveBehaviorType));
        }

        /// <summary>
        /// The button to click to add an animal.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AnimalType type = (AnimalType)this.animalTypeComboBox.SelectedItem;
                Animal animal = AnimalFactory.CreateAnimal(type, "Name", 1, 1, Gender.Male);
                Window animalWindow = new AnimalWindow(animal);
                animalWindow.ShowDialog();

                if (animalWindow.DialogResult == true)
                {
                    this.comoZoo.AddAnimal(animal);
                    this.PopulateAnimalListBox();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("An animal must be selected before adding an animal to the zoo.");
            }
        }

        /// <summary>
        /// Changes the type of move behavior for the animal.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void ChangeMoveBehaviorButton_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = this.animalListBox.SelectedItem as Animal;
            object type = this.changeMoveBehaviorComboBox.SelectedItem;

            if (animal != null && type != null)
            {
                animal.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior((MoveBehaviorType)type);
            }
            else
            {
                MessageBox.Show("Please select an animal and a movement type to change the behavior.");
            }
        }

        /// <summary>
        /// Removes an animal.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void RemoveAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Animal animal = this.animalListBox.SelectedItem as Animal;
                if (MessageBox.Show(string.Format("Are you sure you want to remove animal: {0}?", animal.Name), "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.comoZoo.RemoveAnimal(animal);
                    this.PopulateAnimalListBox();
                    this.PopulateGuestListBox();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select an animal to remove");
            }
        }

        /// <summary>
        /// Removes a guest.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void RemoveGuestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guest guest = this.guestListBox.SelectedItem as Guest;
                if (MessageBox.Show(string.Format("Are you sure you want to remove guest: {0}?", guest.Name), "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.comoZoo.RemoveGuest(guest);

                    this.PopulateGuestListBox();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select a guest to remove");
            }
        }

        /// <summary>
        /// Adds a guest.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guest guest = new Guest("Greg", 44, 15.00m, WalletColor.Brown, Gender.Male, new Account());

                Window guestWindow = new GuestWindow(guest);
                guestWindow.ShowDialog();

                try
                {
                    if (guestWindow.DialogResult == true)
                    {
                        this.comoZoo.AddGuest(guest, this.comoZoo.SellTicket(guest));
                        this.PopulateGuestListBox();
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("An guest must be entered before adding the zoo.");
            }
        }

        /// <summary>
        /// Double clicking on the animal list box events.
        /// </summary>
        /// <param name="sender"> The object that initiated the event. </param>
        /// <param name="e"> The event arguments for the event. </param>
        private void AnimalListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Animal animal = this.animalListBox.SelectedItem as Animal;

            Window animalWindow = new AnimalWindow(animal);
            animalWindow.ShowDialog();

            if (animalWindow.DialogResult == true)
            {
                this.PopulateAnimalListBox();
            }
        }

        /// <summary>
        /// Double clicking on the guest list box events.
        /// </summary>
        /// <param name="sender"> The object that initiated the event. </param>
        /// <param name="e"> The event arguments for the event. </param>
        private void GuestListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Guest guest = this.guestListBox.SelectedItem as Guest;

            Window guestWindow = new GuestWindow(guest);
            guestWindow.ShowDialog();

            if (guestWindow.DialogResult == true)
            {
                this.PopulateGuestListBox();
            }
        }

        /// <summary>
        /// Events occurring when clicking on the show cage button.
        /// </summary>
        /// <param name="sender"> The object that initiated the event. </param>
        /// <param name="e"> The event arguments for the event. </param>
        private void ShowCageButton_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = this.animalListBox.SelectedItem as Animal;

            try
            {
                if (animal != null)
                {
                    Window cageWindow = new CageWindow(this.comoZoo.FindCage(animal.GetType()));
                    cageWindow.Show();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select an animal to show.");
            }
        }

        /// <summary>
        /// Events that occur when clicking on the adopt animal button.
        /// </summary>
        /// <param name="sender"> The object that initiated the event. </param>
        /// <param name="e"> The event arguments for the event. </param>
        private void AdoptAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Guest guest = this.guestListBox.SelectedItem as Guest;
                Animal animal = this.animalListBox.SelectedItem as Animal;
                guest.AdoptedAnimal = animal;

                Cage cage = this.comoZoo.FindCage(animal.GetType());
                cage.Add(guest);

                this.PopulateGuestListBox();
                this.PopulateAnimalListBox();

                guestListBox.SelectedItem = guest;
                ////animalListBox.SelectedItem = animal;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a guest and an animal.");
            }
        }

        /// <summary>
        /// Events that occur when clicking on the un-adopt animal button.
        /// </summary>
        /// <param name="sender"> The object that initiated the event. </param>
        /// <param name="e"> The event arguments for the event. </param>
        private void UnadoptAnimalButton_Click(object sender, RoutedEventArgs e)
        {
                Guest guest = this.guestListBox.SelectedItem as Guest;
                Animal animal = guest.AdoptedAnimal;

                if (guest != null && animal != null)
                {
                        if (animalListBox.SelectedItem == animal)
                        {
                            Cage cage = this.comoZoo.FindCage(guest.AdoptedAnimal.GetType());

                            cage.Remove(guest);
                            guest.AdoptedAnimal = null;

                            this.PopulateGuestListBox();
                        }                  
                    else if (animalListBox.SelectedItem != animal && animalListBox.SelectedItem != null)
                    {
                        MessageBox.Show($"The animal: {animalListBox.SelectedItem} is not {guest.Name}'s adopted animal.");
                    }
                    else if (animalListBox.SelectedItem == null)
                    {
                        MessageBox.Show("Please select a guest and an animal.");
                    }                    
                }
        }

        /// <summary>
        /// Allows the animal to give birth if pregnant.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void BirthAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            Animal animal = this.animalListBox.SelectedItem as Animal;

            if (animal == null)
            {
                MessageBox.Show("The animal does not exist.");
            }
            else
            {
                if (animal.IsPregnant == false)
                {
                    MessageBox.Show($"The animal: {animal.Name} is not pregnant.");
                }
                else if (animal.IsPregnant == true)
                {
                    Animal baby = null;

                    baby = animal.Reproduce() as Animal;
                    this.comoZoo.AddAnimal(baby);

                    this.PopulateAnimalListBox();
                }
            }
        }
    }
}