using Autofac;
using Reqnroll.Autofac;
using Reqnroll.Autofac.ReqnrollPlugin;
using ReqnrollProject1.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Support
{
    public static class GlobalHooks
    {
        
        [GlobalDependencies]
        public static void CreateGlobalContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterInstance(new GlobalScopedData { Data = "Data" });
        }

        [ScenarioDependencies]
        public static void CreateContainerBuilder(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterAssemblyTypes(typeof(CalculatorStepDefinitions).Assembly)
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))
                .SingleInstance();
        }
    }
}
