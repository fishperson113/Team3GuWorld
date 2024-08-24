using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.IO;
public class Checkpoint : MonoBehaviour
{
    private GameObject player;
    private PlayerInput input;

    private void Start()
    {
        input = KeyboardManager.Instance.input;
        input.Enable();
        input.normal.Reset.performed += OnReloadPuzzle;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player == null)
        {
            player = other.gameObject;
            SaveGame();
            Debug.Log("Checkpoint đạt, game đã được lưu.");
        }
    }

    private void OnReloadPuzzle(InputAction.CallbackContext context)
    {
        LoadGame();
    }

    public void SaveGame()
    {
        GameData gameData = new GameData();

        if (player != null)
        {
            gameData.playerPosition = new float[] { player.transform.position.x, player.transform.position.y, player.transform.position.z };
        }

        ISavable[] savableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISavable>().ToArray();

        gameData.objectsData.Clear(); // Clear existing data to prevent duplicates

        foreach (ISavable savable in savableObjects)
        {
            ObjectData objectData = savable.GetObjectData();
            gameData.objectsData.Add(objectData);
        }
        SaveSystem.DeleteSave();

        SaveSystem.SaveGame(gameData); 
    }

    public void LoadGame()
    {
        GameData gameData = SaveSystem.LoadGame(); 

        if (gameData != null)
        {
            if (player != null)
            {
                player.transform.position = new Vector3(gameData.playerPosition[0], gameData.playerPosition[1], gameData.playerPosition[2]);
            }

            ISavable[] savableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISavable>().ToArray();

            // Create a dictionary to map IDs to savable objects
            var savableDict = new Dictionary<string, ISavable>();

            foreach (var savable in savableObjects)
            {
                var objectID = savable.GetObjectData().objectID;

                if (!savableDict.ContainsKey(objectID))
                {
                    savableDict[objectID] = savable;
                }
                else
                {
                    Debug.LogWarning($"Duplicate objectID found: {objectID}. Only one instance will be used.");
                }
            }

            foreach (ObjectData objData in gameData.objectsData)
            {
                if (savableDict.TryGetValue(objData.objectID, out ISavable savable))
                {
                    savable.SetObjectData(objData);
                }
                else
                {
                    Debug.LogWarning($"Object with ID {objData.objectID} not found for loading.");
                }
            }
        }
    }
}
