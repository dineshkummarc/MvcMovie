using System;
using System.Dynamic;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcMovie.Models;

namespace UnitTest.Specs
{
    [TestClass]
    public class MovieSpecs
    {

        [TestMethod]
        public void a_movie_has_a_title()
        {
            dynamic movies = new Movies();
            var o1 = new {Title = "TestTitle", Genre = "TestingGenre", Price = 1.00, Rating = "TestingRating"};
            var m = movies.Insert(o1);
            Assert.AreEqual("TestTitle", m.Title);
        } 
    }
}
