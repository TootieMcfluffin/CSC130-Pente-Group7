using Pente.Models;
using Pente.Enums;
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
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pente
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            InitializationPage initialization = new InitializationPage();
            this.NavigationService.Navigate(initialization);
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            Instructions instruction = new Instructions();
            this.NavigationService.Navigate(instruction);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pente file (*.pen)|*.pen";
            openFileDialog.ShowDialog();

            string fileName = openFileDialog.FileName;
            if(fileName != null && fileName != "")
            {
                Stream filestream = File.Open(fileName, FileMode.Open);
                if (File.Exists(fileName))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    GameState currentState = (GameState)formatter.Deserialize(filestream);

                    filestream.Close();

                    GamePage gm = new GamePage(currentState);
                    this.NavigationService.Navigate(gm);
                }
            }
        }
    }
}
