using EduSphare.Domain.Common;
using EduSphare.Domain.Common.ValueObjects;
using EduSphare.Domain.Courses.Categories;
using EduSphare.Domain.Courses.Modules;
using EduSphare.Domain.Courses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Courses
{
    public sealed class Course : AggregateRoot
    {
        
        private Course() { }
        
        public CourseTitle Title { get; private set; }
        public CourseDescription Description { get; private set; }
        public ImageUrl ThumbnailImageUrl { get; private set; }
        public Money Price { get; private set; }
        public int LanguageId { get; private set; }
        public Guid InstructorId { get; private set; }
        public int? CourseLevel { get; private set; }
        public int CourseCategoryId { get; private set; }
        public CourseStatus Status { get; private set; }
        public Slug Slug { get; private set; }


        private readonly List<Module> _modules = [];
        public IReadOnlyCollection<Module> Modules => _modules.AsReadOnly();


        private readonly List<CourseCategory> _categories = [];
        public IReadOnlyCollection<CourseCategory> Categories
            => _categories.AsReadOnly();


        #region Behaviors
        // create course
        public static Course Create(
            CourseTitle title,
            CourseDescription description,
            ImageUrl thumbnailImageUrl,
            Money price,
            int languageId,
            Guid instructorId,
            int? courseLevel,
            Slug slug)
        {
            return new Course
            {
                Title = title,
                Description = description,
                ThumbnailImageUrl = thumbnailImageUrl,
                Price = price,
                LanguageId = languageId,
                InstructorId = instructorId,
                CourseLevel = courseLevel,
                Slug = slug,
                Status = CourseStatus.Draft
            };
        }

        // update course details
        public void UpdateDetails(
            CourseTitle title,
            CourseDescription description,
            int languageId,
            int? courseLevel)
        {
            Title = title;
            Description = description;
            LanguageId = languageId;
            CourseLevel = courseLevel;

            SetUpdated();
        }

        // change thumbnail
        public void ChangeThumbnail(ImageUrl thumbnailImageUrl)
        {
            ThumbnailImageUrl = thumbnailImageUrl;

            SetUpdated();
        }

        // change price
        public void ChangePrice(Money price)
        {
            Price = price;

            SetUpdated();
        }

        // publish course
        public void Publish()
        {
            if (Status != CourseStatus.Draft)
            {
                throw new InvalidOperationException(
                    "Only draft courses can be published.");
            }

            if (!_modules.Any())
            {
                throw new InvalidOperationException(
                    "Course must contain at least one module.");
            }

            if (!_modules.SelectMany(x => x.Lessons).Any())
            {
                throw new InvalidOperationException(
                    "Course must contain at least one lesson.");
            }

            Status = CourseStatus.Published;

            SetUpdated();
        }

        //unpublish course
        public void UnPublish()
        {
            if (Status != CourseStatus.Published)
            {
                throw new InvalidOperationException(
                    "Only published courses can be unpublished.");
            }

            Status = CourseStatus.Draft;

            SetUpdated();
        }

        //archive course
        public void Archive()
        {
            if (Status != CourseStatus.Published)
            {
                throw new InvalidOperationException(
                    "Only published courses can be archived.");
            }

            Status = CourseStatus.Archived;

            SetUpdated();
        }

        #endregion



        #region Module Behaviors

        public void AddModule(Module module)
        {
            if(_modules.Any(x => x.Id == module.Id))
            {
                throw new InvalidOperationException(
                    "Module already exists.");
            }

            _modules.Add(module);

            SetUpdated();
        }

        public void RemoveModule(Guid moduleId)
        {
            var module = _modules.FirstOrDefault(x => x.Id == moduleId);

            if (module is null)
            {
                throw new InvalidOperationException(
                    "Module not found.");
            }

            _modules.Remove(module);

            SetUpdated();
        }

        #endregion


        #region Category Behaviors

        public void AddCategory(Guid categoryId)
        {
            if (_categories.Any(x => x.CategoryId == categoryId))
            {
                throw new InvalidOperationException(
                    "Category already exists.");
            }

            _categories.Add(
                CourseCategory.Create(Id, categoryId));

            SetUpdated();
        }

        public void RemoveCategory(Guid categoryId)
        {
            var category = _categories
                .FirstOrDefault(x => x.CategoryId == categoryId);

            if (category is null)
            {
                throw new InvalidOperationException(
                    "Category not found.");
            }

            _categories.Remove(category);

            SetUpdated();
        }

        #endregion


    }
}
