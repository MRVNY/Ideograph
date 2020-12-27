using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : IElement
{
    public IElement spell;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void activate(IElement interactable)
    {
        if (interactable.GetType().Name == "Learn")
        {
            interactable.react(this);
        }
        else say("Learned nothing");
    }

    public override void react(IElement activator)
    {
        if (spell == null) say("Learned nothing");
        else
        {
            activator.gameObject.GetComponent<Wand>().addSpell(spell);
        }
    }
}
