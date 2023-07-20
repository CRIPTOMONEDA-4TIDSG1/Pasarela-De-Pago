using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.ArqLimpia.BL.DTOs;
using Crypto.ArqLimpia.EN.Interfaces;

namespace Crypto.ArqLimpia.DAL
{
    public class PucharseOrderDAL : IPucharseOrder
    {
        public void Create(IPucharseOrder pOrder)
        {
            throw new NotImplementedException();
        }

        public Task<IPucharseOrder> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IPucharseOrder>> Search(SearchOrderInputDTOs pOrder)
        {
            throw new NotImplementedException();
        }
    }
}
