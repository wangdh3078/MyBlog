using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MyBlog.Entities;
using MyBlog.Web.Areas.Admin.Models;
using MyBlog.Services;

namespace MyBlog.Web
{
    public class AdminMapperConfiguration : IMapperConfiguration
    {
        public AdminMapperConfiguration()
        {
        }
        public int Order => 0;

        public Action<IMapperConfigurationExpression> GetConfiguration()
        {
            Action<IMapperConfigurationExpression> action = cfg =>
            {
                //Blog
                cfg.CreateMap<BlogViewModel, Blog>()
                .ForMember(t=>t.CreateDate, mo => mo.Ignore());
                cfg.CreateMap<Blog, BlogViewModel>()
                 .ForMember(t => t.CreateDate, mo => mo.Ignore());

                //Classify
                cfg.CreateMap<ClassifyViewModel, Classify>()
                .ForMember(t => t.Blogs, mo => mo.Ignore());
                cfg.CreateMap<Classify, ClassifyViewModel>()
                 .ForMember(t => t.Blogs, mo => mo.Ignore());
                //Tags
                cfg.CreateMap<TagsViewModel, Tags>()
                 .ForMember(t => t.Blogs, mo => mo.Ignore());
                cfg.CreateMap<Tags, TagsViewModel>()
                 .ForMember(t => t.Blogs, mo => mo.Ignore());
            };
            return action;
        }
    }
}