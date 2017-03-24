using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataIndia.Models;
namespace DataIndia.Repository
{
    public class DistrictRepository : DataRepository<District>,IDistrictRepository
    {
        public DistrictRepository(DataIndiaDbContext context) : base(context)
        {
        }

        public District GetDistrict(int id)
        {

            return DataIndiaDbContext.Districts.SingleOrDefault(d=>d.DistrictCode==id);
        }

        public IEnumerable<District> GetDistrictsByState(int id)
        {
            return this.GetAll().Where(d => d.StateId == id);
        }


        public DataIndiaDbContext DataIndiaDbContext
        {
            get { return Context as DataIndiaDbContext; }
        }
    }
}
