using ShoesShop.Model;
using System;
using System.Collections.Generic;

namespace ShoesShop.BLL.Interfaces
{
    public interface IHistoryBLL
    {
        void SaveHistory(ProductModel oldData, ProductModel newData, string content);
        List<HistoryModel> GetHistories(Guid objectId);
    }
}
