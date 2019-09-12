using ShoesShop.BLL.Interfaces;
using ShoesShop.Repository;
using ShoesShop.Repository.Repo;
using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoesShop.Model;
using ShoesShop.Core.Extensions;

namespace ShoesShop.BLL
{
    public class SupplierBLL: ISupplierBLL
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SupplierRepository _supplierRepository;

        public SupplierBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _supplierRepository = new SupplierRepository(_unitOfWork);
        }

        public List<SupplierModel> GetSuppliers()
        {
            var list = _supplierRepository.GetAll().Where(r => !r.IsDeleted).ToList();
            var result = list.MapTo<List<SupplierModel>>();
            return result;
        }
        public SupplierModel GetSupplierDetail(Guid Id)
        {
            var entity = _supplierRepository.GetById(Id);
            var model = entity.MapTo<SupplierModel>();
            return model;
        }

        public bool InsertSupplier(SupplierModel model)
        {
            var result = false;
            if (model != null)
            {
                var entity = new Supplier();
                entity = model.MapTo<Supplier>();

                _supplierRepository.Insert(entity);
                _unitOfWork.SaveChanges();
                result = true;
            }
            

            return result;
        }
        public bool UpdateSupplier(SupplierModel model)
        {
            bool result = false;
            var entity = _supplierRepository.GetById(model.Id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Address = model.Address;
                entity.Phone = model.Phone;
                entity.Country = model.Country;
                entity.IsActive = model.IsActive;    
                _supplierRepository.Update(entity);
                _unitOfWork.SaveChanges();
                result = true;
            }
            return result;
        }
        
        public bool DeleteSupplier(Guid SupplierId)
        {
            var entity = _supplierRepository.GetById(SupplierId);
            bool result = false;
            if (entity != null)
            {
             result =   _supplierRepository.SoftDelete(entity);
            }
            _unitOfWork.SaveChanges();
            return result;
        }
        public List<Supplier> GetSupplierForMasterData()
        {
            return _supplierRepository.GetAll(r => !r.IsDeleted).ToList();
        }
    }
}
