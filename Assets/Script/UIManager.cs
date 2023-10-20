using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inputCanvas;
    public GameObject gameplayCanvas;

    private void Awake()
    {
        inputCanvas.GetComponent<PlayerDataInputUIManager>().SetCallback(ShowGameplayCanvas);
    }

    void ShowGameplayCanvas()
    {
        inputCanvas.SetActive(false);
        gameplayCanvas.SetActive(true);
    }
}
