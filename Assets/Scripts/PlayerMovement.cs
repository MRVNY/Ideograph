using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public List<BoxCollider2D> platforms;
    public List<PolygonCollider2D> stairs;

    private Vector2 pPos;
    private Vector2 mPos;

    public CharacterController2D ctrl;
    public float speed = 40f;
    private float horizontalMove = 0f;

    private void Start()
    {
        pPos = transform.position;
        mPos = pPos;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            pPos = transform.position;
            mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            foreach (BoxCollider2D platform in platforms)
            {
                float py = platform.bounds.center.y;
                if ((mPos.y > py && pPos.y < py) || (mPos.y < py && pPos.y > py))
                {
                    platform.enabled = false;
                }
                else platform.enabled = true;
            }

            foreach (PolygonCollider2D stair in stairs)
            {

            }
        }
    }

    private void FixedUpdate()
    {
        pPos = transform.position;
        if (pPos.x + 1f < mPos.x) horizontalMove = speed;
        else if (pPos.x > mPos.x + 1f) horizontalMove = -speed;
        else horizontalMove = 0;
        ctrl.Move(horizontalMove * Time.fixedDeltaTime,false);
    }

    public void resetMPos()
    {
        pPos = transform.position;
        mPos = pPos;
    }
}
