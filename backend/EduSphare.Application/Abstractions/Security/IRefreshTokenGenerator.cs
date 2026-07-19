using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Application.Abstractions.Security
{
    public interface IRefreshTokenGenerator
    {
        string Generate();

    }
}
