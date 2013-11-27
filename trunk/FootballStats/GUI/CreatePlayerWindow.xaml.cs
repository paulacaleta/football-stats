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
    }
}
