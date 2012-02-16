using NUnit.Framework;
using MvcMovie.Models;

namespace Test.Specs {
    //A customer can buy access to a Production
    //A customer can buy a Subscription
    
    [TestFixture]
    public class MovieSpecs : TestBase
    { 
        dynamic _movies; 
        [SetUp]
        public void Init() {
            _movies = new Movies(); 
            //_movies.Delete();
            //Massive.DB.Current.Execute("DELETE FROM Customers_Productions");
            //_productions.Delete();
            //_customers.Delete();
        }



        [Test]
        public void a_movie_has_a_title()
        {
            var m = _movies.Insert(new { Title = "Test", Genre = "Drama", Price = 12.00, Rating = "G" });
             
            Assert.AreEqual("Test", m.Title);
        }

    }
}
