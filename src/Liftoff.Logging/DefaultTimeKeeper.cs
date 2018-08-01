using System;

namespace Liftoff.Logging
{
    public interface IKeepTime
    {
        DateTime Now();
    }

    public class DefaultTimeKeeper : IKeepTime
    {
        private static readonly Lazy<IKeepTime> InternalInstance = new Lazy<IKeepTime>(() => new DefaultTimeKeeper());
        public static IKeepTime Instance => InternalInstance.Value;

        private DefaultTimeKeeper()
        {
        }

        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
