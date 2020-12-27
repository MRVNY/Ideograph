using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
}
