using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeamLab.Koala.Web.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BeamLab.Koala.Web.Controllers
{
    [Route("api/[controller]")]
    public class KoalaAPIController : Controller
    {
        private IRepository _repository;

        public KoalaAPIController(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returns items.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        [ApiExplorerSettings(GroupName = "v1")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ApiExplorerSettings(GroupName = "v1")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ApiExplorerSettings(GroupName = "v1")]
        public void Post([FromBody]string value)
        {
        }
    }
}
