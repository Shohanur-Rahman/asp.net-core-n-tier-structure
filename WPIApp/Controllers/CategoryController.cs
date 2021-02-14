using ServiceManager.IManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPIApp.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBlogManager _blogManager;
        public CategoryController(IBlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var responses = _blogManager.GetCategories();
            return new JsonResult(responses);
        }
    }
}
