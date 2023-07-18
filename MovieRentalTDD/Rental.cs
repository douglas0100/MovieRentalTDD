using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalTDD
{
    public class Rental
    {
        public Movie Movie { get; set; }

        public int DaysRented { get; set; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        //Additional Method
        public double GetAmount()
        {
            return Movie.GetAmount(DaysRented);
        }

        //Additional Method
        public int GetFrenquentRenterPoints()
        {
            return Movie.GetFrenquentRenterPoints(DaysRented);
        }

    }
}
