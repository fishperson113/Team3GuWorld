using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{
    public GameObject gameFinishedUI;
    private void Start()
    {
        FinishedPoint.endGame += ShowGameFinishedScreen;      
    }
    private void OnDisable()
    {
        FinishedPoint.endGame -= ShowGameFinishedScreen;
    }
    private void ShowGameFinishedScreen()
    {
        gameFinishedUI.SetActive(true);
    }

}