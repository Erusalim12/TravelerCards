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
            var sortedListOfCards = Sorting(new List<Card>
            {               
               Card.Create("Адлер", "Чита"),
               Card.Create("Москва", "Анапа"),
               Card.Create("Чита", "Самара"),
               Card.Create("Анапа", "Адлер"),
               Card.Create("Самара", "Владивосток")
            });
            foreach (var card in sortedListOfCards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.Read();
        }

        public static string GetFirstCardKey(List<Card> cards)=>
            cards.Select(x => x.OutCity).Except(cards.Select(c => c.InCity)).Single();

        public static Dictionary<string, Card> ConvertToDictionary(IEnumerable<Card> cards) => 
            cards.ToDictionary(c => c.OutCity, c => c);


        public static List<Card> Sorting(List<Card> cards)
        {
            try
            {
                var cardsDict = ConvertToDictionary(cards);
                var sortedList = new List<Card>(cards.Count());
                var firstCard = cardsDict[GetFirstCardKey(cards)];
                cards.Remove(firstCard);
                sortedList.Add(firstCard);

                while (cards.Count() > 0)
                {
                    sortedList.Add(cardsDict[sortedList.Last().InCity]);
                    cards.Remove(sortedList.Last());
                }

                return sortedList;
            }
            catch (ArgumentException)
            {
                throw new TravelellerCardSortingException("Ошибка, в наборе 2 или более карты не имеющие предшественников");
            }
            catch (InvalidOperationException)
            {
                throw new TravelellerCardSortingException("Ошибка, в наборе 2 или более карты не имеющие предшественников");
            }
        }

        
    }
    public class TravelellerCardSortingException : Exception
    {
        public TravelellerCardSortingException(string message)
            : base(message) { }
    }
}
