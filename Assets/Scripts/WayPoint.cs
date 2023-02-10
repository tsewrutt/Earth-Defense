using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class WayPoint : MonoBehaviour
{
    [SerializeField] private Vector3[] points;
    // Start is called before the first frame update
    public Vector3[] pts => points;

    public Vector3 currentPos => _currPos;

    private Vector3 _currPos;

    private bool gameon;

    void Start()
    {
        gameon = true;
        _currPos = transform.position;
    }

    public Vector3 GetWayPointPos(int i)
    {
        return currentPos + pts[i];
    }



    private void onDrawGizmos()
    {
        if (!gameon && transform.hasChanged)
        {
            _currPos = transform.position;
        }
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(points[i] + _currPos, 0.5f);

            if (i < points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + _currPos, points[i + 1] + _currPos);
            }

        }
    }








    /*    // Update is called once per frame
        void Update()
        {

        }*/
}
