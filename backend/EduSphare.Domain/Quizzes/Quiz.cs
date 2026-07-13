using System;
using System.Collections.Generic;
using System.Text;
using EduSphare.Domain.Common;
using EduSphare.Domain.Quizzes.QuizQuestion;
using EduSphare.Domain.Quizzes.ValueObjects;

namespace EduSphare.Domain.Quizs
{
    public sealed class Quiz : AggregateRoot
    {
        private Quiz(){}


       public Guid LessonId { get; private set; }
       public QuizTitle Title { get; private set; }


       private readonly List<QuizQuestion> _questions = [];

       public IReadOnlyCollection<QuizQuestion> Questions
           => _questions.AsReadOnly();



        #region Quiz Behaviors

        //create
        public static Quiz Create(Guid lessonId, QuizTitle title)
        {
            var quiz = new Quiz
            {
                LessonId = lessonId,
                Title = title
            };
            return quiz;
        }

       //change title 
       public void ChangeTitle(QuizTitle title)
        {
            Title = title;
            SetUpdated();
        }

        #endregion




        #region Question Behaviors

        public void AddQuestion(QuizQuestion question)
        {
            if (_questions.Any(x => x.Id == question.Id))
            {
                throw new InvalidOperationException(
                    "Question already exists.");
            }

            _questions.Add(question);

            SetUpdated();
        }

        public void RemoveQuestion(Guid questionId)
        {
            var question = _questions.FirstOrDefault(x => x.Id == questionId);

            if (question is null)
            {
                throw new InvalidOperationException(
                    "Question not found.");
            }

            _questions.Remove(question);

            SetUpdated();
        }


        #endregion

    }
}
