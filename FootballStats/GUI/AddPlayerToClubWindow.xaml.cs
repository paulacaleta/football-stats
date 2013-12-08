using FootballStats.Clubs;
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
    /// Interaction logic for AddPlayerToClubWindow.xaml
    /// </summary>
    public partial class AddPlayerToClubWindow : Window
    {
        private Club club;
        public AddPlayerToClubWindow(Club club)
        {
            InitializeComponent();
            this.club = club;
            this.ClubTextBlock.Text = this.club.Name;
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.PlayersListBox.SelectedItem is Player)
                {
                    club.AddPlayer(this.PlayersListBox.SelectedItem as Player);
                }
                else if (this.PlayersListBox.SelectedItem is StaffMember)
                {
                    club.AddStaffMember(this.PlayersListBox.SelectedItem as StaffMember);
                }
                
                (this.PlayersListBox.SelectedItem as ClubAffiliatedPerson).AffiliatedClub = this.club.Name;                
                World.Save();
                this.PlayersListBox.ItemsSource = null;
                this.PlayersListBox.ItemsSource = new ShowPersonsViewModel().FreeAgents;
            }
            catch (ClubException err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
