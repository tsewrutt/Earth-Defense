using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    public Text gameOverText;
    private GameObject obj;
    //sfx
    //public AudioSource winSound;
    public AudioSource loseSound;
    void Start()
    {
        obj = GameObject.FindWithTag("signal");
        GameObject music = GameObject.FindGameObjectWithTag("StarterMusic");


        Gamesignal gs = obj.GetComponent<Gamesignal>();
    
        if(gs.win == true)
        {
           
            if(music != null)
            {
                AudioSource a = music.GetComponent<AudioSource>();
                a.Play();
            }

            gameOverText.text = "Planet Earth has been saved!\n\nThank you for playing!!";
      
        }
        else
        {
            AudioSource a = music.GetComponent<AudioSource>();
            a.Stop();
            loseSound.Play();
            gameOverText.text = "You Failed!\nAll the animals and plants perished to death!\n\nTry again";
        }
    
    }

    // Update is called once per frame



}
