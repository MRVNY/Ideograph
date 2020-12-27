using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : IElement 
{
    private Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    

    public override void activate(IElement interactable)
    {
        if (interactable != null)
        {
            interactable.react(this);
        }
    }

    public override void react(IElement activator)
    {
        if (activator.GetType().Name.Equals("Water"))
        {
            renderer.enabled = false;
        }
    }
}
