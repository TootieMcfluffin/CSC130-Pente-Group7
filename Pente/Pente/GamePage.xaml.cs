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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

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
        GameState currentState;

        int turnCount;
        public string p1turn;
        public string p2turn;
        private string recentPath = "";

        public int TurnTimer { get; set; } = 20;

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

            gameBoard.GameBoard[rowCount / 2, colCount / 2].TokenXY = "X";
            
            playTimer.Tick += new EventHandler(TurnTimerEvent);
            playTimer.Interval = new TimeSpan(0, 0, 1);
            TimerLabel.Content = TurnTimer;

            playTimer.Start();
            
        }

        public GamePage(GameState game)
        {
            InitializeComponent();
            InitializeBoard(game.BoardState, game.RowCount, game.ColCount);

            player1 = new Player(game.Player1Name, Enums.PlayerOrderEnum.PLAYER1);
            player2 = new Player(game.Player2Name, Enums.PlayerOrderEnum.PLAYER2);

            player1.Captures = game.Player1CaptureCount;
            player2.Captures = game.Player2CaptureCount;

            Player1NameLabel.Content = player1.Name;
            Player2NameLabel.Content = player2.Name;
            Player1CapturesLabel.Content = player1.Captures;
            Player2CapturesLabel.Content = player2.Captures;
            turnCount = game.TurnCount;

            p1turn = "It\'s " + player1.Name + "'s Turn!";
            p2turn = "It\'s " + player2.Name + "'s Turn!";
            if(turnCount % 2 == 0)
            {
                PlayerTurnLabel.Content = p1turn;
            }
            else
            {
                PlayerTurnLabel.Content = p2turn;
            }

            playTimer.Tick += new EventHandler(TurnTimerEvent);
            playTimer.Interval = new TimeSpan(0, 0, 1);
            TimerLabel.Content = TurnTimer;

            playTimer.Start();

        }

        public void InitializeBoard(int rowCount, int colCount)
        {
            gameBoard = new Board(rowCount, colCount);
            InitializeImageGrid();
            InitializeGrid();
        }

        public void InitializeBoard(string[,] savedBoard, int rowCount, int colCount)
        {
            gameBoard = new Board(rowCount, colCount);
            InitializeImageGrid();
            InitializeGrid(savedBoard);
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
        public void InitializeGrid(string[,] savedBoard)
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
                    Cell newCellBoii = new Cell(savedBoard[i,j]);
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (recentPath == "")
            {
                SaveAs_Click(sender, e);
            } else
            {
                Stream filestream = File.Open(recentPath, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();

                currentState.BoardState = new string[gameBoard.rowCount, gameBoard.colCount];
                for(int row = 0; row < gameBoard.rowCount; row++)
                {
                    for(int col = 0; col < gameBoard.colCount; col++)
                    {
                        currentState.BoardState[row, col] = gameBoard.GameBoard[row, col].TokenXY;
                    }
                }

                currentState.TurnCount = turnCount;
                currentState.Player1Name = player1.Name;
                currentState.Player1CaptureCount = player1.Captures;
                currentState.Player2Name = player2.Name;
                currentState.Player2CaptureCount = player2.Captures;

                currentState.RowCount = gameBoard.rowCount;
                currentState.ColCount = gameBoard.colCount;

                formatter.Serialize(filestream, currentState);
                filestream.Close();
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Pente file (*.pen)|*.pen";
            //saveFileDialog.InitialDirectory = @"..\\..\\SavedContactLists\\";

            //saveFileDialog.ShowDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                recentPath = saveFileDialog.FileName;
                Stream filestream = File.Open(saveFileDialog.FileName, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();

                currentState.BoardState = new string[gameBoard.rowCount, gameBoard.colCount];
                for (int row = 0; row < gameBoard.rowCount; row++)
                {
                    for (int col = 0; col < gameBoard.colCount; col++)
                    {
                        currentState.BoardState[row, col] = gameBoard.GameBoard[row, col].TokenXY;
                    }
                }

                currentState.TurnCount = turnCount;
                currentState.Player1Name = player1.Name;
                currentState.Player1CaptureCount = player1.Captures;
                currentState.Player2Name = player2.Name;
                currentState.Player2CaptureCount = player2.Captures;

                currentState.RowCount = gameBoard.rowCount;
                currentState.ColCount = gameBoard.colCount;

                formatter.Serialize(filestream, currentState);
                filestream.Close();
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pente file (*.pen)|*.pen";
            openFileDialog.ShowDialog();

            Stream filestream = File.Open(openFileDialog.FileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            GameState currentState = (GameState)formatter.Deserialize(filestream);

            filestream.Close();

            GamePage gm = new GamePage(currentState);
            this.NavigationService.Navigate(gm);
        }

        private void Exit_To_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainM = new MainMenu();
            this.NavigationService.Navigate(mainM);
        }

        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            Instructions instructions = new Instructions(this);
            this.NavigationService.Navigate(instructions);
        }
    }
}
