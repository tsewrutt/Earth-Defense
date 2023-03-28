using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    //TRANSFORM INFO
    public Vector3 targetPosForAngel;
    public Vector3 targetPosForJesus;
    public float moveSpeed = 10f;
    private Vector3 initJesusPos;
    private Vector3 initAngelPos;

    //DIALOG
    private int index = 0;
    List<string> dialog_l = new List<string>();

    public List <AudioSource> a = new List<AudioSource>();
  



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
    public SkipBtnBehaviour skipbtnbehaviour;
    public CoroutineMove cmovement;


    void Start()
    {
        initAngelPos = angel.transform.position;
        initJesusPos = jesus.transform.position;
        
        dialog_l.Add(s1);
        dialog_l.Add(s11);
        dialog_l.Add(s2);
        dialog_l.Add(s21);
        dialog_l.Add(s3);
        dialog_l.Add(s31);


        StartCoroutine(Convo(index));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("space");
            StartCoroutine(ShakeSprite(jesus));
            StartCoroutine(ShakeSprite(angel));
        }
        //StartCoroutine(normalWait(4));

       // UpdateDialogBox("Angel", dialog_l[5]);

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


    private IEnumerator Convo(int i)
    {

        //cmovement.moveCoroutine(true);
        StartCoroutine(MoveGameObject(jesus, targetPosForJesus));
        StartCoroutine(MoveGameObject(angel, targetPosForAngel));
        yield return StartCoroutine(cmovement.MoveCoroutine());
        Debug.Log("movement complete");
        while (i < dialog_l.Count)
        {
            switch (i)
            {
                case 0:
                    a[i].Play();
                    break;
                case 1:
                    a[i].Play();
                    break;
                case 2:
                    a[i].Play();
                    break;
                case 3:
                    a[i].Play();
                    break;
                case 4:
                    a[i].Play();
                    break;
                case 5:
                    a[i].Play();
                    break;
                default:
                    break;
            }

            if (i % 2 == 0)
            {
                // yield return new WaitForSeconds(1f);
                
                StartCoroutine(ShakeSprite(jesus));
                yield return StartCoroutine(ShowTextAndWait(i, dialog_l[i], 5.0f));
            }
            else
            {
              //  yield return new WaitForSeconds(1f);
                StartCoroutine(ShakeSprite(angel));
                yield return StartCoroutine(ShowTextAndWait(i, dialog_l[i], 5.0f));
            }
            


            Debug.Log("changing convo...");
            i++;

            if (i >= dialog_l.Count)
            {
                UpdateDialogBox("", "");
                StartCoroutine(cmovement.MoveBackCoroutine());
                yield return StartCoroutine(MoveGameObject(jesus, initJesusPos));
                yield return StartCoroutine(MoveGameObject(angel, initAngelPos));
               
                StartCoroutine(UpdateScene());
                //insert here
               
            }
        }



    }
    private void UpdateDialogBox(string character, string dialog)
    {
        characterName.text = character;
        characterDialog.text = dialog;
    }

    private IEnumerator ShowTextAndWait(int i,string dialog, float delayTime)
    {
        string characterName;
        UpdateDialogBox("", "");
        //yield return new WaitForSeconds(2.0f);
        if(i % 2 == 0)
        {
            characterName = "Jesus";
        }
        else
        {
            characterName = "Angel";
        }
        UpdateDialogBox(characterName, dialog);
        yield return new WaitForSeconds(delayTime);
        UpdateDialogBox("", "");
    }


    private IEnumerator MoveGameObject(GameObject go, Vector3 targetPos)
    {
        while(go.transform.position != targetPos)
        {

            go.transform.position = Vector3.MoveTowards(go.transform.position, targetPos, moveSpeed);
            yield return null;
        
        }

    }

    private IEnumerator UpdateScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("level1");
    }





}
