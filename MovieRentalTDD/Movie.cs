using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalTDD
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        public string Title { get; set; }

        public int PriceCode { get; set; }

        public Movie(String title, int priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }
    }
}
