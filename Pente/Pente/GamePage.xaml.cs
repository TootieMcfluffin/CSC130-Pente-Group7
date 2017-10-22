using Pente.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using Pente.GameProcesses;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pente.Converters;
using System.Timers;
using System.Windows.Threading;

namespace Pente
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        ImageBrush BlackStoneBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\BlackStone.png", UriKind.RelativeOrAbsolute)));
        ImageBrush WhiteStoneBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\WhiteStone.png", UriKind.RelativeOrAbsolute)));
        ImageBrush NoStoneBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\Transparent16x16.png", UriKind.RelativeOrAbsolute)));
        ImageBrush MiddleBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\cross.png", UriKind.RelativeOrAbsolute)));
        ImageBrush TopLeftBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\topleft.png", UriKind.RelativeOrAbsolute)));
        ImageBrush TopRightBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\topright.png", UriKind.RelativeOrAbsolute)));
        ImageBrush BottomRightBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\bottomright.png", UriKind.RelativeOrAbsolute)));
        ImageBrush BottomLeftBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\bottomleft.png", UriKind.RelativeOrAbsolute)));
        ImageBrush LeftSideBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\leftside.png", UriKind.RelativeOrAbsolute)));
        ImageBrush TopSideBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\topside.png", UriKind.RelativeOrAbsolute)));
        ImageBrush RightSideBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\rightside.png", UriKind.RelativeOrAbsolute)));
        ImageBrush BottomSideBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\bottomside.png", UriKind.RelativeOrAbsolute)));
        Player player1;
        Player player2;
        Board gameBoard;
        int turnCount;
        public string p1turn;
        public string p2turn;

        public int TurnTimer { get; set; } = 20;

        //Timer playTimer = new Timer(1000);
        DispatcherTimer playTimer = new DispatcherTimer();
        
        public GamePage(string player1Name, string player2Name, int rowCount, int colCount)
        {
            InitializeComponent();
            InitializeBoard(rowCount, colCount);
            player1 = new Player(player1Name, Enums.PlayerOrderEnum.PLAYER1);
            player2 = new Player(player2Name, Enums.PlayerOrderEnum.PLAYER2);
            Player1NameLabel.Content = player1.Name;
            Player2NameLabel.Content = player2.Name;
            Player1CapturesLabel.Content = player1.Captures;
            Player2CapturesLabel.Content = player2.Captures;
            turnCount = 2;
            p1turn = "It\'s " + player1Name + "'s Turn!";
            p2turn = "It\'s " + player2Name + "'s Turn!";
            PlayerTurnLabel.Content = p1turn;
            //playTimer.Interval = 1000;
            //playTimer.Elapsed += TurnTimerEvent;
            gameBoard.GameBoard[rowCount / 2, colCount / 2].TokenXY = "X";
            TimerLabel.Content = TurnTimer;
            //playTimer.AutoReset = true;
            //playTimer.BeginInit();

            playTimer.Tick += new EventHandler(TurnTimerEvent);
            playTimer.Interval = new TimeSpan(0, 0, 1);


            playTimer.Start();
            
        }

        public GamePage(GameState game)
        {
            InitializeComponent();

        }

        public void InitializeBoard(int rowCount, int colCount)
        {
            gameBoard = new Board(rowCount, colCount);
            InitializeImageGrid();
            InitializeGrid();
        }

        public void playerTurn(int[] move)
        {
            Player currentPlayer;
            //if turncount /2 == 0 Player 2
            if(turnCount % 2 == 1)
            {
                PlayerTurnLabel.Content = p1turn;
                currentPlayer = player2;
            }
            else
            {
                PlayerTurnLabel.Content = p2turn;
                currentPlayer = player1;
            }

            if(GameRules.IsMoveLegal(gameBoard, move, turnCount))
            {
                gameBoard.GameBoard[move[0], move[1]].TokenXY = "" + currentPlayer.pieceChar;
                GameRules.RemovePieces(currentPlayer, gameBoard, move);
                resetTimer();
            }
            Player1CapturesLabel.Content = player1.Captures;
            Player2CapturesLabel.Content = player2.Captures;

            if (GameRules.GameOver(currentPlayer, gameBoard))
            {
                if (currentPlayer.hasWon)
                {
                    //popup
                    MessageBox.Show("Congratulations "+ currentPlayer.Name + "! You have won the game!");
                }
                else
                {
                    MessageBox.Show("IT\'S A DRAW! You have filled the board and somehow nobody won... Nice.");
                }
                MainMenu mainM = new MainMenu();
                this.NavigationService.Navigate(mainM);
            }
        }
        /// <summary>
        /// The current grid that's displayed will be deleted and replaced
        /// with a new grid with rows and columns specified by the GridControl sliders
        /// </summary>
        public void InitializeGrid()
        {
            GameGrid.Rows = gameBoard.rowCount;
            GameGrid.Columns = gameBoard.colCount;

            GameGrid.Children.Clear();
            

            for (int i = 0; i < GameGrid.Rows; i++)
            {
                for (int j = 0; j < GameGrid.Columns; j++)
                {
                    Label newLabel = MakeRectangle(); //import method from conways
                    newLabel.MouseLeftButtonDown += RectangleLabel_Click; //label click method
                    Cell newCellBoii = new Cell();
                    gameBoard.GameBoard[i, j] = newCellBoii;
                    newLabel.DataContext = newCellBoii;
                    Binding newBinding = new Binding();
                    newBinding.Path = new PropertyPath("TokenXY");
                    StringToImageConverter s2b = new StringToImageConverter();
                    s2b.BlackStoneBrush = BlackStoneBrush;
                    s2b.WhiteStoneBrush = WhiteStoneBrush;
                    s2b.NoStoneBrush = NoStoneBrush;
                    newBinding.Converter = s2b;
                    newBinding.Mode = BindingMode.TwoWay;
                    newBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    BindingOperations.SetBinding(newLabel, Label.BackgroundProperty, newBinding);
                    GameGrid.Children.Add(newLabel);

                }
            }
        }
        public void InitializeImageGrid()
        {
            ImageGrid.Rows = gameBoard.rowCount;
            ImageGrid.Columns = gameBoard.colCount;

            ImageGrid.Children.Clear();


            for (int i = 0; i < ImageGrid.Rows; i++)
            {
                for (int j = 0; j < ImageGrid.Columns; j++)
                {
                    Label newLabel = MakeRectangle();
                    if ( i == 0 && j == 0)
                    {
                        newLabel.Background = TopLeftBrush;
                    }
                    else if (i == 0 && j == ImageGrid.Columns - 1)
                    {
                        newLabel.Background = TopRightBrush;
                    }
                    else if (i == ImageGrid.Rows - 1 && j == ImageGrid.Columns - 1)
                    {
                        newLabel.Background = BottomRightBrush;
                    }
                    else if (i == ImageGrid.Rows - 1 && j == 0)
                    {
                        newLabel.Background = BottomLeftBrush;
                    }
                    else if (i == 0)
                    {
                        newLabel.Background = TopSideBrush;
                    }
                    else if (j == 0)
                    {
                        newLabel.Background = LeftSideBrush;
                    }
                    else if (j == ImageGrid.Columns - 1)
                    {
                        newLabel.Background = RightSideBrush;
                    }
                    else if (i == ImageGrid.Rows - 1)
                    {
                        newLabel.Background = BottomSideBrush;
                    }
                    else
                    {
                        newLabel.Background = MiddleBrush;
                    }

                    ImageGrid.Children.Add(newLabel);
                }
            }
        }
        
        private Label MakeRectangle()
        {

            ImageBrush shapeBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\cross.png", UriKind.RelativeOrAbsolute)));
            SolidColorBrush shapeBrush2 = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            Thickness thicc = new Thickness(.5);
            Label rectangleLabel = new Label
            {
                Background = shapeBrush
            };
            return rectangleLabel;
        }

        private void RectangleLabel_Click(object sender, EventArgs e)
        {
            Label hithere = (Label)sender;
            int index = GameGrid.Children.IndexOf(hithere);
            int row = index / GameGrid.Columns;
            int column = index - (row * GameGrid.Columns);
            int[] move = { row, column };
            playerTurn(move);
        }

        private void TurnTimerEvent(Object source, EventArgs e)
        {
            TurnTimer--;
            if (TurnTimer < 0) {
                TurnTimer = 20;
                turnCount++;
                if (turnCount % 2 == 0)
                {
                    PlayerTurnLabel.Content = p1turn;
                }
                else
                {
                    PlayerTurnLabel.Content = p2turn;
                }
            }
            TimerLabel.Content = TurnTimer;
        }

        private void resetTimer()
        {
            TurnTimer = 20;
            TimerLabel.Content = TurnTimer;
            turnCount++;
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
