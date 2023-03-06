public class Stage
{
    public string[] resources;
    public Quiz[] quizzes;
    public string tips;

    public Stage(string[] resources, Quiz[] quizzes, string tips)
    {
        this.resources = resources;
        this.quizzes = quizzes;
        this.tips = tips;
    }
}

public class Quiz
{
    public string question;
    public string[] answerChoices;
    public int correctAnswerChoice;

    public Quiz(string question, string[] answerChoices, int correctAnswerChoice)
    {
        this.question = question;
        this.answerChoices = answerChoices;
        this.correctAnswerChoice = correctAnswerChoice;
    }
}