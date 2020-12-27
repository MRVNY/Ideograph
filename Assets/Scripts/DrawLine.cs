using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    private GameObject currentLine;
    private LineRenderer lineRenderer;
    private List<List<Vector2>> positions;
    private Wand wand;
    void Start()
    {
        positions = new List<List<Vector2>>();
        wand = FindObjectOfType<Wand>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) createLine();
        if(Input.GetMouseButton(0))
        {
            Vector2 tmpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tmpPos,positions.Last().Last())>.1f) updateLine(tmpPos);
        }

        if(Input.GetMouseButtonUp(0)) checkChar();

    }

    void createLine()
    {
        currentLine = Instantiate(linePrefab, new Vector3(0,0,-4), Quaternion.identity);
        currentLine.transform.SetParent(transform);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        List<Vector2> tmpList = new List<Vector2>();
        positions.Add(tmpList);
        tmpList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        tmpList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0,tmpList[0]);
        lineRenderer.SetPosition(1,tmpList[1]);
    }

    void updateLine(Vector2 pos)
    {
        positions.Last().Add(pos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1,pos);
    }

    void checkChar()
    {
        //Fire
        if (positions.Count == 4 &&
            positions[0][0].y > positions[0].Last().y && //第一画从上到下
            positions[1][0].y > positions[1].Last().y && //第二画从上到下
            positions[2][0].y > positions[2].Last().y && //第三画从上到下
            positions[3][0].y > positions[3].Last().y && //第四画从上到下
            positions[0].Last().y > positions[2].Last().y && //一尾在三尾上
            positions[1].Last().y > positions[3].Last().y && //二尾在四尾上
            positions[2][0].x > positions[0][0].x && //二始在一始右边
            positions[2][0].x < positions[1][0].x && //二始在三始左边
            positions[3][0].y < positions[2][0].y && //四始在三始下面
            positions[3][0].y > positions[2].Last().y //四始在三尾上面
        )
        {
            print("是火");
            wand.loadSpell("Fire");
        }
        
        //Water
        if (positions.Count == 4 &&
            positions[0][0].y > positions[0].Last().y && //第一画从上到下
            positions[1][0].y > positions[1].Last().y && //第二画从上到下
            positions[2][0].y > positions[2].Last().y && //第三画从上到下
            positions[3][0].y > positions[3].Last().y && //第四画从上到下
            
            positions[2][0].x > positions[2].Last().x && //第三画从右到左
            positions[3][0].x < positions[3].Last().x && //第四画从左到右
            
            positions[0].Last().y > positions[2].Last().y && //一尾在三尾上
            positions[1].Last().y > positions[3].Last().y && //二尾在四尾上
            positions[2][0].x > positions[0][0].x && //二始在一始右边
            positions[2][0].x < positions[1][0].x && //二始在三始左边
            positions[3][0].y < positions[2][0].y && //四始在三始下面
            positions[3][0].y > positions[2].Last().y //四始在三尾上面
        )
        {
            print("是水");
            wand.loadSpell("Water");
        }
        
    }

    public void clear()
    {
        positions.Clear();
    }
}
