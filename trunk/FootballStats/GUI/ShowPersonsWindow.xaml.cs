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
            // TOP PANEL
            this.PersonFirstNameTextBlock.Text = pers.Name.FirstName;
            this.PersonSecondNameTextBlock.Text = pers.Name.MiddleName;
            this.PersonLastNameTextBlock.Text = pers.Name.LastName;
            

            // LEFT PANEL
            this.PersonAgeTextBlock.Text = string.Format("Age" + Environment.NewLine + pers.GetAge().ToString()+Environment.NewLine);
            if (pers is ClubAffiliatedPerson) 
            {                 
                this.PersonWageTextBlock.Text = 
                    String.Format("Monthly Wage"+Environment.NewLine + (pers as ClubAffiliatedPerson).MonthlyWage().ToString()
                    +Environment.NewLine);
            }

            // RIGHT PANEL
            if (pers is ClubAffiliatedPerson) { this.PersonClubTextBlock.Text = (pers as ClubAffiliatedPerson).AffiliatedClub; }

            if (pers is Player)
            {
                this.PersonPositionOrRoleTextBlock.Text =
                    String.Format("Player position" + Environment.NewLine + (pers as Player).Positions[0].ToString()
                    + Environment.NewLine);
            }
            else if (pers is StaffMember)
            {
                this.PersonPositionOrRoleTextBlock.Text =
                    String.Format("Staff role" + Environment.NewLine + (pers as StaffMember).StaffPosition.ToString()
                    + Environment.NewLine);
            }
        }
    }
}
