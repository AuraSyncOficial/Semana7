using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerDataShowUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI strengthText;
    [SerializeField] private TextMeshProUGUI dexteryText;
    [SerializeField] private TextMeshProUGUI lifeText;

    void Start()
    {
        nameText.text = $"Name: {PlayerData.Instance.PlayerName}";
        strengthText.text = $"Strength: {PlayerData.Instance.Strength}";
        dexteryText.text = $"Dextery: {PlayerData.Instance.Dextery}";
        lifeText.text = $"Life: {PlayerData.Instance.Life}"; 

        PlayerData.Instance.OnLifeChange += OnLifeChange;
    }

    void OnLifeChange(int value)
    {
        lifeText.text = $"Life: {value}";
    }

    private void OnDestroy()
    {
        PlayerData.Instance.OnLifeChange -= OnLifeChange;
    }
}
