using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using DctDomainModel;
using DctDomainModel.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DctApi.Controllers
{
	[Route("api/[controller]")]
    public class DctController : Controller
	{
		private readonly IDataAccessProvider _provider;

		public DctController(IDataAccessProvider provider)
		{
			this._provider = provider;
		}

        // GET: api/values
        [HttpGet]
        public IEnumerable<Dct> Get()
        {
	        return this._provider.GetDcts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Dct Get(int id)
        {
	        return this._provider.GetDct(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
