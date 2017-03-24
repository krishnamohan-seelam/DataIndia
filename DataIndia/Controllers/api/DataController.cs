using DataIndia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataIndia.Controllers.api
{
    public class DataController : ApiController
    {
        IStateRepository _stateRepo;
        IDistrictRepository _districtRepo;

        public DataController() : this(null, null)
        {


        }
        public DataController(IStateRepository stateRepo, IDistrictRepository districtRepo)
        {
            _stateRepo = stateRepo;
            _districtRepo = districtRepo;


        }

        // GET api/<controller>
        [Route("api/states")]
        [HttpGet]
        public  IHttpActionResult GetStates()
        {
            var statesList = _stateRepo.GetAll().Select(s => new { s.Id, s.Name }).ToList();

            if (statesList == null) return NotFound();
            
            return Ok(statesList);
        }

        // GET api/<controller>/5
        [Route("api/districts/{stateId}")]
        public IHttpActionResult GetDistrictsByState(int stateId)
        {
            var districtList = _districtRepo.GetDistrictsByState(stateId).Select(d => new { districtName = d.Name, districtState = d.State.Name });
            if (districtList == null) return NotFound();

            return Ok(districtList);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}