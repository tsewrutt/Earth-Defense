using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    public Text gameOverText;
    private GameObject obj;
    
    void Start()
    {
        obj = GameObject.FindWithTag("signal");

        

        Gamesignal gs = obj.GetComponent<Gamesignal>();
    
        if(gs.win == true)
        {
            gameOverText.text = "Planet Earth has been saved!\n\nThank you for playing!!";
        }
        else
        {

            gameOverText.text = "You Failed!\nAll the animals and plants perished to death!\n\nTry again";
        }
    
    }

    // Update is called once per frame



}
