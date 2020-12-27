using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Burnable : IElement
{
    private SpriteRenderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<Animator>().gameObject.GetComponent<SpriteRenderer>();
        renderer.enabled = false;
    }


    public override void activate(IElement interactable)
    {
        //do nothing
    }

    public override void react(IElement activator)
    {
        if (activator.GetType().Name.Equals("Fire"))
        {
            renderer.enabled = true;
            say("Burned");
        }
    }
}
