using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movplayer : MonoBehaviour
{   
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform gcheck;
    public float gdistance = 0.4f;
    public float jump= 3f;
    public LayerMask gmask;
    Vector3 velocity;
    bool isgrounded;
   
    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(gcheck.position, gdistance, gmask);
        if(isgrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move= transform.right* x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if(Input.GetButtonDown("Jump")&&  isgrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }
        velocity.y +=  gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
