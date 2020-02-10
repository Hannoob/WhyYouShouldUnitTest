using System;

namespace BeautifulRestApi.Services
{
    public interface ITimeProvider
    {
        DateTime getCurrentTime();
    }
}