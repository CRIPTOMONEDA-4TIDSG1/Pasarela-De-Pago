using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.ArqLimpia.EN
{
    internal class PurchaseOrder
    {
        public int Id { get; set; }

        public DateTime DateOrder { get; set; }

        public string HeadLine { get; set; }

        public int SubTotal { get; set; }

        public int Total { get; set; }
    }
}
