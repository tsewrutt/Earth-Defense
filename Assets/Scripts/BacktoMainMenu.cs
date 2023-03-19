using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BacktoMainMenu : MonoBehaviour
{
    public Button b1;
    // Start is called before the first frame update
    void Start()
    {
        b1.onClick.AddListener(Task);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Task()
    {
        SceneManager.LoadScene("startscene");
    }
}
