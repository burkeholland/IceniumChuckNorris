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
    public class CategoryController : ApiController
    {
        private readonly CategoryRepository _repository;
        public CategoryController()
        {
            _repository = new CategoryRepository();
        }

        // GET api/Category
        public HttpResponseMessage Get()
        {
            var items = _repository.GetAllCategories();
            return Request.CreateResponse<IEnumerable<CategoryDto>>(HttpStatusCode.OK, items);
        }

        // GET api/Category/5
        public HttpResponseMessage Get(int id)
        {
            var item = _repository.GetCategory(id);
            return Request.CreateResponse<CategoryDto>(HttpStatusCode.OK, item);
        }
    }
}
