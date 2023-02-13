using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ExitAction : MonoBehaviour
{
        public Button _b;

        void Start()
        {
           _b.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            
            Application.Quit();
        }
      
}
