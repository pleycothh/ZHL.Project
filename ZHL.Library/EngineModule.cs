using Autofac;
using ZHL.Library.Contracts;
using ZHL.Library.Keras;

namespace ZHL.Library
{
    public class EngineModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RunnerMain>().As<IRunnerMain>();
            builder.RegisterType<LinearRegression>().As<ILinearRegression>();

        }
    }// test 
}
