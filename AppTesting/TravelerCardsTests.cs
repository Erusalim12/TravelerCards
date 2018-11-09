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
        public void SetUp()
        {
            //набор карт, из которых можно построить маршрут
            NormalCards = new List<Card>
            {
               Card.Create("Москва", "Анапа"),
               Card.Create("Адлер", "Чита"),
               Card.Create("Чита", "Самара"),
               Card.Create("Анапа", "Адлер"),
               Card.Create("Самара", "Владивосток")
            };

            //набор карт с ошибкой
            ErrorCards = new List<Card>
            {
               Card.Create("Москва", "Анапа"),
               Card.Create("Адлер", "Чита"),
               Card.Create("Анапа", "Адлер"),
               Card.Create("Самара", "Владивосток")
            };
        }




        [Test]
        public void Sorting_NormalList_Successful()
        {
            // Arrange
            var sortedCards = Program.Sorting(NormalCards);

            // Act
            if (sortedCards != null && sortedCards.Count > 0)
            {
                var prevCard = sortedCards.FirstOrDefault();
                sortedCards.Remove(prevCard);

                // Assert
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
        public void Sorting_ListWithError_ExceptionHandling()
        {   
            try
            {
                var sortedCards = Program.Sorting(ErrorCards);
            }
            catch (TravelellerCardSortingException e)
            {
                Assert.Pass(e.Message + e.InnerException);
            }
            Assert.Fail();

        }
       

    }
}
