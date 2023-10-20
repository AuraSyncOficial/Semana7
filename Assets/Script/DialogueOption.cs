using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueOption
{
    protected int value;
    protected int lifeLoss;
    protected string text;
    protected Action OnSuccessCallback;
    protected Action OnFailureCallback;

    public string Text => text;
    public DialogueOption(int value, int lifeLoss, string text)
    {
        this.value = value;
        this.lifeLoss = lifeLoss;
        this.text = text;
    }

    public void SetCallback(Action OnSuccessCallback,Action OnFailureCallback)
    {
        this.OnSuccessCallback = OnSuccessCallback;
        this.OnFailureCallback= OnFailureCallback;
    }

    public abstract void PickOption();

}
