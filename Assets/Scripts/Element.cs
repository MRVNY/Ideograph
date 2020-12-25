using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : MonoBehaviour, IElement
{
    void Update()
    {
        if (Input.GetButtonDown("Activate"))
        {
            activate();
        }
    }
    
    public abstract void activate();
    public abstract void react(String activator);
}
