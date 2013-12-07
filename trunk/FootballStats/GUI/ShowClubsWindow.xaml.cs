using FootballStats.Clubs;
using FootballStats.Competitions;
using FootballStats.Persons;
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
    /// Interaction logic for ShowClubsWindow.xaml
    /// </summary>
    public partial class ShowClubsWindow : Window
    {
        public ShowClubsWindow()
        {
            InitializeComponent();
            if (ClubsListBox.Items.Count == 0)
            {
                MessageBox.Show("There are no clubs in the database." + Environment.NewLine + "Please add a new club.");
                this.Close();
            }
        }

        private void OnClubsListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayClubInfo(this.ClubsListBox.SelectedItem as Club);
            this.PlayersAndStaffListBox.ItemsSource = (this.ClubsListBox.SelectedItem as Club).Team;
        }       

        private void DisplayClubInfo(Club selectedClub)
        {
            
            this.TotalPlayersTextBlock.Text = string.Format(
                "Total players" + Environment.NewLine + selectedClub.TotalPlayersAtClub().ToString());
            try
            {
                this.AverageAgeTextBlock.Text = string.Format(
                "Average age" + Environment.NewLine + selectedClub.TeamAverageAge().ToString());
            }
            catch (Exception)
            {
                this.AverageAgeTextBlock.Text = string.Format(
               "No players");               
            }


            try
            {
                this.HighestWageTextBlock.Text = string.Format(
                "Highest wage" + Environment.NewLine + "{0:0.00}", selectedClub.HighestPlayerWage());
            }
            catch (Exception)
            {
                this.HighestWageTextBlock.Text = string.Format(
                "No players");
            }

            try
            {
                this.AverageWagePlayersTextBlock.Text = string.Format(
               "Av. player wage" + Environment.NewLine + "{0:0.00}", selectedClub.AverageWageOfPlayers());
            }
            catch (Exception)
            {
                this.AverageWagePlayersTextBlock.Text = string.Format(
               "No players");
            }

            try
            {
                this.AverageWageStaffTextBlock.Text = string.Format(
               "Average staff wage" + Environment.NewLine + "{0:0.00}", selectedClub.AverageWageOfStaff().ToString());
            }
            catch (Exception)
            {
                this.AverageWageStaffTextBlock.Text = string.Format(
              "No staff");
            }
           
        }

        private void OnAddPlayerButtonClick(object sender, RoutedEventArgs e)
        {

            AddPlayerToClubWindow addPlayerToClubWindow = new AddPlayerToClubWindow(this.ClubsListBox.SelectedItem as Club);
            addPlayerToClubWindow.ShowDialog();
            DisplayClubInfo(this.ClubsListBox.SelectedItem as Club);
            this.PlayersAndStaffListBox.ItemsSource = null;
            this.PlayersAndStaffListBox.ItemsSource = (this.ClubsListBox.SelectedItem as Club).Team;
        }

        private void OnRemovePlayerButtonClick(object sender, RoutedEventArgs e)
        {
            (this.ClubsListBox.SelectedItem as Club).RemovePlayer(this.PlayersAndStaffListBox.SelectedItem as Player);
            DisplayClubInfo(this.ClubsListBox.SelectedItem as Club);
            this.PlayersAndStaffListBox.ItemsSource = null;
            this.PlayersAndStaffListBox.ItemsSource = (this.ClubsListBox.SelectedItem as Club).Team;            
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            World.Save();
        }

        
    }
}
