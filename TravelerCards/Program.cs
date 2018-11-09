using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerCards
{
   public class Program
    {
        static void Main(string[] args)
        {

        }
        public static Card GetFirstCard(List<Card> cards)
        {
            try
            {
                var cardsDict = ConvertToDictionary(cards);
            var firstCardKey = cards.Select(x => x.OutCity).Except(cards.Select(c => c.InCity)).Single();
          return cardsDict[firstCardKey];
            }
            catch (InvalidOperationException)
            {
                throw new TravelellerCardSortingException("Ошибка, в наборе 2 или более карты, которые могут выступать как начало набора");
            }
        }

        public static List<Card> SortingCards(List<Card> cards)
        {
            try
            {
                var cardsDict = ConvertToDictionary(cards);

            var sortedList = new List<Card>(cards.Count());
            
                var firstCard = GetFirstCard(cards);
                cards.Remove(firstCard);
                sortedList.Add(firstCard);         

            while (cards.Count() > 0)
                {
                    sortedList.Add(cardsDict[sortedList.Last().InCity]);
                    cards.Remove(sortedList.Last());
                }

            return sortedList;
            }
            catch (ArgumentException) {
                throw new TravelellerCardSortingException("Ошибка, в наборе 2 или более карты, которые могут выступать как начало набора");
            }
        }

        public static Dictionary<string, Card> ConvertToDictionary(IEnumerable<Card> cards) => cards.ToDictionary(c => c.OutCity, c => c);
   
                 

    }
    public class TravelellerCardSortingException: Exception
    {
        public TravelellerCardSortingException(string message)
            : base(message){}
    }
}
