using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highScoreText;
    public InputField playerName;

   

    void Start()
    {
        if (DataStorage.Instance != null)
        {
            DataStorage.Instance.LoadDataMethod();
            highScoreText.text = "High Score: " + DataStorage.Instance.playerName + " : " + DataStorage.Instance.highScore;
        }
    }

    void Update()
    {
        playerName.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string name)
    {
        DataStorage.Instance.currentName = name;
        Debug.Log(name);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        DataStorage.Instance.SaveDataMethod();
    }

    public void Exit()
    {
        DataStorage.Instance.SaveDataMethod();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

        DataStorage.Instance.SaveDataMethod();
    }
}
