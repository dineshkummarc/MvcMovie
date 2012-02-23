﻿using System;
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
            dynamic o = new ExpandoObject();
            o.Title = "TestTitle"; 
            o.Genre = "TestingGenre";
            o.Price = "1.00";
            o.Rating = "R"; 


            
            var m = movies.Insert(o);
            Assert.AreEqual("TestTitle", m.Title);
            // clean up record

            movies.Execute("Delete From Movies where Title =@0 and Genre=@1 and Price=@2 and Rating=@3  ", o.Title, o.Genre, o.Price, o.Rating);

            //this.Execute("UPDATE Customers SET HighriseID=@0 WHERE ID=@1", newPerson["id"], item.ID);



            /*
            var sql = @"
            IF NOT EXISTS(Select CustomerID FROM Customers_Productions WHERE CustomerID=@0 AND ProductionID=@1) 
                BEGIN               
                    INSERT INTO Customers_Productions (CustomerID, ProductionID) VALUES (@0, @1)
                END";
            DB.Current.Execute(sql, customer.ID, production.ID);*/
        } 
    }
}
