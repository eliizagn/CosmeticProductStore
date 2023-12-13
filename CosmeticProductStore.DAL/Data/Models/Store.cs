using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CosmeticProductStore.DAL.Data.Models;

public class Store
{
    public int StoreCode { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    [JsonIgnore]
    public ICollection<StockItem>? StockItems { get; set; }
}

