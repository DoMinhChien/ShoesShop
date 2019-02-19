using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.Repository
{
    public class SupplierRepository: BaseRepository<tblSupplier>
    {
        public SupplierRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
