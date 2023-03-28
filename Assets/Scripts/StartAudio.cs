using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartAudio : MonoBehaviour
{
    // Start is called before the first frame update


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StarterMusic");

        if(objs.Length > 1)
        {
            AudioSource a = objs[0].GetComponent<AudioSource>();
            a.Play();
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
