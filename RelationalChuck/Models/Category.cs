using System.Collections.Generic;

namespace RelationalChuck.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Jokes = new List<Joke>();
        }

        public int CategoryId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Joke> Jokes { get; set; }
    }
}
