using DataIndia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIndia.Repository
{
    public interface IDistrictRepository: IDataRepository<District>
    {
         District GetDistrict(int id);

         IEnumerable<District> GetDistrictsByState(int id);
    }
}
