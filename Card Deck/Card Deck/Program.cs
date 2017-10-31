using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Deck
{
    class Card
    {
        //string[] Number = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        string[] Number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };
        string[] Suit = { "Spades", "Hearts", "Clovers", "Diamonds" };
        List<string> FullDeck = new List<string>();
        // List<string> RemovedDeck = new List<string>();

        int Score = 0;

        int FirstDraw = 0;
        int SecondDraw = 0;

        Random random = new Random();
        public void Game()
        {           
            Console.WriteLine("1. Draw a card and start the game");
            Console.WriteLine("2. Show Deck");
            Console.WriteLine("3. Show Removed Cards");
            int choice1 = Int32.Parse(Console.ReadLine());
            switch (choice1)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Let the games begin! Your card is the ");
                    RandomDraw();
                    Console.WriteLine("Is the next card higher or lower???? (*o*) Only fate knows!!!!");
                    StartGame();
                    break;
                case 2:
                    Console.Clear();
                    PrintDeck();
                    break;
                case 3:
                    Console.Clear();
                   // PrintRemovedCards();
                    break;
            }
           
            Game();
            
        } //Start menue

        public void CreateDeck()
        {
            for(int i = 0; i < Suit.Length; i++)
            {
                for(int j = 0; j < Number.Length; j++)
                {
                    if (Number[j] == "1")
                    {
                        FullDeck.Add("Ace" + " of " + Suit[i]);
                    }
                    else if (Number[j] == "11")
                    {
                        FullDeck.Add("Jack" + " of " + Suit[i]);
                    }
                    else if (Number[j] == "12")
                    {
                        FullDeck.Add("Queen" + " of " + Suit[i]);
                    }
                    else if (Number[j] == "13")
                    {
                        FullDeck.Add("King" + " of " + Suit[i]);
                    }
                    else
                    {
                        FullDeck.Add(Number[j] + " of " + Suit[i]);
                    }
                }
            }
        } //Renaming suits

        public void PrintDeck()
        {            
            FullDeck.ForEach(Console.WriteLine);     
        }

     //   public void PrintRemovedCards()
       // {

        //    RemovedDeck.ForEach(Console.WriteLine);

            


       // }
        
        public void RandomDraw() //First Draw
        {
            Random draw = new Random();
            FirstDraw = draw.Next(FullDeck.Count);
            Console.WriteLine(FullDeck[FirstDraw]);
            // RemovedDeck.Add(FullDeck[FirstDraw]);
            FullDeck.Remove(FullDeck[FirstDraw]);            
        }

        public void RandomDraw2() //Second Draw
        {
            Random draw = new Random();
            SecondDraw = draw.Next(FullDeck.Count);
            Console.WriteLine(FullDeck[SecondDraw]);
            // RemovedDeck.Add(FullDeck[SecondDraw]);
            FullDeck.Remove(FullDeck[SecondDraw]);
        }

        public void StartGame()
        {
            RandomDraw2();
            Console.WriteLine("1. Higher");
            Console.WriteLine("2. Lower");
            int Userpick = Int32.Parse(Console.ReadLine());
            switch(Userpick)
            {
                case 1:
                    if (FirstDraw > SecondDraw)
                    {
                        Score++;
                        Console.WriteLine("You did it Will!");
                        Console.WriteLine("You'r new score is " + Score);
                        Console.WriteLine("Press enter to try again");
                        Console.ReadLine();
                        Console.Clear();
                        StartGame();
                    }
                    else if (FirstDraw == SecondDraw)
                    {
                        Console.WriteLine("They were the same! It's a draw");
                        Console.WriteLine("Press enter to try again");
                        Console.ReadLine();
                        Console.Clear();
                        StartGame();
                    }
                    else if (FirstDraw < SecondDraw)
                    {
                        Console.WriteLine("Nope! Womp womp :(");
                        Console.WriteLine("Press enter to try again");
                        Console.ReadLine();
                        Console.Clear();
                        StartGame();
                    }
                    break;
                case 2:
                    if (FirstDraw < SecondDraw)
                    {
                        Score++;
                        Console.WriteLine("You did it Will!");
                        Console.WriteLine("You'r new score is " + Score);
                        Console.WriteLine("Press enter to try again");
                        Console.ReadLine();
                        Console.Clear();
                        StartGame();
                    }
                    else if (FirstDraw == SecondDraw)
                    {
                        Console.WriteLine("They were the same! It's a draw");
                        Console.WriteLine("Press enter to try again");
                        Console.ReadLine();
                        Console.Clear();
                        StartGame();
                    }
                    else if (FirstDraw > SecondDraw)
                    {
                        Console.WriteLine("Nope! Womp womp :(");
                        Console.WriteLine("Press enter to try again");
                        Console.ReadLine();
                        Console.Clear();
                        StartGame();
                    }
                    break;
            }
        } //High low game

    }
    class Program
    {
        static void Main(string[] args)
        {
            Card deck = new Card();
            deck.CreateDeck();
            deck.Game();
            Console.Read();
        }        
    }
}
