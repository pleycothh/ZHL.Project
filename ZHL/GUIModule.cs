using Autofac;
using ZHL.Library;
using ZHL.GUI.Provider;
using ZHL.GUI.Provider.Contracts;

namespace ZHL.GUI
{
    public class GUIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<EngineModule>();

            builder.RegisterType<FilterListProvider>().As<IFilterListProvider>();
            builder.RegisterType<ItemProvider>().As<IItemProvider>();
         //   builder.RegisterType<EmailerProvider> ().As<IEmailerProvider>();
        }
    }
}
