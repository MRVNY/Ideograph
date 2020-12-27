using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    private Image image;
    private DrawLine draw;
    private PlayerMovement move;
    private SpriteRenderer[] anims;
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        draw = GetComponent<DrawLine>();
        draw.enabled = false;
        move = FindObjectOfType<PlayerMovement>();
        anims = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in anims)
        {
            sr.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void togglePanel()
    {
        if (image.enabled == false)
        {
            move.resetMPos();
            move.enabled = false;
            image.enabled = true;
            draw.enabled = true;
            foreach (SpriteRenderer sr in anims)
            {
                sr.enabled = true;
            }
        }
        else
        {
            image.enabled = false;
            draw.clear();
            draw.enabled = false;
            foreach (SpriteRenderer sr in anims)
            {
                sr.enabled = false;
            }
            //GetComponents<>()
            LineRenderer[] toDestroy = GetComponentsInChildren<LineRenderer>();
            foreach (LineRenderer obj in toDestroy)
            {
                Destroy(obj.gameObject);
            }
            move.enabled = true;
            move.resetMPos();
        }
    }
}
