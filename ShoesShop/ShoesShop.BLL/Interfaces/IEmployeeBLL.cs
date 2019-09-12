using ShoesShop.Model;
using ShoesShop.Model.FilterModel;
using System;
using System.Collections.Generic;

namespace ShoesShop.BLL.Interfaces
{
    public interface IEmployeeBLL
    {
        List<EmployeeModel> GetListEmployee(EmployeeFilterModel filterModel);
        bool DeleteEmployee(Guid productId);
        bool InsertEmployee(EmployeeModel model);
        EmployeeModel GetEmployeeDetail(Guid productId);
        bool UpdateEmployee(EmployeeModel productModel);
    }
}
