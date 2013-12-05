using FootballStats.Clubs;
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
    /// Interaction logic for AddPlayerToClubWindow.xaml
    /// </summary>
    public partial class AddPlayerToClubWindow : Window
    {
        private Club club;
        public AddPlayerToClubWindow(Club club)
        {
            InitializeComponent();
            this.club = club;
            this.ClubTextBlock.Text = this.club.ToString();
        }

        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            club.AddPlayer(this.PlayersListBox.SelectedItem as Player);
            (this.PlayersListBox.SelectedItem as Player).AfiliatedClub = club.Name;
        }
    }
}
