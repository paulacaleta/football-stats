using FootballStats.Clubs;
using FootballStats.Common;
using FootballStats.Competitions;
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
    /// Interaction logic for CreateClubWindow.xaml
    /// </summary>
    public partial class CreateClubWindow : Window
    {
        public CreateClubWindow()
        {
            InitializeComponent();
        }

        private void OnCreateButtonClick(object sender, RoutedEventArgs e)
        {
            string clubName = this.ClubNameTextBox.Text;
            Nationality nationality = (Nationality)this.NationalityComboBox.SelectedItem;

            Club newClub = new Club(clubName, nationality);
            World.AddClub(newClub);
            World.Save();
            this.Close();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
