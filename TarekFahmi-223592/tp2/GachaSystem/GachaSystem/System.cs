using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GachaSystem
{
    public class System
    {
        public Version SystemVersion;
        private List<BaseUser> users;

        [Serializable]
        internal class NotImplementedException : Exception
        {
            public NotImplementedException()
            {
            }

            public NotImplementedException(string message) : base(message)
            {
            }

            public NotImplementedException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected NotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}