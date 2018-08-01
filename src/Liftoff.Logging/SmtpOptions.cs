using System.Collections.Generic;

namespace Liftoff.Logging
{
    public class SmtpOptions
    {
        public string ComputerName { get; set; }
        public string Host { get; set; }
        public string From { get; set; }
        public ICollection<string> Recipients { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string Source { get; set; }
    }
}
