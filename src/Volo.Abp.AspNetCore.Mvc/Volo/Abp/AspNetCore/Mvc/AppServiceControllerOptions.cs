﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Volo.Abp.Http.Modeling;

namespace Volo.Abp.AspNetCore.Mvc
{
    public class AppServiceControllerOptions
    {
        public ControllerAssemblySettingList ControllerAssemblySettings { get; }

        public List<Type> FormBodyBindingIgnoredTypes { get; }
        
        public List<IUrlActionNameNormalizer> UrlActionNameNormalizers { get; }

        public AppServiceControllerOptions()
        {
            ControllerAssemblySettings = new ControllerAssemblySettingList();

            FormBodyBindingIgnoredTypes = new List<Type>
            {
                typeof(IFormFile)
            };

            UrlActionNameNormalizers = new List<IUrlActionNameNormalizer>
            {
                new DefaultUrlActionNameNormalizer()
            };
        }

        public AbpControllerAssemblySettingBuilder CreateFor(Assembly assembly, string rootPath = ModuleApiDescriptionModel.DefaultRootPath)
        {
            var setting = new AbpControllerAssemblySetting(assembly, rootPath);
            ControllerAssemblySettings.Add(setting);
            return new AbpControllerAssemblySettingBuilder(setting);
        }
    }
}