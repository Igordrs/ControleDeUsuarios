using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Projeto.Services.Mappings
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg => {

                cfg.AddProfile<EntityToViewModel>();
                cfg.AddProfile<ViewModelToEntity>();
            });
        }
    }

}