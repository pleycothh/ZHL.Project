using Autofac;
using ZHL.Library.Contracts;
using ZHL.Library.Plugin.RegexPlugin;

namespace ZHL.Library
{
    public class EngineModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            /// Main Model
            builder.RegisterType<RunnerMain>().As<IRunnerMain>();

            /// Word2Vec


            /// Regex Model
            builder.RegisterType<ExactMatch>().As<IRegexIntro>();
        //    builder.RegisterType<LooseMatchTwo>().As<IRegexIntro>();
         //   builder.RegisterType<LoosMatchOne>().As<IRegexIntro>();
            
        }
    }// test 
}
