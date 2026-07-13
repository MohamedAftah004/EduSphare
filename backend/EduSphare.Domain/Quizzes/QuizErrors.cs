using EduSphare.Domain.Common;

namespace EduSphare.Domain.Quizzes;

public static class QuizErrors
{
    public static readonly Error NotFound =
        new(
            "Quiz.NotFound",
            "Quiz was not found.");

    public static readonly Error QuestionNotFound =
        new(
            "Quiz.QuestionNotFound",
            "Question was not found.");

    public static readonly Error OptionNotFound =
        new(
            "Quiz.OptionNotFound",
            "Question option was not found.");

    public static readonly Error QuestionAlreadyExists =
        new(
            "Quiz.QuestionAlreadyExists",
            "Question already exists.");

    public static readonly Error InvalidQuestionType =
        new(
            "Quiz.InvalidQuestionType",
            "Question type is invalid.");
}