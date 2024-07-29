using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{

    [SerializeField] private InputReader inputReader;

    void Start()
    {
        GuController guController=GuManager.Instance.CreateGu();
        inputReader.guController = guController;
    }
}