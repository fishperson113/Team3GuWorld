using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuSpawner : MonoBehaviour
{
    [SerializeField] private GameObject GuPrefab;
    public void CreateGu(IGu gu)
    {
        GameObject guObject = Instantiate(GuPrefab);
        GuController guController = guObject.GetComponent<GuController>();
        guController.gu=gu;
    }
}
