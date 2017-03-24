using DataIndia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataIndia.Repository;

namespace DataIndia.Repository
{
    public interface IStateRepository : IDataRepository<State>
    {
        State GetState(int id);
    }
}
