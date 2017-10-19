using Pente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Pente.GameProcesses;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pente.Converters;

namespace Pente
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        SolidColorBrush OffColor = new SolidColorBrush(System.Windows.Media.Colors.Purple);  //Change brushes to imagebrushes
        SolidColorBrush OnColor = new SolidColorBrush(System.Windows.Media.Colors.Aqua);
        Player player1;
        Player player2;
        Board gameBoard;
        int turnCount;

        public GamePage(string player1Name, string player2Name, int rowCount, int colCount)
        {
            InitializeComponent();
            InitializeBoard(rowCount, colCount);
            player1 = new Player(player1Name, Enums.PlayerOrderEnum.PLAYER1);
            player2 = new Player(player2Name, Enums.PlayerOrderEnum.PLAYER2);
            turnCount = 2;
            gameBoard.GameBoard[rowCount / 2, colCount / 2] = "X";
        }

        public GamePage(GameState game)
        {
            InitializeComponent();

        }

        public void InitializeBoard(int rowCount, int colCount)
        {
            gameBoard = new Board(rowCount, colCount);
        }

        public void playerTurnDecision(int[] move)
        {
            Player currentPlayer;
            //if turncount /2 == 0 Player 2
            if(turnCount % 2 == 0)
            {
                //player turn
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
                //player turn
            }

            if(GameRules.IsMoveLegal(gameBoard, move, turnCount))
            {
                gameBoard.GameBoard[move[0], move[1]] = "" + currentPlayer.pieceChar;
                GameRules.RemovePieces(currentPlayer, gameBoard, move);
                resetTimer();
                //updateGridImages();
            }
        }
        /// <summary>
        /// The current grid that's displayed will be deleted and replaced
        /// with a new grid with rows and columns specified by the GridControl sliders
        /// </summary>
        public void InitializeGrid()
        {
            GameGrid.Children.Clear();

            //for (int i = 0; i < GameGrid.Rows; i++)
            //{
            //    for (int j = 0; j < GameGrid.Columns; j++)
            //    {
            //        Label newLabel = MakeRectangle(); //import method from conways
            //        newLabel.MouseLeftButtonDown += RectangleLabel_Click; //label click method
            //        string filler = " ";
            //        gameBoard.GameBoard[i, j] = filler;
            //        newLabel.DataContext = filler;
            //        Binding newBinding = new Binding();
            //        newBinding.Path = new PropertyPath("IsOn");
            //        StringToImageConverter b2b = new StringToImageConverter();
            //        b2b.OnBrush = OnColor;
            //        b2b.OffBrush = ;
            //        newBinding.Converter = b2b;
            //        newBinding.Mode = BindingMode.TwoWay;
            //        newBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //        BindingOperations.SetBinding(newLabel, Label.BackgroundProperty, newBinding);
            //        GameGrid.Children.Add(newLabel);

            //    }
            //}
        }
        //private void updateGridImages()
        //{
        //    //Updates all images
        //    //If gameboard[row,col] == "X" change grid[row,col] = black stone image
        //    //else if gameboard[row,col] == "Y" change grid[row,col] = white stone image
        //    //else change grid[row,col] = transparent stone image
        //    throw new NotImplementedException();
        //}

        private void resetTimer()
        {
            //This will reset the timer
            turnCount++;
            throw new NotImplementedException();
        }

        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    if (recentPath == "")
        //    {
        //        SaveAs_Click(sender, e);
        //    }
        //    Stream filestream = File.Open(recentPath + "\\contacts.con", FileMode.Create);
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    formatter.Serialize(filestream, contacts);
        //    filestream.Close();
        //}

        //private void SaveAs_Click(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();

        //    saveFileDialog.Filter = "ContactList file (*.con)|*.con";
        //    //saveFileDialog.InitialDirectory = @"..\\..\\SavedContactLists\\";

        //    saveFileDialog.ShowDialog();

        //    if (saveFileDialog.ShowDialog() == true)
        //    {
        //        recentPath = saveFileDialog.FileName;
        //        Stream filestream = File.Open(saveFileDialog.FileName, FileMode.Create);
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(filestream, contacts);
        //        filestream.Close();
        //    }
        //}

        //private void Load_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "ContactList file (*.con)|*.con";
        //    openFileDialog.ShowDialog();

        //    Stream filestream = File.Open(openFileDialog.FileName, FileMode.Open);
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    ObservableCollection<Contact> cons = new ObservableCollection<Contact>();
        //    cons = (ObservableCollection<Contact>)formatter.Deserialize(filestream);
        //    contacts.Clear();
        //    foreach (Contact contact in cons)
        //    {
        //        contacts.Add(contact);
        //    }
        //    filestream.Close();
        //}
    }
}
