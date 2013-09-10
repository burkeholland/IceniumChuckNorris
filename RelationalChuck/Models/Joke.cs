using System.Collections.Generic;

namespace RelationalChuck.Models
{
    public partial class Joke
    {
        public Joke()
        {
            this.Categories = new List<Category>();
        }

        public int JokeId { get; set; }
        public string JokeText { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
