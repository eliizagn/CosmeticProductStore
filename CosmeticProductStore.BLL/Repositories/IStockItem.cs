using CosmeticProductStore.DAL.Data.Models;
using CosmeticProductStore.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.BLL.Repositories;

public interface IStockItem
{
    void CreateStorewithProducts(CreateStockItem item);
    StockItem GetStockItem(int storeCode, int productId);
    void ChanginProductsinStore(ChangeStockItem change);
    string FindMinCost(int productid);
    List<StockItem> WhatCanIBuy(int storeCode, decimal budget);
    decimal BuyItemsInStore(BatchofProducts batch);
}
