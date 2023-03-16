using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    //this will contain all the stuff for the dialog

    //SHAKE
    public GameObject jesus;
    public GameObject angel;

    public float shakeMagnitude = 1f;
    public float shakeDuration = 1f;
    public float elapsed = 0.0f;


    //JESUS DIALOG
    string s1 = "The World Is on FIRE!!! The human activities are killing Planet Earth.";
    string s2 = "You need to save them.";
    string s3 = "I know but Do it for the millions of plants and animals which will perish, if we don't do anything about it";

    //ANGEL DIALOG
    string s11 = "Those shitty humans, they get what they deserve. pfff, They are destroying their own place.";
    string s21 = "No, why should I??? It was their own doing!";
    string s31 = "Fine! I'll go save them only this once!";

    //TEXT BOXES
    public Text characterName;
    public Text characterDialog;


    List<string> dialog_l = new List<string>();
    void Start()
    {
        dialog_l.Add(s1);
        dialog_l.Add(s11);
        dialog_l.Add(s2);
        dialog_l.Add(s21);
        dialog_l.Add(s3);
        dialog_l.Add(s31);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("space");
            StartCoroutine(ShakeSprite(jesus));
            StartCoroutine(ShakeSprite(angel));
        }


    }

    //move the sprite up and down whenever they are talking 
    private IEnumerator ShakeSprite(GameObject obj)
    {
        Vector3 initialPosition = obj.transform.position;
        elapsed = 0.0f;
        while (elapsed < shakeDuration)
        {
            //float x = initialPosition.x + Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = initialPosition.y + Random.Range(-shakeMagnitude, shakeMagnitude);
            obj.transform.position = new Vector3(initialPosition.x, y, initialPosition.z);

            elapsed += Time.deltaTime;

            // Pause for one frame before continuing the loop
            yield return null;
        }

        obj.transform.position = initialPosition;
        
    }
}
