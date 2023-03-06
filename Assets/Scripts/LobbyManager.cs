using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] canvasPanels;
    [SerializeField] private ScrollRect[] toResetRects;

    [SerializeField] private Image progressCircle;
    [SerializeField] private TMP_Text progressCircleText;
    [SerializeField] private TMP_Text progressText;
    
    [SerializeField] private TMP_Text versionText;

    void Start()
    {
        OpenPanel(1);
        
        SetScrollSensitivity();
        
        //DEBUG ONLY
        //ProgressManager.Instance.SaveProgress(StageList.Stages.Length - 3);
        versionText.text = Application.version.ToString();
    }

    void FixedUpdate()
    {
        progressCircle.fillAmount = ProgressManager.Instance.progressPercent;
        progressCircleText.text = ((int)(progressCircle.fillAmount * 100)).ToString();
        if (Settings.ProgressIndicatorOnRight)
        {
            progressCircle.rectTransform.pivot = new Vector2(1, 1);
            progressCircle.rectTransform.anchorMax = new Vector2(1, 1);
            progressCircle.rectTransform.anchorMin = new Vector2(1, 1);
            progressCircle.rectTransform.anchoredPosition = new Vector2(-25, -5);
        }
        else
        {
            progressCircle.rectTransform.pivot = new Vector2(0, 1);
            progressCircle.rectTransform.anchorMax = new Vector2(0, 1);
            progressCircle.rectTransform.anchorMin = new Vector2(0, 1);
            progressCircle.rectTransform.anchoredPosition = new Vector2(25, -5);
        }
        //print(progressCircle.rectTransform.anchoredPosition);
    }

    public void StartGame()
    {
        LevelManager.Instance.LoadScene(1);
    }
    
    
    public void OpenPanel(int num)
    {
        for (int i = 0; i < canvasPanels.Length; i++)
        {
            canvasPanels[i].SetActive(i == num);
        }

        if (num == 3)
        {
            SetProgressData();
        }
    }

    public void SetProgressData()
    {
        progressText.text = $"{ProgressManager.Instance.correctAnswers} correct answers\n" +
                            $"{ProgressManager.Instance.wrongAnswers} wrong answers\n" +
                            $"{ProgressManager.Instance.accuracyPercent}% accuracy\n" +
                            $"current stage: {ProgressManager.Instance.currentStage}\n" +
                            $"out of {StageList.Stages.Length} stages\n" +
                            $"progress: {(int)(ProgressManager.Instance.progressPercent * 100)}%";
    }

    public void SetScrollSensitivity()
    {
        foreach(ScrollRect rect in toResetRects) 
        {
            ScrollRectExtensions.ScrollToTop(rect);
            rect.scrollSensitivity = Settings.ScrollSensitivity;
            //print(rect.scrollSensitivity);
            //print(Settings.ScrollSensitivity);
        }
    }
}
