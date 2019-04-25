using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.Repository.Repo
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}
