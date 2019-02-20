using ShoesShop.BLL.Interfaces;
using ShoesShop.Repository;
using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.BLL
{
    public class SupplierBLL: ISupplierBLL
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SupplierRepository supplierRepository;

        public SupplierBLL(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            supplierRepository = new SupplierRepository(unitOfWork);
        }

        public List<tblSupplier> GetSupplierForMasterData()
        {
            return supplierRepository.GetAll(r => !r.IsDeleted).ToList();
        }
    }
}
