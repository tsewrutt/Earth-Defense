using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StarterMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 velocity;
    //private Renderer rend;
    public float speed = 10f;
    private Rigidbody2D rb;
    public float init_s = 50f;
    public Vector3 direction; 
    // public Light point_l;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * init_s * speed * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {

       


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //point_l.color = new Color32(System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), System.Convert.ToByte(Random.Range(0, 255)), 255);
        rb.AddForce(rb.velocity.normalized * init_s * speed * Time.deltaTime);
    }

}
