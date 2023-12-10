using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.DAL.Data.Models;

public class StockItem
{
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int StoreCode { get; set; }
    public Store Store { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
