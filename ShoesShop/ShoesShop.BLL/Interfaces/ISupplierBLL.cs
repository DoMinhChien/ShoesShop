using ShoesShop.Model;
using ShoesShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.BLL.Interfaces
{
    public interface ISupplierBLL
    {
        List<Supplier> GetSupplierForMasterData();
        bool DeleteSupplier(Guid SupplierId);
        SupplierModel GetSupplierDetail(Guid Id);
        bool UpdateSupplier(SupplierModel model);
        bool InsertSupplier(SupplierModel model);
        List<SupplierModel> GetSuppliers();
    }
}
