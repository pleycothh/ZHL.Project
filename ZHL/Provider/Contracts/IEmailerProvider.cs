using ZHL.Library.Models;

namespace ZHL.GUI.Provider.Contracts
{
    public interface IEmailerProvider
    {
        Task Sender(EmailClientModel emailClient);
    }
}