using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using NoOneImportsChuckNorris.Dto;
using RelationalChuck.Models;
using Newtonsoft.Json;

namespace NoOneImportsChuckNorris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Only Chuck Norris can download Chuck Norris...stand by");
            var walker = new WalkerTexasRanger("http://api.icndb.com/jokes/");
            var converter = new ChuckConverter();
            var mia = new MissingInSqlAction();
            walker.GetChuck((results) => converter.ConvertAndThen(results, (cats, jokes) =>
            {
                mia.PersistChuck(cats, jokes);
                Console.WriteLine("Persisted {0} Categories and {1} Jokes.", cats.Count(), jokes.Count());
                Console.WriteLine("We're done here. Click Enter to Exit.");
            }));
            Console.ReadLine();
        }
    }

    public class WalkerTexasRanger
    {
        private readonly string _url;

        public WalkerTexasRanger(string url)
        {
            _url = url;
        }

        public async void GetChuck(Action<IList<JokeDto>> action)
        {
            var client = new HttpClient();
            var resp = await client.GetStringAsync(_url);
            var results = JsonConvert.DeserializeObject<JokeResults>(resp);
            action(results.value);
        }
    }

    public class MissingInSqlAction
    {
        public void PersistChuck(IList<Category> categories, IList<Joke> jokes)
        {
            using (var db = new ChuckNorrisContext())
            {
                jokes.ToList().ForEach(joke => db.Jokes.Add(joke));
                db.SaveChanges();
            }
        }
    }

    public class ChuckConverter
    {
        public void ConvertAndThen(IList<JokeDto> jokeDtos, Action<IList<Category>, IList<Joke>> action)
        {
            var cats = GetCategoriesFromDtos(jokeDtos);
            var jokes = GetJokesFromDtos(jokeDtos, cats);
            action(cats, jokes);
        }

        public IList<Category> GetCategoriesFromDtos(IList<JokeDto> jokeDtos)
        {
            var idx = 0;
            return jokeDtos.SelectMany(x => x.categories).Distinct().Select(x => new Category()
            {
                Description = x, CategoryId = idx++ // OH THE HUMANITY!
            }).ToList();
        }

        public IList<Joke> GetJokesFromDtos(IList<JokeDto> jokeDtos, IList<Category> categories)
        {
            return jokeDtos.Select(joke => new Joke()
            {
                JokeId = joke.id,
                JokeText = joke.joke,
                Categories = categories.Where(x => joke.categories.Contains(x.Description)).ToList()
            }).ToList();
        }
    }
}
