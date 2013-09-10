using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoOneImportsChuckNorris.Dto
{
    public class JokeResults
    {
        public string type { get; set; }
        public IList<JokeDto> value { get; set; } 
    }

    public class JokeDto
    {
        public int id { get; set; }
        public string joke { get; set; }
        public IList<string> categories { get; set; } 
    }
}
