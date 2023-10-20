using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerData instance;

    public static PlayerData Instance => instance;

    public event Action<int> OnLifeChange = (value) => { };

    private string playerName;
    private int strength;
    private int dextery;
    private int life;

    public string PlayerName => playerName;
    public int Strength => strength;
    public int Dextery => dextery;
    public int Life => life;

    

    private void Awake()
    {
        instance = this;
    }

    public bool ValidateData(string playerName, int strength, int dextery, int life)
    {
        if (playerName.Length == 0)
        {
            return false;
        }

        if (strength <= 0 || dextery <= 0 || life <= 0)
        {
            return false;
        }

        if (strength + dextery + life > 100)
        {
            return false;
        }

        return true;

    }

    public void CreatePlayer(string playerName, int strength, int dextery, int life)
    {
        this.playerName = playerName;
        this.strength = strength;
        this.dextery = dextery;
        this.life = life;
    }

    public void ChangeLife(int value)
    {
        life += value;
        OnLifeChange?.Invoke(life);
    }
}
