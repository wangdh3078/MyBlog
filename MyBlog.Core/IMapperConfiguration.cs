using AutoMapper;
using System;

namespace MyBlog.Core
{
    public interface IMapperConfiguration
    {
        Action<IMapperConfigurationExpression> GetConfiguration();

        int Order { get; }
    }
}
