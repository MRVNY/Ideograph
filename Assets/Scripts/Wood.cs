using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Wood : IElement
{
    private SpriteRenderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }


    public override void activate(IElement interactable)
    {
        //do nothing
    }

    public override void react(IElement activator)
    {
        if (activator.tag.Equals("Fire"))
        {
            renderer.color = Color.red;
            say("Bured");
        }
    }
}
