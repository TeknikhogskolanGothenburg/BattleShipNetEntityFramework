﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.Domain;

namespace BattleShip.TestConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            //AddAccount();
            //Login();
            //GetAccount();
            AddGame();
            //JoinGame();
            //GameKeyExist();
            //GetGame();
            //GetOpenGames();
            //GetAccountGames();
            //Shoot();
            //RemoveOldGames();
        }

        private static void AddAccount()
        {
            try
            {
                GameEngine.GameEngine.NewAccount("WrickedGamer", "Test123", "wrickedgamer@example.com");
                GameEngine.GameEngine.NewAccount("Chibi", "Test123", "chibi@example.com");

                Console.WriteLine("Accounts added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Login()
        {
            try
            {
                Account account = GameEngine.GameEngine.Login("WrickedGamer", "Test123");
                Console.WriteLine("Account " + account.UserName + " now logged in!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetAccount()
        {
            try
            {
                Account account = GameEngine.GameEngine.GetAccount(1);

                if (account != null)
                {
                    Console.WriteLine("Got account with username: " + account.UserName);
                }
                else
                {
                    Console.WriteLine("No user with that id!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddGame()
        {
            try
            {
                string gameKey = GameEngine.GameEngine.NewGame(1, false);
                Console.WriteLine("New game added with gamekey: " + gameKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void JoinGame()
        {
            try
            {
                GameEngine.GameEngine.JoinGame("1692c2", 2);
                Console.WriteLine("You have join game!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GameKeyExist()
        {
            try
            {
                bool result = GameEngine.GameEngine.GameKeyExist("23ed4e");

                if (result)
                {
                    Console.WriteLine("GameKey exist!");
                }
                else
                {
                    Console.WriteLine("GameKey doesn't exist!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetGame()
        {
            try
            {
                GameBoard game = GameEngine.GameEngine.GetGame("23ed4e");
                if (game != null)
                {
                    Console.WriteLine(String.Format("Game {0} started by {1}", game.Key, game.Players[0].Account.UserName));
                }
                else
                {
                    Console.WriteLine("GameBoard with this key doesn't exist!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetOpenGames()
        {
            try
            {
                List<GameBoard> games = GameEngine.GameEngine.GetOpenGames();

                Console.WriteLine("Existing open games:");

                foreach (GameBoard game in games)
                {
                    Console.WriteLine("\t" + game.Key + " started by " + game.Players[0].Account.UserName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetAccountGames()
        {
            try
            {
                List<GameBoard> games = GameEngine.GameEngine.GetAccountGames(1);

                Console.WriteLine("WrickedGamer's games:");

                foreach (GameBoard game in games)
                {
                    string activeText = (game.Active) ? "Active" : (game.Ended) ? "Game ended" : "Waiting for player";

                    Console.WriteLine(String.Format("\t{0} - {1}", game.Key, activeText));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Shoot()
        {
            try
            {
                bool result = GameEngine.GameEngine.Shoot(23, "23ed4e", 1, 1);

                Console.WriteLine("Shoot at position 1,1 on player 1 - Result:" + result.ToString());

                //bool result = GameEngine.GameEngine.Shoot(2, "23ed4e", 1, 1);

                //Console.WriteLine("Shoot at position 1,1 on player 2 - Result:" + result.ToString());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveOldGames()
        {
            try
            {
                GameEngine.GameEngine.RemoveOldGameBoards();

                Console.WriteLine("Removed old gameboards!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
