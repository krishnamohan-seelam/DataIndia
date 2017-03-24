using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataIndia.Models;
namespace DataIndia.Repository
{
    public class StateRepository : DataRepository<State>, IStateRepository
    {
        public StateRepository(DataIndiaDbContext context) : base(context)
        {
        }

        public State GetState(int id)
        {
            
                return DataIndiaDbContext.States.SingleOrDefault(s => s.Id == id);
            
        }

        public DataIndiaDbContext DataIndiaDbContext
        {
            get { return Context as DataIndiaDbContext; }
        }
    }
}
