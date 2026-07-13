using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;

namespace EduSphare.Domain.Users
{
    public sealed class Country : BaseEntity
    {
       public string Name{ get; private set; }

        private Country() { }
    }
}
