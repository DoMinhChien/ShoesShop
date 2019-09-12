using ShoesShop.BLL;
using ShoesShop.BLL.Interfaces;
using ShoesShop.Repository.Infrastructure;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ShoesShop.Mvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployeeBLL, EmployeeBLL>();
            container.RegisterType<IProductBLL, ProductBLL>();
            container.RegisterType<IHistoryBLL, HistoryBLL>();
            container.RegisterType<ICategoryBLL, CategoryBLL>();
            container.RegisterType<ISupplierBLL, SupplierBLL>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}