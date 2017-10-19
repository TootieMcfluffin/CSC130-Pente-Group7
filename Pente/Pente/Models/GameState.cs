using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.Models
{
    [Serializable]
    struct GameState
    {
        string player1Name;
        string player2Name;

        int player1CaptureCount;
        int player2CaptureCount;

        int turnCount;

        string[][] boardState;
    }
}
