using CosmeticProductStore.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.BLL.Models;

public class CheckStockItems
{
    public string StoreName { get; set; }
    public CreateStore Store { get; set; }

    public string ProductName { get; set; }
    public CreateProduct Product { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }

}
