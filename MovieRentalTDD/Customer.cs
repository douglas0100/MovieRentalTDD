using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalTDD
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Rental> Rentals;

        public Customer(string name)
        {
            Name = name;
            Rentals = new List<Rental>();
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            IEnumerator<Rental> rentalsEnum = this.Rentals.GetEnumerator();
            string result = "Rental Record for " + Name + "\n";

            while (rentalsEnum.MoveNext())
            {
                double thisAmount = 0;
                Rental each = rentalsEnum.Current;

                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                        {
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        }
                        break;

                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;

                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                        {
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        }
                        break;
                }
                frequentRenterPoints++;
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE) && (each.DaysRented > 1))
                {
                    frequentRenterPoints++;
                }
                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }


        //Additional Method
        public string StatementRefactored()
        {
            int frequentRenterPoints = 0;
            double totalAmount = 0;

            IEnumerator<Rental> rentalsEnum = this.Rentals.GetEnumerator();
            string result = "Rental Record for " + Name + "\n";

            while (rentalsEnum.MoveNext())
            {
                Rental rental = rentalsEnum.Current;

                double thisAmount = rental.GetAmount();
                frequentRenterPoints += rental.GetFrenquentRenterPoints();

                result += "\t" + rental.Movie.Title + "\t" + thisAmount.ToString() + "\n";
                totalAmount += thisAmount;
            }

            result += "Amount owed is " + totalAmount.ToString() + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points";

            return result;
        }

        //Additional Method
        private static int GetFrenquentRenterPoints(Rental rental)
        {
            int frequentRenterPoints = 1;

            if ((rental.Movie.PriceCode == Movie.NEW_RELEASE) && (rental.DaysRented > 1))
            {
                frequentRenterPoints++;
            }

            return frequentRenterPoints;
        }

        //Additional Method
        private static double GetAmount(Rental rental)
        {
            double amount = 0;

            switch (rental.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    amount += 2;
                    if (rental.DaysRented > 2)
                    {
                        amount += (rental.DaysRented - 2) * 1.5;
                    }
                    break;

                case Movie.NEW_RELEASE:
                    amount += rental.DaysRented * 3;
                    break;

                case Movie.CHILDRENS:
                    amount += 1.5;
                    if (rental.DaysRented > 3)
                    {
                        amount += (rental.DaysRented - 3) * 1.5;
                    }
                    break;
            }

            return amount;
        }
    }
}
