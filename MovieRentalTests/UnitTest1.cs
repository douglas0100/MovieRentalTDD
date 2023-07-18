using MovieRentalTDD;

namespace MovieRentalTests
{
    [TestClass]
    public class UnitTest1
    {
        private Customer client;

        [TestInitialize]
        public void SetUp()
        {
            client = new Customer("John");
        }

        [TestMethod]
        public void TestNameCreation()
        {
            string result = client.Statement();
            Assert.IsTrue(result.Contains("Rental Record for John"));
        }

        [TestMethod]
        public void TestOneRegularOneDay()
        {
            RentMovie("Indiana Jones", Movie.REGULAR, 1);
            string result = client.Statement();
            Assert.IsTrue(result.Contains("Amount owed is 2"));
            Assert.IsTrue(result.Contains("You earned 1 frequent renter points"));
        }

        [TestMethod]
        public void TestOneRegularThreeDays()
        {
            RentMovie("Indiana Jones", Movie.REGULAR, 3);
            string result = client.Statement();
            Assert.IsTrue(result.Contains("Amount owed is 3,5"));
            Assert.IsTrue(result.Contains("You earned 1 frequent renter points"));
        }

        [TestMethod]
        public void TestOneChildrensFiveDays()
        {
            RentMovie("Procurando Nemo", Movie.CHILDRENS, 5);
            string result = client.Statement();
            Assert.IsTrue(result.Contains("Amount owed is 4,5"));
            Assert.IsTrue(result.Contains("You earned 1 frequent renter points"));
        }

        [TestMethod]
        public void TestOneNewReleaseOneDay()
        {
            RentMovie("Vingadores", Movie.NEW_RELEASE, 1);
            string result = client.Statement();
            Assert.IsTrue(result.Contains("Amount owed is 3"));
            Assert.IsTrue(result.Contains("You earned 1 frequent renter points"));
        }

        private void RentMovie(string title, int type, int days)
        {
            Movie movie = new Movie(title, type);
            Rental rental = new Rental(movie, days);
            client.Rentals.Add(rental);
        }

    }
}