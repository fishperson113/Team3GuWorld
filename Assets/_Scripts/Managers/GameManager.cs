using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public enum GameState
{
    Menu,
    Playing,
    Completed
}

public class GameManager : PersistentSingleton<GameManager>
{
    public GameState CurrentState { get; private set; }
    private GameData currentGameData;

    private void Start()
    {
        CurrentState = GameState.Menu;
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