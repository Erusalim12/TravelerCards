using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerCards
{
    public class Card
    {
        private Card(string outCity, string inCity)
        {
            OutCity = outCity;
            InCity = inCity;
        }
        /// <summary>
        /// Город отправления
        /// </summary>
        public string OutCity { get; private set; }

        /// <summary>
        /// Город прибытия
        /// </summary>
        public string InCity {  get; private set; }

        public static Card Create(string outCity, string inCity)
        {
            return new Card(outCity, inCity);
        }
        //public override string ToString()
        //{
        //    return $"Departure city: {_outCity} \t Destination city:{_inCity}";
        //}


    }
}
