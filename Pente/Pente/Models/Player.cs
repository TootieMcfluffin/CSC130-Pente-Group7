using Pente.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Pente.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Captures { get; set; }
        public char pieceChar { get; set; }
        public bool hasWon { get; set; }
        public Player(PlayerOrderEnum playerEnum)
        {
            if(playerEnum == PlayerOrderEnum.PLAYER1)
            {
                Name = "Player1";
                pieceChar = 'Y';
            } 
            else if(playerEnum == PlayerOrderEnum.PLAYER2)
            {
                Name = "Player2";
                pieceChar = 'X';
            } 
            else
            {
                throw new NullReferenceException("Player needs an Enum");
            }
        }
        public Player(string name, PlayerOrderEnum playerEnum)
        {
            this.Name = name;
            if (playerEnum == PlayerOrderEnum.PLAYER1)
            {
                pieceChar = 'Y';
            }
            else if (playerEnum == PlayerOrderEnum.PLAYER2)
            {
                pieceChar = 'X';
            }
            else
            {
                throw new NullReferenceException("Player needs an Enum");
            }
        }

    }
}
