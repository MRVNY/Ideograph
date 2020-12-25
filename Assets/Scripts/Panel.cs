using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject linePrefab;
    private Image image;
    private DrawLine draw;
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        draw = GetComponent<DrawLine>();
        draw.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void togglePanel()
    {
        if (image.enabled == false)
        {
            image.enabled = true;
            draw.enabled = true;
        }
        else
        {
            image.enabled = false;
            draw.clear();
            draw.enabled = false;
            //GetComponents<>()
            LineRenderer[] toDestroy = GetComponentsInChildren<LineRenderer>();
            foreach (LineRenderer obj in toDestroy)
            {
                Destroy(obj.gameObject);
            }
            
        }
    }
}
