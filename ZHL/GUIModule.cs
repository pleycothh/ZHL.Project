
using Autofac;
using ZHL.Library;


namespace ZHL.GUI
{
    public class GUIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<EngineModule>();
        }
    }
}
