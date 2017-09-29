using MyBlog.Core;
using MyBlog.Entities;
using MyBlog.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Web.Extensions
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        #region Blog

        public static BlogViewModel ToModel(this Blog entity)
        {
            return entity.MapTo<Blog, BlogViewModel>();
        }

        public static Blog ToEntity(this BlogViewModel model)
        {
            return model.MapTo<BlogViewModel, Blog>();
        }

        public static Blog ToEntity(this BlogViewModel model, Blog destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Classify

        public static ClassifyViewModel ToModel(this Classify entity)
        {
            return entity.MapTo<Classify, ClassifyViewModel>();
        }

        public static Classify ToEntity(this ClassifyViewModel model)
        {
            return model.MapTo<ClassifyViewModel, Classify>();
        }

        public static Classify ToEntity(this ClassifyViewModel model, Classify destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Tags

        public static TagsViewModel ToModel(this Tags entity)
        {
            return entity.MapTo<Tags, TagsViewModel>();
        }

        public static Tags ToEntity(this TagsViewModel model)
        {
            return model.MapTo<TagsViewModel, Tags>();
        }

        public static Tags ToEntity(this TagsViewModel model, Tags destination)
        {
            return model.MapTo(destination);
        }

        #endregion
    }
}