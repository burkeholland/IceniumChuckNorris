using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ChuckNorris.Repositories;
using RelationalChuck.Models;

namespace ChuckNorris.Controllers
{
    public class CategoryJokesController : ApiController
    {
        private readonly JokeRepository _repository;
        public CategoryJokesController()
        {
            _repository = new JokeRepository();
        }

        // GET api/Category
        public HttpResponseMessage Get(int id)
        {
            var items = _repository.GetJokesByCategory(id);
            return Request.CreateResponse<IEnumerable<JokeDto>>(HttpStatusCode.OK, items);
        }
    }
}
