using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GachaSystem
{
    public class System
    {
        public List <BaseUser> Users;

        public string VersionNumber { get; set; }
        public int VersionCode { get; set; }
        public DateTime LastUpdatedDate { get; set; }

    }
}