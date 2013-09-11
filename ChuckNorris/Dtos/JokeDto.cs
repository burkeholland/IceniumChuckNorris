using System.Collections.Generic;

namespace ChuckNorris.Repositories
{
    public class JokeDto
    {
        public int JokeId { get; set; }
        public string JokeText { get; set; }
        public virtual IList<CategoryDto> Categories { get; set; }
    }
}