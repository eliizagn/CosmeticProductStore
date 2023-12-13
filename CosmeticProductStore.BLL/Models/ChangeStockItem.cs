using CosmeticProductStore.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.BLL.Models;

public class ChangeStockItem
{
    public int StoreCode { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}