using EduSphare.Domain.Common;
using EduSphare.Domain.Courses.ValueObjects;
using EduSphare.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Courses.Categories
{
    public sealed class Category  : BaseEntity
    {
        private Category(){}

        public CategoryName CategoryName { get; private set; }


        public static Category Create(CategoryName name)
        {
            return new Category
            {
                CategoryName = name
            };
        }

        public void Rename(CategoryName name)
        {
            CategoryName = name;
        }
    }
}
