using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IElement : MonoBehaviour
{
    private Text box;

    private void Awake()
    {
        box = FindObjectOfType<Canvas>().GetComponentInChildren<Text>();
    }

    public abstract void activate(IElement interactable);
    public abstract void react(IElement activator);

    public void say(string s)
    {
        box.text = s;
    }
}
