using AutoMapper;
using System;
using System.Linq.Expressions;

namespace ShoesShop.Core.Extensions
{
    public static class MapperExtension
    {
        public static TDest MapTo<TDest>(this object src) where TDest : class
        {
            return (TDest)AutoMapper.Mapper.Map(src, src.GetType(), typeof(TDest));
        }
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
    this IMappingExpression<TSource, TDestination> map,
    Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }

}