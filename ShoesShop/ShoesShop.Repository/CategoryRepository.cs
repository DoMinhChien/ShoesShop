using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.Repository
{
    public class CategoryRepository: BaseRepository<tblCategory>
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
