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
        List<Card> Cards;

        [SetUp]
        private void SetUp()
        {
            Cards = new List<Card>
            {
               Card.Create("Москва", "Анапа"),
               Card.Create("Адлер", "Чита"),
               Card.Create("Чита", "Самара"),
               Card.Create("Анапа", "Адлер"),
               Card.Create("Самара", "Владивосток")
            };
        }


        [TestCase("Москва", "Стамбул")]
        [TestCase("Ярославль", "Анапа")]
        [Test]
        public void CanCreateCard_isCreated(string outCity, string inCity)
        {
            var card = Card.Create(outCity, inCity);
            Assert.IsNotNull(card, "object not created");
        }


        [Test]
        public void CanSortCard_IsTrue()
        {
         Cards.

        }
    }
}
