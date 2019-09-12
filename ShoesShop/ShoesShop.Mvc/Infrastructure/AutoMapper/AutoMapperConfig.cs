using ShoesShop.Model;
using ShoesShop.Mvc.Inputs;
using ShoesShop.Mvc.Outputs;
using ShoesShop.Repository;
using System;

namespace ShoesShop.Core.Extensions
{
    public class AutoMapperConfig : AutoMapper.Profile
    {
        // Config automatically mapping between 2 objects
        public AutoMapperConfig()
        {
            ConfigureMapperforEntity();
            ConfigureMapperforModel();
            ConfigureMapperforInput();
            ConfigureMapperforOutput();
        }
        private void ConfigureMapperforEntity()
        {
            CreateMap<EmployeeModel, Employee>();
            CreateMap<ProductModel, Product>();
            CreateMap<CategoryModel, Category>()
                                     .ForMember(dst => dst.Products,s=>s.MapFrom(src=>src.Products))
                                     .ForMember(dst => dst.CreatedBy, s => s.MapFrom(src => Guid.Parse("6E2B9DE4-B456-4263-A0F7-CE0432556726")))
                                     .ForMember(dst => dst.CreatedOn, s => s.MapFrom(src => DateTime.Now));
            CreateMap<SupplierModel, Supplier>()
                                     .ForMember(dst => dst.Products, s => s.MapFrom(src => src.Products))
                                     .ForMember(dst => dst.CreatedBy, s => s.MapFrom(src => Guid.Parse("6E2B9DE4-B456-4263-A0F7-CE0432556726")))
                                     .ForMember(dst => dst.IsDeleted , s=>s.Ignore())
                                     .ForMember(dst => dst.CreatedOn , s=>s.Ignore())
                                     .ForMember(dst => dst.ModifiedOn, s => s.Ignore());
        }
        
        private void ConfigureMapperforModel()
        {
            CreateMap<HistoryDetail, HistoryDetailModel>().ForMember(r => r.history, s => s.Ignore());
            CreateMap<Employee, EmployeeModel>().ForMember(dst=>dst.DepartmentName,s=>s.MapFrom(src=>src.Department.DepartmentName));                           
            CreateMap<Product, ProductModel>();
            CreateMap<ProductInput, ProductModel>();
            CreateMap<History, HistoryModel>().ForMember(dst=>dst.HistoryDetails,s=>s.MapFrom(src=>src.HistoryDetails))
                                              .ForMember(dst=>dst.Employee,s=>s.MapFrom(src=>src.Employee));
           
            CreateMap<Category, CategoryModel>().ForMember(dst=>dst.Products,s=>s.MapFrom(src=>src.Products));
            CreateMap<Supplier, SupplierModel>().ForMember(dst => dst.Products, s => s.MapFrom(src => src.Products));

            CreateMap<CategoryInput, CategoryModel>();
            CreateMap<SupplierInput, SupplierModel>();

        }
        private void ConfigureMapperforInput()
        {

        }
        private void ConfigureMapperforOutput()
        {
            CreateMap<EmployeeModel, EmployeeOutput>();
            CreateMap<SupplierModel, SupplierOutput>();
            CreateMap<HistoryModel, HistoryOutput>();
            CreateMap<ProductModel, ProductOutput>();
            CreateMap<CategoryModel, CategoryOutput>()
                .ForMember(dst => dst.Products, s => s.MapFrom(src => src.Products));

        }
        public static void RegisterMapping()
        {
            AutoMapper.Mapper.Initialize(r => { r.AddProfile<AutoMapperConfig>(); });
        }

    }
    public static class ExtensionMethod
    {

        public static string Encrypt(this Int32 num)
        {

            return "Technotips:" + num;
        }
    }
}