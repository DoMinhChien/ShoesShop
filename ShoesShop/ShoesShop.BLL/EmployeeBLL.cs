using ShoesShop.BLL.Interfaces;
using ShoesShop.Core.Extensions;
using ShoesShop.Model;
using ShoesShop.Model.FilterModel;
using ShoesShop.Repository;
using ShoesShop.Repository.Infrastructure;
using ShoesShop.Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesShop.BLL
{
    public class EmployeeBLL : IEmployeeBLL
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeBLL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = new EmployeeRepository(_unitOfWork);
        }
        public List<EmployeeModel> GetListEmployee(EmployeeFilterModel filterModel)
        {

            var list = _employeeRepository.GetAll(r => !r.IsDeleted).OrderByDescending(c => c.CreatedOn).ToList();
            var result = list.MapTo<List<EmployeeModel>>();
            return result;
        }
        public bool DeleteEmployee(Guid Id)
        {
            bool result = false;
            var entity = _employeeRepository.GetById(Id);
            if (entity != null)
            {
                result = _employeeRepository.SoftDelete(entity);
            }
            _employeeRepository.Update(entity);
            _unitOfWork.SaveChanges();

            return result;
        }
        public EmployeeModel GetEmployeeDetail(Guid productId)
        {
            var entity = _employeeRepository.GetById(productId);
            var model = entity.MapTo<EmployeeModel>();
            return model;
        }
        public bool InsertEmployee(EmployeeModel model)
        {
            var entity = new Employee();
            entity = model.MapTo<Employee>();

            _employeeRepository.Insert(entity);
            _unitOfWork.SaveChanges();
            return true;

        }
        public bool UpdateEmployee(EmployeeModel employeeModel)
        {

            var entity = _employeeRepository.GetById(employeeModel.Id);

            var oldEntity = entity.MapTo<EmployeeModel>();

            entity.DisplayName = employeeModel.DisplayName;
            entity.Address = employeeModel.Address;
            entity.Email = employeeModel.FirstName;
            entity.HireDate = employeeModel.HireDate;
            entity.Phone = employeeModel.Phone;
            //_historyBLL.SaveHistory(oldEntity, productModel, "Has updated this Employee");
            _employeeRepository.Update(entity);
            _unitOfWork.SaveChanges();
            return true;

        }
    }
}
