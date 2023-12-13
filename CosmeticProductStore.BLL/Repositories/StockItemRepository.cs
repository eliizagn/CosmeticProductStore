using CosmeticProductStore.BLL.Models;
using CosmeticProductStore.DAL.Data.Models;
using CosmeticProductStore.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticProductStore.BLL.Repositories
{
    public class StockItemRepository : IStockItem
    {
        private readonly StoreDbContext _dbContext;

        public StockItemRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateStorewithProducts(CreateStockItem item)
        {
            var itemEntity = new StockItem();
            itemEntity.StoreCode = item.StoreCode;
            itemEntity.ProductId = item.ProductId;
            itemEntity.Quantity = item.Quantity;
            itemEntity.Price = item.Price;

            _dbContext.StockItems.Add(itemEntity);
            _dbContext.SaveChanges();
        }

        public StockItem GetStockItem(int storeCode, int productId)
        {
            return _dbContext.StockItems
                .Include(x => x.Store)
                .Include(x => x.Product)
                .FirstOrDefault(s => s.StoreCode == storeCode);
        }

        public string? FindMinCost(int productid)
        {
            decimal minPrice = decimal.MaxValue;
            string cheapestStore = null;
            var stockItems = _dbContext.StockItems.Include(x => x.Store);

            foreach (var storeProduct in stockItems)
            {
                if (storeProduct.ProductId == productid)
                {
                    if (storeProduct.Quantity > 0 && (storeProduct.Price < minPrice))
                    {
                        minPrice = storeProduct.Price;
                        cheapestStore = storeProduct.Store.Name; 
                    }
                }
            }

            return cheapestStore;
        }
        

        public void ChanginProductsinStore(ChangeStockItem change)
        {
            var stockItem = _dbContext.StockItems.FirstOrDefault(si => si.StoreCode == change.StoreCode && si.ProductId == change.ProductId);

            if (stockItem != null)
            {
                stockItem.Quantity = change.Quantity;
                stockItem.Price = change.Price;

                _dbContext.SaveChanges();
            }
        }

        public List<StockItem> WhatCanIBuy(int storeCode, decimal budget)
        {
            var affordableProducts = new List<StockItem>();

            var storeProducts = _dbContext.StockItems
                .Where(si => si.StoreCode == storeCode && si.Quantity > 0)
                .Include(si => si.Product)
                .Include(si => si.Store)
                .ToList();

            foreach (var stockItem in storeProducts)
            {
                int quantityAffordable = (int)(budget / stockItem.Price);

                if (quantityAffordable > 0)
                {
                    var affordableItem = new StockItem
                    {
                        StoreCode = storeCode,
                        Store = stockItem.Store,
                        ProductId = stockItem.ProductId,
                        Product = stockItem.Product,
                        Quantity = quantityAffordable,
                        Price = stockItem.Price
                    };
                    affordableProducts.Add(affordableItem);
                }
            }

            return affordableProducts;
        }

        public decimal BuyItemsInStore(BatchofProducts batch)
        {
            var list = batch.ProductQuantities;
            decimal resultCost = 0;

            foreach (ProductQuantity item in list) {
                var stockItem = _dbContext.StockItems.FirstOrDefault(x => 
                    x.StoreCode == batch.StoreCode &&
                    x.Quantity >= item.Quantity &&
                    x.ProductId == item.ProductID);
                if (stockItem == null)
                {
                    throw new Exception("Произошла ошибка при подсчете!");
                }
                resultCost += stockItem.Price*stockItem.Quantity;
               
            }

            return resultCost;
        }
    }
}
