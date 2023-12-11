using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Travail
{
    class Deck
    {
        public Deck(string p_deckName, int p_cardNumber) 
        { 
            deckName = p_deckName;
            cardNumber = p_cardNumber;
        }

        public Carte SearchCard(Carte toFind)
        {
            for (int i = 0; i < myCardList.Count; i++)
            {
                if(toFind == myCardList[i])
                {
                    return myCardList[i];
                }

                else
                {
                    return null;
                }
            } 
            
            
        }
        private string deckName;
        private int cardNumber;

        public void RemoveCard(Carte p_card)
        {
            myCardList.Remove(p_card);
        }
        public void AddCard(Carte p_card)
        {
            if (myCardList.Count == cardNumber) 
            {
                return;
            }
            myCardList.Add(p_card);
        }

        public Carte DrawCard()
        {
            Carte temp;
            if (myCardList.Count != 0)
            {
                Carte temp = myCardList.Last();
                RemoveCard(temp);
                return temp;
            }
            else
            {
                return null;
            }
           

        }
        
        private List<Carte> myCardList = new List<Carte>();

    }

    class Carte
    {
        public Carte(string p_cardName)
        {
            cardName = p_cardName; 
        }
        private string cardName;

    }
    internal class Program
    {
        static void MinigameLetters(string myList)
        {
            Random rnd = new Random();
            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            bool playAgain = true; // NOT FOR NOW, WILL CREATE A SYSTEM THAT ASKS THE USER IF THEY WANT TO PLAY AGAIN
            int numberOfVictories = 0;


            while (numberOfVictories < 5 && playAgain == true)
            {
                string toFind = letters[rnd.Next(letters.Length)];


                Console.WriteLine("Type a small caps letter between 'a' and 'z'.");
                string userInput = Console.ReadLine();

                if (userInput == toFind)
                {
                    Console.WriteLine($"Your letter was {toFind}, and you found it ! Congrats !");
                    numberOfVictories++;
                }

                else
                {
                    Console.WriteLine($"The letter you had to find was {toFind}, but you lost, sorry...");

                }


                if (numberOfVictories == 5)
                {
                    Console.WriteLine("You found the letters 5 times, you're Awesome! Thank you for playing!");
                    Console.WriteLine("Push Enter button to exit");
                    Console.ReadKey();
                }

            }
        }

        static void Main(string[] args)
        {

            Deck myDeck = new Deck("Super Deck de fou", 60);
            Deck myDeck2 = new Deck("Deck pourri", 60);

            Carte myFirstCard = new Carte("Terrain Magique");
            Carte mySecondCard = new Carte("Dragon Magique");

            myDeck.AddCard(myFirstCard);
            myDeck.RemoveCard(myFirstCard);
            myDeck2.AddCard(mySecondCard);

            Carte? HandCard = myDeck.DrawCard();
        }
         
    }
}
