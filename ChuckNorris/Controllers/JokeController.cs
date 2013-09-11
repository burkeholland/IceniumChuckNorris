using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChuckNorris.Repositories;
using RelationalChuck.Models;

namespace ChuckNorris.Controllers
{
    public class JokeController : ApiController
    {
        private readonly JokeRepository _repository;

        public JokeController()
        {
            _repository = new JokeRepository();
        }

        // GET api/joke
        public HttpResponseMessage Get()
        {
            var items = _repository.GetAllJokes();
            return Request.CreateResponse<IEnumerable<JokeDto>>(HttpStatusCode.OK, items);
        }

        // GET api/joke/5
        public HttpResponseMessage Get(int id)
        {
            var item = _repository.GetJoke(id);
            return Request.CreateResponse<JokeDto>(HttpStatusCode.OK, item);
        }
    }
}