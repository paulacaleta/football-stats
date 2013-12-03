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
using FootballStats.Persons;

namespace GUI
{
    /// <summary>
    /// Interaction logic for ShowPersonsWindow.xaml
    /// </summary>
    public partial class ShowPersonsWindow : Window
    {
        public ShowPersonsWindow()
        {
            InitializeComponent();
        }

        private void OnPlayersListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayPlayerInfo(this.PlayersListBox.SelectedItem as Person);
        }

        private void DisplayPlayerInfo(Person pers)
        {
            this.PersonFirstNameTextBlock.Text = pers.Name.FirstName;
            this.PersonSecondNameTextBlock.Text = pers.Name.MiddleName;
            this.PersonLastNameTextBlock.Text = pers.Name.LastName;
            //if(pers is ClubAffiliatedPerson){this.PersonClubTextBlock.Text = (pers as ClubAffiliatedPerson)} ACTIVATE LATER

        }
    }
}
