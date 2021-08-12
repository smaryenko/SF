using System;
using System.Collections.Generic;

namespace SF.Models
{
    public class Holiday
    {
        public DateTime Date;
        public string LocalName;
        public string Name;
        public string CountryCode;
        public bool Fixed;
        public bool Global;
        public List<string> Counties;
        public int? LaunchYear;
        public List<string> Types;
    }
}
