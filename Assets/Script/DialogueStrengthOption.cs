using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStrengthOption : DialogueOption
{
    public DialogueStrengthOption(int value, int lifeLoss, string text) : base(value, lifeLoss, text)
    {
    }

    public override void PickOption()
    {
        if (value > PlayerData.Instance.Strength)
        {
            PlayerData.Instance.ChangeLife(-lifeLoss);
            OnFailureCallback?.Invoke();
        }
        else
        {
            OnSuccessCallback?.Invoke();
        }
    }
}
