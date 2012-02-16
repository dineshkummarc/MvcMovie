using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quixote;


namespace Vidpub.AcceptanceTests {
    class Program {
        static void Main(string[] args) {
            Runner.SiteRoot = "http://localhost:61100/";
            TheFollowing.Describes("Home Page");

            It.Should("Have 'MVC Movie App' in the title", () =>
            {
                return Runner.Get("/").Title.ShouldContain("Index");
            });

            It.Should("fail Log in with incorrect credentials", () =>
            {
                var post = Runner.Post("/account/logon", new  { UserName = "a", Password = "a" });
                //Console.WriteLine(post.Body);
                //return post.Body.ShouldContain("Welcome");
                return post.Body.ShouldContain("Login was unsuccessful");
            });
             

            Console.Read();
        }
    }
}
