using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{
    [SerializeField] protected string text;

    [SerializeField] protected Dialogue nextDialogue;

    public string Text => text;
    public Dialogue NextDialogue => nextDialogue;

    public Dialogue(string text)
    {
        this.text = text;
    }

    public void SetNextDialogue(Dialogue nextDialogue)
    {
        this.nextDialogue = nextDialogue;
    }
}
