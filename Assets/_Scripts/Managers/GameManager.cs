using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public enum GameState
{
    Playing,
    Completed
}

public class GameManager : StaticInstance<GameManager>
{
    public GameState CurrentState { get; private set; }
    private GameData currentGameData;
    [SerializeField]
    private GameObject playerPrefab;
    public GameObject winScreenUI;
    protected override void Awake()
    {
        base.Awake();
        StartGame();
        FinishedPoint.endGame += WinGame;
        winScreenUI.SetActive(false);
    }
    private void OnDisable()
    {
        FinishedPoint.endGame -= WinGame;
    }
    private void WinGame()
    {
        if (winScreenUI != null)
        {
            winScreenUI.SetActive(true);
            CurrentState = GameState.Completed;
        }
        else
        {
            Debug.LogError("winScreenUI is missing or destroyed.");
        }
    }
    public void StartGame()
    {
        LoadGame();
        CurrentState = GameState.Playing;
    }

    public void LoadGame()
    {
        currentGameData = SaveSystem.LoadGame();

        if (currentGameData != null)
        {
            ApplyGameData(currentGameData);
            Debug.Log("Game loaded successfully.");
        }
        else
        {
            Debug.Log("Không có file save nào, bắt đầu từ đầu.");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Transform spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
            player.transform.position = spawnPoint.position;
        }
    }

    public void DeleteSave()
    {
        SaveSystem.DeleteSave();
    }

    private void ApplyGameData(GameData data)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
        }

        ISavable[] savableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISavable>().ToArray();

        foreach (ObjectData objData in data.objectsData)
        {
            foreach (ISavable savable in savableObjects)
            {
                if (savable.GetObjectData().objectID == objData.objectID)
                {
                    savable.SetObjectData(objData);
                    break;
                }
            }
        }
    }
}