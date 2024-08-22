using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

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
        if (other.CompareTag("Player")&& player==null)
        {
            player = other.gameObject;
            SaveGame();
            Debug.Log("Checkpoint đạt, game đã được lưu.");
        }
    }

    // Xử lý load lại puzzle khi nhấn phím R
    private void OnReloadPuzzle(InputAction.CallbackContext context)
    {
        LoadGame();
    }
    public void SaveGame()
    {
        GameData gameData = new GameData();
        
        gameData.playerPosition = new float[] { player.transform.position.x, player.transform.position.y, player.transform.position.z };

        
        ISavable[] savableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISavable>().ToArray();

        foreach (ISavable savable in savableObjects)
        {
            ObjectData objectData = savable.GetObjectData();
            gameData.objectsData.Add(objectData);
        }

        
        SaveLoadManager.Instance.SaveGame(gameData);
    }

    public void LoadGame()
    {
        GameData gameData = SaveLoadManager.Instance.LoadGame();

        if (gameData != null &&player!= null)
        {
            player.transform.position = new Vector3(gameData.playerPosition[0], gameData.playerPosition[1], gameData.playerPosition[2]);
            
            
            ISavable[] savableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISavable>().ToArray();

            foreach (ObjectData objData in gameData.objectsData)
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
}
