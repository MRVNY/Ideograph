using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element 
{
    private IElement interactable;
    private Renderer renderer;
    private String tag;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        tag = gameObject.tag;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        print("Enter" + other);
        if(other.gameObject.GetComponent<IElement>() != null) interactable = other.gameObject.GetComponent<IElement>();
        print(interactable);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        print("Exit" + other);
        interactable = null;
    }

    public override void activate()
    {
        if (interactable != null)
        {
            print("React Wood");
            interactable.react(tag);
        }
    }

    public override void react(String activator)
    {
        if (activator.Equals("Water"))
        {
            renderer.enabled = false;
        }
    }
}
