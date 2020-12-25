using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D ctrl;
    public float speed = 40f;
    private float horizontalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * speed;
    }

    private void FixedUpdate()
    {
        ctrl.Move(horizontalMove * Time.fixedDeltaTime,false);
    }
}
