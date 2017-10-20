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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pente.Enums;
using Pente.Models;

namespace Pente
{
    /// <summary>
    /// Interaction logic for InitializationPage.xaml
    /// </summary>
    public partial class InitializationPage : Page
    {
        public InitializationPage()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            string playerOneName = NameOne.Text;
            string playerTwoName = NameTwo.Text;
            if (!string.IsNullOrEmpty(playerOneName) && !string.IsNullOrEmpty(playerTwoName))
            {
                if (playerOneName.Equals(playerTwoName, StringComparison.OrdinalIgnoreCase))
                {
                    playerTwoName += "Clone";
                }
            }
            if (playerOneName.Trim() == "")
            {
                playerOneName = "Player One";
            }
            if (playerTwoName.Trim() == "")
            {
                playerTwoName = "Player Two";
            }
            Player playerOne = new Player(playerOneName, PlayerOrderEnum.PLAYER1);
            Player playerTwo = new Player(playerTwoName, PlayerOrderEnum.PLAYER2);
            GamePage game = new GamePage(playerOneName, playerTwoName, 25,25); //Change nums later
            this.NavigationService.Navigate(game);

        }
    }
}
