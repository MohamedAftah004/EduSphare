using EduSphare.Domain.Common;
using EduSphare.Domain.Quizzes.QuizQuestion.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduSphare.Domain.Quizzes.QuizQuestion
{
    public sealed class QuestionOption : AuditableEntity
    {
        private QuestionOption()
        {
        }

        public Guid QuizQuestionId { get; private set; }

        public OptionText OptionText { get; private set; }

        public bool IsCorrect { get; private set; }

        // Create
        public static QuestionOption Create(
            Guid quizQuestionId,
            OptionText optionText,
            bool isCorrect)
        {
            return new QuestionOption
            {
                QuizQuestionId = quizQuestionId,
                OptionText = optionText,
                IsCorrect = isCorrect
            };
        }

        // Update text
        public void UpdateText(OptionText optionText)
        {
            OptionText = optionText;

            SetUpdated();
        }

        // Mark as correct
        public void MarkAsCorrect()
        {
            IsCorrect = true;

            SetUpdated();
        }

        // Mark as incorrect
        public void MarkAsIncorrect()
        {
            IsCorrect = false;

            SetUpdated();
        }
    }
}
