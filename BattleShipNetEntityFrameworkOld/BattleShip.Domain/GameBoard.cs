﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Domain
{
    public class GameBoard
    {
        public string GameKey { get; set; }
        public bool Private { get; set; }
        public int TurnPlayerId { get; set; }

        public List<Player> Players { get; set; }
        public Player TurnPlayer { get; set; }

        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// Properties to check if game is active - get
        /// </summary>
        public bool Active
        {
            get
            {
                return (Players.Count == 2);
            }
        }

        /// <summary>
        /// Properties for check if both player has seen end screen
        /// </summary>
        public bool BothPlayerHasSeenEndScreen
        {
            get
            {
                return (Players.ElementAt(0).HaveSeenEndScreen && Players.ElementAt(1).HaveSeenEndScreen);
            }
        }

        public GameBoard()
        {
            Players = new List<Player>();
            LastUpdate = new DateTime();
        }
    }
}