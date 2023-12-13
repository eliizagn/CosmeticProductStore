using CosmeticProductStore.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.BLL.Models
{
    public class BatchofProducts
    {
        public List<ProductQuantity> ProductQuantities { get; set; }
        public int StoreCode { get; set; }
    }
}

