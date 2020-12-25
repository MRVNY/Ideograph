using System;
using UnityEngine;

public interface IElement
{
    void activate();
    void react(String activator);
}
