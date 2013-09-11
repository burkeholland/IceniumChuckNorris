using System.Collections.Generic;
using System.Linq;
using RelationalChuck.Models;

namespace ChuckNorris.Repositories
{
    public class JokeRepository : IJokeRepository
    {
        public IEnumerable<JokeDto> GetAllJokes()
        {
            var jokes = new List<JokeDto>();
            using (var db = new ChuckNorrisContext())
            {
                jokes.AddRange(
                    db.Jokes.ToList().Select(x => new JokeDto()
                    {
                        JokeId = x.JokeId, 
                        JokeText = x.JokeText, 
                        Categories = x.Categories.Select(y => new CategoryDto()
                        {
                            CategoryId = y.CategoryId, 
                            Description = y.Description
                        }).ToList()
                    })
                );
            }
            return jokes;
        }

        public JokeDto GetJoke(int id)
        {
            JokeDto joke;
            using (var db = new ChuckNorrisContext())
            {
                var result = db.Jokes.First(x => x.JokeId == id);
                joke = new JokeDto()
                {
                    JokeId = result.JokeId, 
                    JokeText = result.JokeText, 
                    Categories = result.Categories.Select(x => new CategoryDto()
                    {
                        CategoryId = x.CategoryId, 
                        Description = x.Description
                    }).ToList()
                };
            }
            return joke;
        }

        public IEnumerable<JokeDto> GetJokesByCategory(int id)
        {
            var jokes = new List<JokeDto>();
            using (var db = new ChuckNorrisContext())
            {
                jokes.AddRange(
                    db.Jokes.ToList()
                        .Where(x => x.Categories.Select(s => s.CategoryId).Contains(id))
                        .Select(j => new JokeDto()
                        {
                            JokeId = j.JokeId,
                            JokeText = j.JokeText,
                            Categories = j.Categories.Select(y => new CategoryDto()
                            {
                                CategoryId = y.CategoryId,
                                Description = y.Description
                            }).ToList()
                        })
                );
            }
            return jokes;
        }
    }
}