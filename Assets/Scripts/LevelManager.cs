using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; set; }
    [SerializeField] GameObject loadingScreen;

    private void Awake()
    {
        Debug.Log("LevelManager initialize Singleton");
        
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

        Application.targetFrameRate = 120;
    }
    
    public void LoadScene(int index)
    {
        StartCoroutine(AsyncLoad(index));
    }

    IEnumerator AsyncLoad(int index)
    {
        loadingScreen.SetActive(true);

        AsyncOperation asy = SceneManager.LoadSceneAsync(index);

        while (!asy.isDone)
        {
            yield return null;
        }

        loadingScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            ScreenCapture.CaptureScreenshot("screenshot" + Time.time +".png");
    }
}
