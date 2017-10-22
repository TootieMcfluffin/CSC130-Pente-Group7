using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.Models
{
    [Serializable]
    public struct GameState
    {
        string player1Name;
        string player2Name;

        int player1CaptureCount;
        int player2CaptureCount;

        int turnCount;

        int rowCount;
        int colCount;

        string[,] boardState;

        public string[,] BoardState { get => boardState; set => boardState = value; }
        public int TurnCount { get => turnCount; set => turnCount = value; }
        public int Player2CaptureCount { get => player2CaptureCount; set => player2CaptureCount = value; }
        public int Player1CaptureCount { get => player1CaptureCount; set => player1CaptureCount = value; }
        public string Player2Name { get => player2Name; set => player2Name = value; }
        public string Player1Name { get => player1Name; set => player1Name = value; }
        public int RowCount { get => rowCount; set => rowCount = value; }
        public int ColCount { get => colCount; set => colCount = value; }
    }
}
