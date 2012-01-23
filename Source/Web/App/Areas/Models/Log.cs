using Massive;

namespace MvcMovie.Models
{
    public class Log : DynamicModel
    {
        public Log() : base("ApplicationConnectionString", "Log", "ID")
        {
        }
    }

    public class LogModel
    {
        

    }


}