using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float move1;
    public int speed;
    public int jump;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move1 = -1;
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            move1 = 1;
        }else move1 = 0;
        transform.Translate(Vector3.right*speed*move1*Time.deltaTime);
        //jump

        if (Input.GetKeyDown(KeyCode.UpArrow)) // (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*jump, ForceMode2D.Impulse);
        }
    }
}
