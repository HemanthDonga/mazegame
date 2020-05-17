using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{

    public bool ground;
    public Rigidbody rb;
    public Vector3 movement;
    public float horizontal;
    public float vertical;
    public float jump;
    public float jumpheight = 9f;
    public Transform sphereobject;
    public float speed;
    public float max_speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ground = true;
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        sphereinput();
        sphereaction();
    }

    private void OnCollisionEnter(Collision objectsphere)
    {
        objectsphere.gameObject.CompareTag("ground");
        ground = true;
    }

    void sphereinput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

    }

    void sphereaction()
    {
        speed = max_speed;
        movement = new Vector3(1f * speed * horizontal*Time.deltaTime, 1f * jumpheight * jump * Time.deltaTime, 1f * speed * vertical * Time.deltaTime);
        rb.MovePosition(transform.position + movement);
        ground = false;
    }

}
