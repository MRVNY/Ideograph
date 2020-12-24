using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public GameObject player;
    private GameObject[] obstacles;
    
    void Start()
    {
        transform.position = player.transform.position;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float goY = player.transform.position.y;
            if (goY > pos.y) goY-=5;
            else goY++;
            transform.position = new Vector2(pos.x,goY);
            /*foreach(GameObject ob in obstacles)
            {
                Vector2 clickPos = transform.position;
                Vector2 obPos = ob.transform.position;
                float scaleX = ob.transform.localScale.x/2;
                if (obPos.y < clickPos.y && clickPos.x > obPos.x - scaleX && clickPos.x < obPos.x + scaleX) ;
                {
                    transform.position = new Vector2(clickPos.x,obPos.y);
                    break;
                }
            }*/
        }
    }
}
