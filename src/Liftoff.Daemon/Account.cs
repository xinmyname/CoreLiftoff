using System;

namespace Liftoff.Daemon {
    
    internal class Account { 

        public string UserName { get; set; }
        public string Password { get; set; }

        public Account(string userName, string password) {
            UserName = userName;
            Password = password;
        }

        protected Account() {
        }
    }

#if DAEMON_PLATFORM_WINDOWS
    internal class WindowsAccount : Account {

        private static readonly Lazy<Account> _localSystem = new Lazy<Account>(() => new WindowsAccount());
        private static readonly Lazy<Account> _localService = new Lazy<Account>(() => new WindowsAccount());
        private static readonly Lazy<Account> _networkService = new Lazy<Account>(() => new WindowsAccount());

        public static Account LocalSystem { get { return _localSystem.Value; }}
        public static Account LocalService { get { return _localService.Value; }}
        public static Account NetworkService { get { return _networkService.Value; }}
    }
#endif    
}
