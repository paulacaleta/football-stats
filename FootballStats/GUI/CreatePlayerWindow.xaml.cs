using FootballStats.Common;
using FootballStats.Competitions;
using FootballStats.Persons;
using FootballStats.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for CreatePlayerWindow.xaml
    /// </summary>
    public partial class CreatePlayerWindow : Window
    {

        public CreatePlayerWindow()
        {
            InitializeComponent();
            World.Load();
        }

        private void OnPersonTypeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.PersonTypeComboBox.SelectedItem == "Player")
            {
                this.PlayerPositionComboBox.IsEnabled = true;
                this.StaffPositionComboBox.IsEnabled = false;

                this.PlayerPositionTextBox.Foreground = Brushes.Black;
                this.StaffPositionTextBox.Foreground = Brushes.Gray;
            }
            else if (this.PersonTypeComboBox.SelectedItem == "Staff")
            {
                this.PlayerPositionComboBox.IsEnabled = false;
                this.StaffPositionComboBox.IsEnabled = true;

                this.PlayerPositionTextBox.Foreground = Brushes.Gray;
                this.StaffPositionTextBox.Foreground = Brushes.Black;
            }
            else
            {
                this.PlayerPositionComboBox.IsEnabled = false;
                this.StaffPositionComboBox.IsEnabled = false;

                this.PlayerPositionTextBox.Foreground = Brushes.Gray;
                this.StaffPositionTextBox.Foreground = Brushes.Gray;
            }
        }

        private void OnCreateButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.PersonTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("You must select person type!");
                return;
            }
            CreatePersonViewModel newModel = new CreatePersonViewModel();
            newModel.FirstName = this.FirstNameTextBox.Text;

            newModel.MiddleName = this.MiddletNameTextBox.Text;
            newModel.LastName = this.LastNameTextBox.Text;

            newModel.WeeklyWage = int.Parse(this.WeeklyWageTextBox.Text);
            newModel.DateOfBirth = this.DateOfBirthTextBox.Text;

            newModel.Nationality = (Nationality)this.NationalityComboBox.SelectedItem;

            newModel.PersonType = this.PersonTypeComboBox.SelectedItem.ToString();

            newModel.PlayerPosition = (PlayerPosition)this.PlayerPositionComboBox.SelectedItem;
            newModel.StaffPosition = (StaffPosition)this.StaffPositionComboBox.SelectedItem;

            try
            {
                newModel.Execute();
                this.Close();
            }
            catch (InvalidPersonDataException exception)
            {
                MessageBox.Show(String.Format("{0}", exception.Message));
            }
            catch (FormatException fe)
            {
                MessageBox.Show(String.Format("{0}", fe.Message));
            }
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
