using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWithOptions : Dialogue
{
    private List<DialogueOption> optionList;

    public List<DialogueOption> OptionList => optionList;

    public DialogueWithOptions(string text) : base(text)
    {
        optionList=new List<DialogueOption>();
    }

    public void AddOption(DialogueOption option)
    {
        optionList.Add(option);
    } 
}
