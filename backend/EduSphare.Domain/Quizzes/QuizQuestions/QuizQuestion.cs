using EduSphare.Domain.Common;
using EduSphare.Domain.Quizzes.QuizQuestion.ValueObjects;

namespace EduSphare.Domain.Quizzes.QuizQuestion
{
    public sealed class QuizQuestion : AuditableEntity
    {
        private readonly List<QuestionOption> _options = [];

        private QuizQuestion() { }

        public Guid QuizId { get; private set; }

        public int QuestionNumber { get; private set; }

        public QuestionText QuestionText { get; private set; }

        public QuestionType QuestionType { get; private set; }

        public IReadOnlyCollection<QuestionOption> Options
            => _options.AsReadOnly();


        #region Question Behaviors

        //create
        public static QuizQuestion Create(
            Guid quizId,
            int questionNumber,
            QuestionText questionText,
            QuestionType questionType)
        {
            return new QuizQuestion
            {
                QuizId = quizId,
                QuestionNumber = questionNumber,
                QuestionText = questionText,
                QuestionType = questionType
            };
        }

        //update
        public void Update(
            QuestionText questionText,
            QuestionType questionType)
        {
            QuestionText = questionText;
            QuestionType = questionType;

            SetUpdated();
        }

        //change number
        public void ChangeQuestionNumber(int questionNumber)
        {
            QuestionNumber = questionNumber;

            SetUpdated();
        }

        //change type
        public void ChangeQuestionType(QuestionType questionType)
        {
            QuestionType = questionType;

            SetUpdated();
        }

        #endregion

        #region Options BehaviorsS

        public void AddOption(QuestionOption option)
        {
            _options.Add(option);

            SetUpdated();
        }

        public void RemoveOption(Guid optionId)
        {
            var option = _options.FirstOrDefault(x => x.Id == optionId);

            if (option is null)
            {
                throw new InvalidOperationException("Option not found.");
            }

            _options.Remove(option);

            SetUpdated();
        }

        #endregion
    }
}