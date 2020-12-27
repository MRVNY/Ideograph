using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Wand : MonoBehaviour
{
    private IElement interactable;
    private Dictionary<string, IElement> spells;
    private IElement currentSpell;
    private IElement tmpSpell;

    private GameObject button;
    private Canvas canvas;
    
    void Start()
    {
        button = GetComponentInChildren<Button>().gameObject;
        spells = new Dictionary<string, IElement>();
        canvas = FindObjectOfType<Canvas>();
        button.transform.SetParent(canvas.transform);
        button.transform.localScale = new Vector3(1,1,1);
        button.SetActive(false);
        addSpell(gameObject.GetComponent<Learn>());
        loadSpell("Learn");
        currentSpell.say("Learn added");
        //loadSpell("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<IElement>() != null)
        {
            interactable = other.gameObject.GetComponent<IElement>();
            print("currentSpell" + currentSpell);
            if (interactable.GetType().Name == "Learn")
            {
                tmpSpell = currentSpell;
                loadSpell("Learn");
            }
            button.transform.position = new Vector3(interactable.transform.position.x,interactable.transform.position.y+interactable.transform.localScale.y);
            button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactable = null;
        button.SetActive(false);
        if(currentSpell.GetType().Name=="Load") loadSpell(tmpSpell.GetType().Name);
    }

    public void addSpell(IElement spell)
    {
        if (!spells.ContainsValue(spell))
        {
            spells.Add(spell.GetType().Name,spell);
            print(spell.GetType().Name+ spell+ "added");
            if(spell.GetType().Name!="Learn") spell.say(spell.GetType().Name+ " added");
        }
        else spell.say(spell.GetType().Name+ " already learned");
    }

    public void loadSpell(string spellName)
    {
        if (spells.ContainsKey(spellName))
        {
            currentSpell = spells[spellName];
            button.GetComponentInChildren<Text>().text = spellName;
            if(currentSpell.GetType().Name!="Learn") currentSpell.say(currentSpell.GetType().Name+ " loaded");
        }
    }

    public void useSpell()
    {
        if (currentSpell != null)
        {
            currentSpell.activate(interactable);
        }
    }
}
