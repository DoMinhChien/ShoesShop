using ShoesShop.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.Repository.Repo
{
    public class HistoryRepository : BaseRepository<History>
    {
        public HistoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
