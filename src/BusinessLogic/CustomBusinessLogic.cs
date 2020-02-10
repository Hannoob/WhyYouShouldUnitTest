using BeautifulRestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautifulRestApi.BusinessLogic
{
    public class CustomBusinessLogic
    {
        private readonly ITimeProvider _timeProvider;
        public CustomBusinessLogic(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public CustomBusinessLogic() : this(new TimeProvider())
        {
        }

        public string GreetBasedOnTime(string name)
        {
            var hour = _timeProvider.getCurrentTime().Hour;
            if (hour > 12)
                return $"Good afternoon {name}.";
            return $"Good morning {name}.";
        }


    


    }
}
