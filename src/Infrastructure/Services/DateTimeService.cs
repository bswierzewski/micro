using micro_api.Application.Common.Interfaces;
using System;

namespace micro_api.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
