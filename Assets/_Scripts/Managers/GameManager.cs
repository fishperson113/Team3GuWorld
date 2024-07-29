using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{

    [SerializeField] private SkillTester skillTester;

    void Start()
    {
        GuController guController=GuManager.Instance.CreateGu();
        skillTester.guController = guController;
    }
}