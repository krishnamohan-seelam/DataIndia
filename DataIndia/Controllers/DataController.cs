using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataIndia.Repository;
using Microsoft.Practices.Unity;
namespace DataIndia.Controllers
{
    public class DataController : Controller
    {
         IStateRepository _stateRepo;
         IDistrictRepository _districtRepo;
       

        // GET: Data
        public DataController() :this(null,null)
        {
            

        }

        public DataController(IStateRepository stateRepo, IDistrictRepository districtRepo)
        {
            _stateRepo = stateRepo ;
            _districtRepo = districtRepo;


        }

        

        public ActionResult GetStates()
        {

            var stateList = _stateRepo.GetAll().Select(s=>new {s.Id,s.Name}).ToList();



            return Json(stateList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDistricts(int id)
        {

            var stateList = _stateRepo.GetAll().Select(s => new { s.Id, s.Name }).ToList();



            return Json(stateList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDistrictsbyState(int id)
        {
            var districtList = _districtRepo.GetDistrictsByState(id).Select( d=> new { districtName =d.Name, districtState =d.State.Name});
            
            return Json(districtList, JsonRequestBehavior.AllowGet);
        }


    }
}