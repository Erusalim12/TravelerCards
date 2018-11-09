using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TravelerCards;

namespace AppTesting
{
    [TestFixture]
    public class TravelerCardsTests
    {
        List<Card> NormalCards;
        List<Card> ErrorCards;

        [SetUp]
        public void Prepare()
        {
            NormalCards = new List<Card>
            {
               Card.Create("Москва", "Анапа"),
               Card.Create("Адлер", "Чита"),
               Card.Create("Чита", "Самара"),
               Card.Create("Анапа", "Адлер"),
               Card.Create("Самара", "Владивосток")          
            };

            ErrorCards = new List<Card>
            {
               Card.Create("Москва", "Анапа"),
               Card.Create("Адлер", "Чита"),
            //   Card.Create("Чита", "Самара"),
               Card.Create("Анапа", "Адлер"),
               Card.Create("Самара", "Владивосток")
            };
        }

        [Test]
        public void GetFirstCard_IsTrue()
        {
            var firstCard = Program.GetFirstCard(NormalCards);
            Assert.AreEqual(Card.Create("Москва", "Анапа").ToString(), firstCard.ToString());
        }

        //[Test]
        //public void GetFirstCardError_IsTrue()
        //{        
        //    Assert.That(() => Program.GetFristCard(ErrorCards), Throws.ArgumentException);
        //}


        [Test]

        public void ListIsCorrectSorting_IsTrue()
        {
            var sortedCards = Program.SortingCards(NormalCards);

            if (sortedCards != null && sortedCards.Count > 0)
            {
                var prevCard = sortedCards.FirstOrDefault();
                sortedCards.Remove(prevCard);

                while (sortedCards.Count > 0)
                {
                    Card nextCard = sortedCards.FirstOrDefault();
                    Assert.AreEqual(prevCard.InCity, nextCard.OutCity);
                    prevCard = nextCard;
                    sortedCards.Remove(prevCard);
                }
            }
        }
        [Test]
        public void SortingWithLoop_IsFalse()
        {
            NormalCards.Add(Card.Create("Адлер", "Владивосток"));

            var actual = Program.SortingCards(NormalCards);

            Assert.IsTrue(actual != null);
        }
    }
}
