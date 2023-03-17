using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GoBackToMainMenu : MonoBehaviour
{
    public Button _b;

    void Start()
    {
        _b.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {

        SceneManager.LoadScene("startscene");
    }
}
