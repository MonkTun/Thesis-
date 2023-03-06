using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    #region References

    [SerializeField] private GameObject learnPanel, quizPanel, loadingPanel;
    [SerializeField] private Animator loadingAN;
    [SerializeField] private GameObject leaveOverlayPanel, successOverlayPanel, failedOverlayPanel, tipOverlayPanel;
    [SerializeField] private ScrollRect[] toResetRects;
    [SerializeField] private GameObject masteredOverlayPanel;
    [SerializeField] private RectTransform leaveButton;
    [SerializeField] private TMP_Text successText, failedText, masteredText;

    [Header("Learn")] 
    [SerializeField] private Transform learnPanelScrollViewContent;
    [SerializeField] private GameObject emptyImagePrefab, dynamicTextPrefab, hyperlinkButtonPrefab;
    [SerializeField] private TMP_Text tipText;
    
    [Header("Quiz")]
    [SerializeField] private Transform quizPanelScrollViewContent;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_Text[] answerChoiceTexts;
    [SerializeField] private Button leftAnchorButton, rightAnchorButton;

    [Header("Progress Bar")]
    [SerializeField] private Image progressCircle;
    [SerializeField] private TMP_Text progressCircleText;
    
    public static GameManager Instance { get; private set; }

    private Stage currentStage;
    private int currentQuiz;
    private int quizAnchor; //new addition
    private int selectedAnswerChoice;
    private List<GameObject> instantiatedPrefabs = new List<GameObject>();

    private bool isTransitioning;
    
    #endregion

    #region Initialize

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    void Start()
    {
        OverlayPanelManage(null);
        currentStage = StageList.Stages[ProgressManager.Instance.currentStage < StageList.Stages.Length ? ProgressManager.Instance.currentStage : StageList.Stages.Length - 1];
        currentQuiz = ProgressManager.Instance.currentQuiz;
        quizAnchor = currentQuiz;
        StartCoroutine(SetUpRoutine(true));

        print("current: " +ProgressManager.Instance.currentStage);
        print("Length" + StageList.Stages.Length);
    }

    IEnumerator SetUpRoutine(bool openLearn)
    {
        isTransitioning = true;
        if (!loadingPanel.activeInHierarchy)
        {
            loadingPanel.SetActive(true);
            loadingAN.SetTrigger("Start");
            yield return new WaitForSeconds(0.5f);
        }

        tipText.text = currentStage.tips;
        
        SetUpLearn();
        SetUpQuiz();
        ChooseAnswer(-1);

        rightAnchorButton.interactable = currentQuiz > quizAnchor;
        leftAnchorButton.interactable = quizAnchor > 0;
        

        learnPanel.SetActive(true);
        quizPanel.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        PanelManage(null);
        yield return new WaitForSeconds(0.05f);
        PanelManage(openLearn ? learnPanel: quizPanel);
        
        loadingAN.SetTrigger("End");

        foreach (ScrollRect rect in toResetRects)
        {
            ScrollRectExtensions.ScrollToTop(rect);
            rect.scrollSensitivity = Settings.ScrollSensitivity;
        }
        yield return new WaitForSeconds(0.5f);
        loadingPanel.SetActive(false);
        isTransitioning = false;
    }

    #endregion

    #region Updates

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
            

            leaveButton.pivot = new Vector2(0, 1);
            leaveButton.anchorMax = new Vector2(0, 1);
            leaveButton.anchorMin = new Vector2(0, 1);
            leaveButton.anchoredPosition = new Vector2(75, -50);
            
        }
        else
        {
            progressCircle.rectTransform.pivot = new Vector2(0, 1);
            progressCircle.rectTransform.anchorMax = new Vector2(0, 1);
            progressCircle.rectTransform.anchorMin = new Vector2(0, 1);
            progressCircle.rectTransform.anchoredPosition = new Vector2(25, -5);
            
            leaveButton.pivot = new Vector2(1, 1);
            leaveButton.anchorMax = new Vector2(1, 1);
            leaveButton.anchorMin = new Vector2(1, 1);
            leaveButton.anchoredPosition = new Vector2(-75, -50);
  
        }
        //print(progressCircle.rectTransform.anchoredPosition);
    }
    

    #endregion
    
    #region Buttons

    public void ButtonTryLeave()
    {
        OverlayPanelManage(leaveOverlayPanel);
    }

    public void ButtonAskTip()
    {
        OverlayPanelManage(tipOverlayPanel);
    }
    
    public void ButtonCloseOverlap()
    {
        OverlayPanelManage(null);
    }

    public void ButtonGoQuiz()
    {
        if (currentStage.quizzes.Length > 0)
            PanelManage(quizPanel);
        else
        {
            loadingPanel.SetActive(false);
            OverlayPanelManage(masteredOverlayPanel);
            masteredText.text = $"You Finished!\nFinal Accuracy: <color=green>{ProgressManager.Instance.accuracyPercent}</color>%";
            PanelManage(null);
            if (ProgressManager.Instance.currentStage < StageList.Stages.Length + 1)
                ProgressManager.Instance.SaveProgress(ProgressManager.Instance.currentStage);
        }
    }
    
    public void ButtonGoLearn()
    {
        PanelManage(learnPanel);
    }

    public void LeaveGame()
    {
        LevelManager.Instance.LoadScene(0);
    }

    public void ResetProgress()
    {
        ProgressManager.Instance.ResetProgress();
        ButtonContinueGame();
    }

    public void MoveQuizAnchorLeft()
    {
        if (isTransitioning) return;
        
        int originalAnchor = quizAnchor;
        
        quizAnchor--;

        if (quizAnchor < 0)
        {
            quizAnchor = 0;
        }

        if (quizAnchor != originalAnchor) ButtonContinueGame();
    }
    
    public void MoveQuizAnchorRight()
    {
        if (isTransitioning) return;
        
        int originalAnchor = quizAnchor;
        
        quizAnchor++;

        if (quizAnchor > currentQuiz) quizAnchor = currentQuiz;

        if (quizAnchor != originalAnchor) ButtonContinueGame();
    }
    
    
    #endregion

    #region GameLoop

    void SetUpLearn()
    {
        foreach (GameObject toDelete in instantiatedPrefabs)
        {
            Destroy(toDelete);
        }
        
        instantiatedPrefabs.Add(Instantiate(emptyImagePrefab, learnPanelScrollViewContent)); //header

        for (int i = 0; i < currentStage.resources.Length; i++)
        {
            if (currentStage.resources[i].Contains("https://"))
            {
                Button button = Instantiate(hyperlinkButtonPrefab, learnPanelScrollViewContent).GetComponent<Button>();
                string link = currentStage.resources[i];
                button.onClick.AddListener(() => Application.OpenURL(link));
                instantiatedPrefabs.Add(button.gameObject);
                //print(currentStage.resources[i]);
                //Application.OpenURL(currentStage.resource[i]);
            }
            else
            {
                TMP_Text text = Instantiate(dynamicTextPrefab, learnPanelScrollViewContent).GetComponent<TMP_Text>();
                text.text = currentStage.resources[i];
                instantiatedPrefabs.Add(text.gameObject);
            }
        }
        
        instantiatedPrefabs.Add(Instantiate(emptyImagePrefab, learnPanelScrollViewContent)); 
    }
    
    void SetUpQuiz()
    {
        if (currentStage.quizzes.Length == 0) return;
        
        questionText.text = "\n" + currentStage.quizzes[quizAnchor].question;
        
        for (int i = 0; i < answerChoiceTexts.Length; i++)
        {
            answerChoiceTexts[i].text = "\n" + currentStage.quizzes[quizAnchor].answerChoices[i] + "\n ";
            int j = i;
            Button button = answerChoiceTexts[i].GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            if (quizAnchor == currentQuiz)
                button.onClick.AddListener(() => ChooseAnswer(j));
        }

       
    }
    
    void ChooseAnswer(int index)
    {
        print("choose answer/ current stage: " + ProgressManager.Instance.currentStage);
        
        if (index == selectedAnswerChoice && index != -1)
        {
            FinalizeAnswer();
            return;
        } 
        else if (index == -1)
        {
            if (quizAnchor != currentQuiz)
            {
                for (int i = 0; i < answerChoiceTexts.Length; i++)
                {
                    if (i == currentStage.quizzes[quizAnchor].correctAnswerChoice)
                        answerChoiceTexts[i].GetComponentInChildren<Image>().color = new Color32(130,237,0,75);
                    else 
                        answerChoiceTexts[i].GetComponentInChildren<Image>().color = new Color32(161,161,161,75);
                }

                return;
            }
        }
        
        for (int i = 0; i < answerChoiceTexts.Length; i++)
        {
            if (i == index) answerChoiceTexts[i].GetComponentInChildren<Image>().color = new Color32(255,212,0,75);
            else answerChoiceTexts[i].GetComponentInChildren<Image>().color = new Color32(161,161,161,75);
        }

        selectedAnswerChoice = index;
    }
    
    void FinalizeAnswer()
    {
        if (selectedAnswerChoice == currentStage.quizzes[currentQuiz].correctAnswerChoice)
        {
            //currentQuiz++;
            ProgressManager.Instance.SetCurrentQuiz(++currentQuiz);
            currentQuiz = ProgressManager.Instance.currentQuiz;
            quizAnchor = currentQuiz;

            ProgressManager.Instance.UpdateAccuracy(false);
            
            if (currentStage.quizzes.Length <= currentQuiz)
                ProgressManager.Instance.SaveProgress(ProgressManager.Instance.currentStage);
            
            print($"debug: current stage: {ProgressManager.Instance.currentStage}");

            if (ProgressManager.Instance.currentStage < StageList.Stages.Length)
            {
                OverlayPanelManage(successOverlayPanel);
                successText.text = $"Nice Job!\nAccuracy: <color=green>{ProgressManager.Instance.accuracyPercent}</color>%";
                AudioManager.Instance.PlayAudio(AudioManager.Instance.successClip);
            }
            else
            {
                OverlayPanelManage(masteredOverlayPanel);
                masteredText.text = $"You Finished!\nFinal Accuracy: <color=green>{ProgressManager.Instance.accuracyPercent}</color>%";
                AudioManager.Instance.PlayAudio(AudioManager.Instance.masteredClip);
            }
        }
        else
        {
            ProgressManager.Instance.UpdateAccuracy(true);
            OverlayPanelManage(failedOverlayPanel);
            //TODO: play some sad audio
            AudioManager.Instance.PlayAudio(AudioManager.Instance.failedClip);
            failedText.text = $"Try again!\nAccuracy: <color=red>{ProgressManager.Instance.accuracyPercent}</color>%";
        }

        return;
        
        //if player guesses it correct
    }

    public void ButtonRetry()
    {
        OverlayPanelManage(null);
        ChooseAnswer(-1);
    }

    public void ButtonContinueGame()
    {
        print("current: " + ProgressManager.Instance.currentStage);
        print("Length" + StageList.Stages.Length);

        if (currentStage != null && currentStage.quizzes.Length > currentQuiz)
        {
            StartCoroutine(SetUpRoutine(false));
            OverlayPanelManage(null);
        }
        else if (ProgressManager.Instance.currentStage >= StageList.Stages.Length)
        {
            LevelManager.Instance.LoadScene(0);
        }
        else
        {
            Start();
        }
    }

    #endregion

    #region PanelManager

    void PanelManage(GameObject exception)
    {
        learnPanel.SetActive(learnPanel == exception);
        quizPanel.SetActive(quizPanel == exception);
    }

    void OverlayPanelManage(GameObject exception)
    {
        leaveOverlayPanel.SetActive(leaveOverlayPanel == exception);
        successOverlayPanel.SetActive(successOverlayPanel == exception);
        failedOverlayPanel.SetActive(failedOverlayPanel == exception);
        tipOverlayPanel.SetActive(tipOverlayPanel == exception);
        masteredOverlayPanel.SetActive(masteredOverlayPanel == exception);
    }

    #endregion

}
