using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Wood : Element
{
    private SpriteShapeRenderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteShapeRenderer>();
    }


    public override void activate()
    {
        //do nothing
    }

    public override void react(String activator)
    {
        if (activator.Equals("Fire"))
        {
            
            renderer.color = Color.red;
        }
    }
}
