using System;

namespace Liftoff.Logging {

    public interface IKeepTime {
        DateTime Now();
    }

    public class DefaultTimeKeeper : IKeepTime {
        
        public static readonly DefaultTimeKeeper Instance = new DefaultTimeKeeper();

        private DefaultTimeKeeper() {
        }

        public DateTime Now() {
            return DateTime.Now;
        }

    }
}
