using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerCards
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        private static IEnumerable<Card> SortingCards(IEnumerable<Card> cards)
        {

            var firstCard = cards.Select(x => x.NextCity).Except(cards.Select(c => c.NextCity)).Single();
               // string start = list.Except(toarr).Single();

        }

        private static Dictionary<string,Card> ConvertToDictionary(IEnumerable<Card> cards)=> cards.ToDictionary(c => c.CurrentCity, c => c);

        private static Card GetFirstCard(IEnumerable<Card> cards)
        {
            var dict = ConvertToDictionary(card);

            

        }
    }
}
