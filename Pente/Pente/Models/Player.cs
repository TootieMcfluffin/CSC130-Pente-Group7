using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pente.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Captures { get; set; }
        public char pieceChar { get; set; }
        public bool hasWon { get; set; }
        public Player()
        {

        }
        public Player(string name)
        {

        }
    }
}
