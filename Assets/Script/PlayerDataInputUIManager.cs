using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerDataInputUIManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField strengthInputField;
    public TMP_InputField dexteryInputField;
    public TMP_InputField lifeInputField;

    public Button continueButton;
    public TextMeshProUGUI pointsText;
    public Action OnCallback;

    public void Awake()
    {
        continueButton.onClick.AddListener(OnButtonClicked);
        strengthInputField.onValueChanged.AddListener(OnInputChange);
        dexteryInputField.onValueChanged.AddListener(OnInputChange);
        lifeInputField.onValueChanged.AddListener(OnInputChange);
    }

    public void SetCallback(Action OnCallback)
    {
        this.OnCallback = OnCallback;

    }

    void OnInputChange(string value)
    {
        int points = 100;

        if(strengthInputField.text.Length > 0)
        {
            points -= int.Parse(strengthInputField.text);
        }
        if (dexteryInputField.text.Length > 0)
        {
            points -= int.Parse(dexteryInputField.text);
        }
        if (lifeInputField.text.Length > 0)
        {
            points -= int.Parse(lifeInputField.text);
        }

        pointsText.text = $"Points: {points}";
    }




    public void OnButtonClicked()
    {
        if (PlayerData.Instance.ValidateData(
            nameInputField.text,
            int.Parse(strengthInputField.text),
            int.Parse(dexteryInputField.text),
            int.Parse(lifeInputField.text)
            ))
        {
            PlayerData.Instance.CreatePlayer(
                nameInputField.text,
                int.Parse(strengthInputField.text),
                int.Parse(dexteryInputField.text),
                int.Parse(lifeInputField.text)
                );
            OnCallback?.Invoke();
        }
    }

}
