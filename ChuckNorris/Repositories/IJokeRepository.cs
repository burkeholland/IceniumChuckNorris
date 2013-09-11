using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RelationalChuck.Models;

namespace ChuckNorris.Repositories
{
    public interface IJokeRepository
    {
        IEnumerable<JokeDto> GetAllJokes();
        JokeDto GetJoke(int id);
    }
}