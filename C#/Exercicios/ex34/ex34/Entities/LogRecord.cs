using System;
using System.Collections.Generic;
using System.Text;

namespace ex34.Entities
{
    class LogRecord
    {
        public string? Username { get; set; }
        public DateTime Instant { get; set; }

        public override int GetHashCode()
        {
            return Username?.GetHashCode() ?? 0;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            LogRecord other = (LogRecord)obj;
            return Username?.Equals(other.Username) ?? other.Username == null; 
        }
}
}
