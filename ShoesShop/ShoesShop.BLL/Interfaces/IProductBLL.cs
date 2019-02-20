using ShoesShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.BLL.Interfaces
{
  public  interface IProductBLL
    {
        List<ProductModel> GetListProduct();
        bool DeleteProduct(Guid productId);
        bool InsertProduct(ProductModel model);
        ProductModel GetProductDetail(Guid productId);
    }
}
