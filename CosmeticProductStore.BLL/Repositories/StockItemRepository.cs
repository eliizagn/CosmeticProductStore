using CosmeticProductStore.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.BLL.Repositories;

public class StockItemRepository : IStockItem 
{
    private readonly StoreDbContext _dbContext;

    public StockItemRepository(StoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

}
