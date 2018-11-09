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
        private readonly string _outCity;
        private readonly string _inCity;

        private Card(string outCity, string inCity)
        {
            _outCity = outCity;
            _inCity = inCity;
        }

        public string CurrentCity { get => _outCity;}
        public string NextCity { get => _inCity;}

        
        public static Card Create(string outCity, string inCity)
        {
            return new Card(outCity, inCity);
        }
        public override string ToString()
        {
            return $"Departure city: {_outCity} \t Destination city:{_inCity}";
        }


    }
}
