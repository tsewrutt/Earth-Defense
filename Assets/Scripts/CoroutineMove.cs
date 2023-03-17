using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destinationObject;
    public GameObject targetObject;
    public float speed = 0.1f;
    public float delayTime = 0.5f; // Time delay before movement starts

    private Transform destinationTransform;
    private Transform targetTransform;
    private Transform targetTransformForBack;

    void Start()
    {
        destinationTransform = destinationObject.transform;
        targetTransform = targetObject.transform;
        targetTransformForBack = targetObject.transform;
       // StartCoroutine(MoveCoroutine());
    }
    private void MoveTowardsTarget(Vector3 targetPosition)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }


/*    public void MoveBackDown(Vector2 3 targetPosition)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetTransformForBack.position, step);
    }*/

    public IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(delayTime);

        // Move to destination object first
        while (transform.position != destinationTransform.position)
        {
            MoveTowardsTarget(destinationTransform.position);
            yield return null;
        }

        // Move to target object
        while (transform.position != targetTransform.position)
        {
            MoveTowardsTarget(targetTransform.position);
            yield return null;
        }
    }

    public IEnumerator MoveBackCoroutine()
    {

        while (transform.position != targetTransformForBack.position)
        {
            MoveTowardsTarget(targetTransformForBack.position);
            yield return null;
        }

        // Move to target object
        while (transform.position != targetTransformForBack.position)
        {
            MoveTowardsTarget(targetTransformForBack.position);
            yield return null;
        }
    }

   

   
}
