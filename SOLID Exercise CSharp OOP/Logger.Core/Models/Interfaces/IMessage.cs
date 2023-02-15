

namespace Logger.Core.Models.Interfaces
{
    using Enums;
    public interface IMessage
    {
        public string MessageText { get; }
        public string DateTime { get; }
        public ReportLevel ReportLevel { get; }

    }
}
