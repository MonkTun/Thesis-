using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour //this should be together with LevelManager
{
    public static ProgressManager Instance { get; set; }

    private bool[] progress = new bool[StageList.Stages.Length];
    public int wrongAnswers;
    public int correctAnswers;
    public int currentQuiz;
    public int accuracyPercent {
        get
        {
            float trials = wrongAnswers + correctAnswers;
            if (trials != 0)
                return (int)(correctAnswers / trials * 100);
            else return 0;
        }
    }
    public float progressPercent {
        get
        {
            float progressed = 0;

            for (int i = 0; i < StageList.Stages.Length; i++)
            {
                if (progress[i] == true) progressed++;
            }
            return progressed/(StageList.Stages.Length);
        }
    }

    public int currentStage { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (gameObject)
                Destroy(gameObject);
            return;
        }
        
        LoadProgress();
    }

    /// <summary>
    /// Set progress[] Success inclusive to current stage
    /// successStage starts from 0
    /// </summary>
    public void SaveProgress(int successStage)
    {
        //List<string> progress = new List<string>();

        bool[] progress = new bool[StageList.Stages.Length];
        
        for (int i = 0; i < StageList.Stages.Length; i++)
        {
            if (i <= successStage)
            {
                progress[i] = true;
            }
        }
        
        ES3.Save("progress", progress);
        ES3.Save("currentStage", successStage + 1);
        ES3.Save("correctAnswers", correctAnswers);
        ES3.Save("wrongAnswers", wrongAnswers);
        ES3.Save("currentQuiz", 0); //because we want to reset quiz everytime we load new stage
        currentQuiz = 0;
        
        this.progress = progress;
        currentStage = successStage + 1;
    }

    public void UpdateAccuracy(bool isWrong)
    {
        correctAnswers += isWrong ? 0 : 1;
        wrongAnswers += isWrong ? 1 : 0;
        ES3.Save("correctAnswers", correctAnswers);
        ES3.Save("wrongAnswers", wrongAnswers);
    }

    public void SetCurrentQuiz(int index)
    {
        currentQuiz = index;
        ES3.Save("currentQuiz", index);
    }
    
    public void LoadProgress()
    {
        progress = ES3.Load("progress", new bool[StageList.Stages.Length]);
        currentStage = ES3.Load("currentStage", 0);
        correctAnswers = ES3.Load("correctAnswers", 0);
        wrongAnswers = ES3.Load("wrongAnswers", 0);
        currentQuiz = ES3.Load("currentQuiz", 0);
    }

    public void ResetProgress()
    {
        progress = new bool[StageList.Stages.Length];
        currentStage = 0;
        correctAnswers = 0;
        wrongAnswers = 0;
        currentQuiz = 0;
        ES3.Save("progress", progress);
        ES3.Save("currentStage", currentStage);
        ES3.Save("correctAnswers", correctAnswers);
        ES3.Save("wrongAnswers", wrongAnswers);
        ES3.Save("currentQuiz", currentQuiz);
    }
}
