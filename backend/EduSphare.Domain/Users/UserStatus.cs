using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Users
{
    public enum UserStatus
    {
        PendingEmailVerification = 1,
        Active = 2,
        Suspended = 3 ,
        Deleted = 4
    }
}
