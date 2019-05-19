using PagedList;
using ShoesShop.Model;
using ShoesShop.Model.FilterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.BLL.Interfaces
{
  public  interface IProductBLL
    {
        List<ProductModel> GetListProduct(ProductFilterModel filterModel);
        bool DeleteProduct(Guid productId);
        bool InsertProduct(ProductModel model);
        ProductModel GetProductDetail(Guid productId);
        bool UpdateProduct(ProductModel productModel);
    }
}
