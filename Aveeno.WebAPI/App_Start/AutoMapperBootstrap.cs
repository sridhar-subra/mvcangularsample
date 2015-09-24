using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Aveeno.WebAPI
{
    public class AutoMapperBootstrap
    {
        private AutoMapperBootstrap(){}
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new BusinessLibrary.MapperDalToBlPRofile());
                cfg.AddProfile(new MapperPlToBlProfile());
            }
            );
        }
    }
}