using Autofac;
using ZHL.Library.Contracts;
using ZHL.Library.Keras;
using ZHL.Library.NLP;

namespace ZHL.Library
{
    public class EngineModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            /// Main Model
            builder.RegisterType<RunnerMain>().As<IRunnerMain>();

            /// Speech recognition Model
            builder.RegisterType<LinearRegression>().As<ILinearRegression>();


            /// NLP Model
            builder.RegisterType<Hello>().As<IRegexIntro>();
            builder.RegisterType<Name>().As<IRegexIntro>();
            builder.RegisterType<IDK>().As<IRegexIntro>();
            
        }
    }// test 
}
