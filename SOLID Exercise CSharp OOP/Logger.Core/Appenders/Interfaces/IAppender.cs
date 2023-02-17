

namespace Logger.Core.Appenders.Interfaces
{
    using Formating.Layouts.Interfaces;
    using Models.Interfaces;
    public interface IAppender
    {
        ILayout layout { get; }

        void AppendMessage(IMessage message);
    }
}
