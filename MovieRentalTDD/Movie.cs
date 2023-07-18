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

        // Additional Method
        public double GetAmount(int daysRented)
        {
            double amount = 0;

            switch (PriceCode)
            {
                case Movie.REGULAR:
                    amount += 2;
                    if (daysRented > 2)
                    {
                        amount += (daysRented - 2) * 1.5;
                    }
                    break;

                case Movie.NEW_RELEASE:
                    amount += daysRented * 3;
                    break;

                case Movie.CHILDRENS:
                    amount += 1.5;
                    if (daysRented > 3)
                    {
                        amount += (daysRented - 3) * 1.5;
                    }
                    break;
            }

            return amount;
        }

        // Additional Method
        public int GetFrenquentRenterPoints(int daysRented)
        {
            int frequentRenterPoints = 1;

            if ((PriceCode == NEW_RELEASE) && (daysRented > 1))
            {
                frequentRenterPoints++;
            }

            return frequentRenterPoints;
        }

    }
}
