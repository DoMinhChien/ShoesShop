using ShoesShop.BLL.Interfaces;
using ShoesShop.Core.Extensions;
using ShoesShop.Model;
using ShoesShop.Model.History;
using ShoesShop.Repository;
using ShoesShop.Repository.Infrastructure;
using ShoesShop.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoesShop.BLL
{
    public class HistoryBLL : BaseHistoryBLL<Model.HistoryDetailModel>, IHistoryBLL
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoryRepository _categoryRepository;
        private readonly SupplierRepository _supplierRepository;
        private readonly HistoryRepository _historyRepository;

        public HistoryBLL(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
            _supplierRepository = new SupplierRepository(_unitOfWork);
            _historyRepository = new HistoryRepository(_unitOfWork);
            _categoryRepository = new CategoryRepository(_unitOfWork);
        }
        public void SaveHistory(ProductModel oldData, ProductModel newData, string content)
        {
            var history = new History
            {
                Content = content,
                ObjectId = oldData.Id
            };
            if (oldData != null)
            {
                var listCategory = _categoryRepository.GetAll(r => !r.IsDeleted).ToList().Select(r => new SelectedItemModel { Id = r.Id, Name = r.Name }).ToList();
                var listSupplier = _supplierRepository.GetAll(r => !r.IsDeleted).ToList().Select(r => new SelectedItemModel { Id = r.Id, Name = r.Name }).ToList();
                var oldItem = ConvertToProductHistoryDetailModel(oldData, listCategory, listSupplier);
                var newItem = ConvertToProductHistoryDetailModel(newData, listCategory, listSupplier);
                TrackingHistory(history, oldItem, newItem);
                _historyRepository.Insert(history);
                _unitOfWork.SaveChanges();

            }

        }
        private string BindingCategory(int categoryId, List<SelectedItemModel> list)
        {
            return list.FirstOrDefault(r => r.Id == categoryId)?.Name;
        }
        private string BindingSupllier(Guid suplliedId, List<SelectedItemModel> list)
        {
            return list.FirstOrDefault(r => r.Id == suplliedId)?.Name;
        }
        private string BindingStatus(bool isActive)
        {
            return isActive ? "Active" : "Inactive";
        }
        private ProductHistoryDetailModel ConvertToProductHistoryDetailModel(ProductModel model
                                                                             , List<SelectedItemModel> listCategory
                                                                             , List<SelectedItemModel> listSupplier)
        {
            var result = new ProductHistoryDetailModel();
            result.Name = model.Name;
            result.Description = model.Description;
            //result.Quantity = model.Quantity;
            result.UnitPrice = model.UnitPrice;
            result.UnitsInStock = model.UnitsInStock;
            result.CategoryName = BindingCategory(model.CategoryId, listCategory);
            result.StatusName = BindingStatus(model.IsActive);
            result.SupplierName = BindingSupllier(model.SupplierId, listSupplier);
            return result;
        }
        private void TrackingHistory(History history, ProductHistoryDetailModel oldData, ProductHistoryDetailModel newData)
        {
            var compare = CompareObject<ProductHistoryDetailModel>(oldData, newData);
            foreach (var item in compare)
            {
                history.HistoryDetails.Add(new HistoryDetail
                {
                    Field = item.Field,
                    OldValue = item.OldValue,
                    NewValue = item.NewValue,
                    CreatedOn = DateTime.UtcNow
                });
            }

        }
        public List<HistoryModel> GetHistories(Guid objectId)
        {
            var list = _historyRepository.GetAll().ToList();
            var result = list.MapTo<List<HistoryModel>>();
            return result;
        }

    }
}
