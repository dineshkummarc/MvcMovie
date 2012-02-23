using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace MvcMovie.App.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MovieService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public List<Movie> GetMovies()
        {
            // Add your operation implementation here
            var l = new List<Movie>();
            l.Add(new Movie { Title = "aasfd", Rating = "asdf" });
            l.Add(new Movie { Title = "dsfaf", Rating = "asdfa" });
            return l;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
