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
            
            CreateMap<ProductModel, Product>();
            CreateMap<CategoryModel, Category>()
                                     .ForMember(dst => dst.Products,s=>s.MapFrom(src=>src.Products))
                                     .ForMember(dst => dst.CreatedBy, s => s.MapFrom(src => Guid.Parse("6E2B9DE4-B456-4263-A0F7-CE0432556726")))
                                     .ForMember(dst => dst.CreatedOn, s => s.MapFrom(src => DateTime.Now));
            CreateMap<SupplierModel, Supplier>()
                                     .ForMember(dst => dst.Id,s=>s.MapFrom(src=> CheckExistId(src.Id)))
                                     .ForMember(dst => dst.Products, s => s.MapFrom(src => src.Products))
                                     .ForMember(dst => dst.CreatedBy, s => s.MapFrom(src => Guid.Parse("6E2B9DE4-B456-4263-A0F7-CE0432556726")))
                                     .ForMember(dst => dst.CreatedOn, s => s.MapFrom(src => DateTime.Now))
                                     .ForMember(dst => dst.IsDeleted , s=>s.Ignore());
        }
        private Guid CheckExistId (Guid Id)
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
            return Id;  
        }
        
        private void ConfigureMapperforModel()
        {
            CreateMap<HistoryDetail, HistoryDetailModel>().ForMember(r => r.history, s => s.Ignore());
                                                        
            CreateMap<Product, ProductModel>();
            CreateMap<ProductInput, ProductModel>();
            CreateMap<History, HistoryModel>().ForMember(dst=>dst.DisplayName,s=>s.MapFrom(src=>src.Employee.DisplayName));
           
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