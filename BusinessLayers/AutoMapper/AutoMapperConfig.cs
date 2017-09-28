using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayers.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            global::AutoMapper.Mapper.Initialize(x =>
            {
              x.AddProfile<DomainToViewModelMappingProfile>();
              x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
