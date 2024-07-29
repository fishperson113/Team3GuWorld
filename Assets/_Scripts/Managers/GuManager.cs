using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuManager : Singleton<GuManager>
{
    [SerializeField] private SkillPool skillPool;
    [SerializeField] private GuConfig guConfig;
    [SerializeField] private GameObject GuPrefab;
    [SerializeField] private GuEventChannel guEventChannel;

    public GuController CreateGu()
    {
        IGu blankGu = GuFactory.CreateGu(guConfig);

        IGu decoratedGu = new SkillDecorator(blankGu, skillPool);

        GameObject guObject = Instantiate(GuPrefab);
        GuController guController = guObject.GetComponent<GuController>();
        guController.gu=decoratedGu;

        guEventChannel.Invoke(decoratedGu);

        return guController;
    }
}
