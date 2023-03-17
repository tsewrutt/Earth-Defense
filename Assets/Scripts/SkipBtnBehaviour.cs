using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SkipBtnBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Button skipBtn;

    public DialogManager dmscript;
    public CoroutineMove cmovement;
    public int btnpresscount;

    void Start()
    {
        skipBtn.onClick.AddListener(TaskOnClick);
  
    }

    // Update is called once per frame
    void Update()
    {
        if (btnpresscount == 7)
        {
            //that will be at the last press
            SceneManager.LoadScene("level1");
        }
    }


    //gets called whenver skip button is pressed
    public void TaskOnClick()
    {
        SceneManager.LoadScene("level1");

    }


/*    public IEnumerator showTextNow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

    }*/


    public IEnumerator moveToScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("level1");
    }
    
}
