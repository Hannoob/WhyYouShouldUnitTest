using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautifulRestApi.Services
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime getCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
