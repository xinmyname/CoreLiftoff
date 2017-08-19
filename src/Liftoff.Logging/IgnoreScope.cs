using System;

namespace Liftoff.Logging
{
    internal class IgnoreScope : IDisposable
    {
        public static readonly IgnoreScope Instance = new IgnoreScope();

        private IgnoreScope()
        {
        }

        public void Dispose()
        {
        }
    }
}
