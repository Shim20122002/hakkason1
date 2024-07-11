using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    private float speed = 5.0f; //移動速度
    private float rotationSpeed = 1f; // 回転速度
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            rb.velocity = transform.forward*speed;
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            rb.velocity = -transform.forward*speed;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = transform.right*speed;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = -transform.right*speed;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.up, -rotationSpeed);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.up, rotationSpeed);
        }
    }
}
