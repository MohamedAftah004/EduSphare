using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Common
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
