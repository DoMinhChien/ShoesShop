using ShoesShop.Model;
using ShoesShop.Mvc.Inputs;
using ShoesShop.Mvc.Outputs;
using ShoesShop.Repository;
using System;

namespace ShoesShop.Mvc.Infrastructure
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
            CreateMap<ProductModel, tblProduct>().ForMember(dst => dst.CreatedBy, s => s.MapFrom(src => Guid.Parse("6E2B9DE4-B456-4263-A0F7-CE0432556726")))
                                     .ForMember(dst => dst.CreatedOn, s => s.MapFrom(src => DateTime.Now))
                                     .ForMember(dst => dst.StatusId, s => s.MapFrom(src => 1))
                                     .ForMember(dst => dst.Id, s => s.MapFrom(src => Guid.NewGuid()));
        }
        private void ConfigureMapperforModel()
        {
            CreateMap<tblProduct, ProductModel>();
            CreateMap<ProductInput, ProductModel>();
        }
        private void ConfigureMapperforInput()
        {

        }
        private void ConfigureMapperforOutput()
        {
            CreateMap<ProductModel, ProductOutput>();
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