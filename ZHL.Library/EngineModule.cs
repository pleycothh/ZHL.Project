using Autofac;
using ZHL.Library.Contracts;

namespace ZHL.Library
{
    public class EngineModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RunnerMain>().As<IRunnerMain>();
        }
    }// test 
}
