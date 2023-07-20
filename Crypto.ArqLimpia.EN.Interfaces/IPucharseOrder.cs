using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto.ArqLimpia.EN;
using Crypto.ArqLimpia.BL.DTOs;

namespace Crypto.ArqLimpia.EN.Interfaces
{
    public  interface PucharseOrder
    {
        void Create(PucharseOrder pOrder);
        Task<PucharseOrder> GetById(int id);
        Task<List<PucharseOrder>> Search(SearchOrderInputDTOs pOrder);


    }
}
