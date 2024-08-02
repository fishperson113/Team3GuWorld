using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuSpawner : MonoBehaviour
{
    [SerializeField] private GameObject GuPrefab;
    static int GuNumber=0;
    public void CreateGu(IGu gu)
    {
        GuNumber++;
        GameObject guObject = Instantiate(GuPrefab);
        GuController guController = guObject.GetComponent<GuController>();
        guController.name= "Gu " + GuNumber;
        gu.GetGuData().guName = guController.name;
        guController.gu=gu;
        Vector3 spawnPosition = GetRandomSpawnPosition();
        guObject.transform.position = spawnPosition;
    }
    private Vector3 GetRandomSpawnPosition()
    {
        Camera mainCamera = Camera.main;
        float screenLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).x;
        float screenRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, mainCamera.nearClipPlane)).x;
        float screenBottom = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).y;
        float screenTop = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, mainCamera.nearClipPlane)).y;

        float x = Random.Range(screenLeft, screenRight);
        float y = Random.Range(screenBottom, screenTop);

        return new Vector3(x, y, 0); // Assuming 2D game, Z-axis is set to 0
    }
}
