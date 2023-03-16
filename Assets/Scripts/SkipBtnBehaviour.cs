using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkipBtnBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Button skipBtn;

    //dialog box
    public Transform targetTransform;
    public GameObject dialogBox;
    private Transform dialogBoxTrans;
    public float delayTime = 2.0f;
    public float speed = 0.1f;

    
    private bool boxMotionDone;
    void Start()
    {
        dialogBoxTrans = dialogBox.transform;
        StartCoroutine(OperationMoveBox());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator OperationMoveBox()
    {
        yield return new WaitForSeconds(delayTime);
        while(dialogBoxTrans.position  != targetTransform.position)
        {
            TransformBoxTowardsTarget(dialogBoxTrans.position);
            yield return null;
        }
       

    }


    private void TransformBoxTowardsTarget(Vector3 boxPos)
    {
        float step = speed * Time.deltaTime;
        boxPos = Vector3.MoveTowards(targetTransform.position ,boxPos , step);
    }
}
