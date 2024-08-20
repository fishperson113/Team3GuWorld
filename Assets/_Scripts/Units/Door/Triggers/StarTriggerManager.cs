using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTriggerManager : MonoBehaviour
{
    [SerializeField] private GameObject doorA;  // Cửa cần quản lý
    [SerializeField] private List<StarTrigger> starTriggers; // Danh sách các pressure plates

    private IDoor door;
    private int StarShot = 1;
    private void Awake()
    {
        door = doorA.GetComponent<IDoor>();
        for(int i=0;i<starTriggers.Count;i++)
        {
            if (i!=0)
            {
                starTriggers[i].onStarTriggeredShot += HandleStarTrigger;
                starTriggers[i].gameObject.SetActive(false);
            
            }
            else
            {
                starTriggers[i].onStarTriggeredShot += InitPuzzle;
                
            }
        }
    }
    private void InitPuzzle()
    {
        for (int i=0;i<starTriggers.Count;i++)
        {
            if (i>0)
            {
                starTriggers[i].gameObject.SetActive(true);
                StartCoroutine(RewindCheck());
            }    
        }
    }
    private void HandleStarTrigger()
    {
        StarShot++;
        if (StarShot == starTriggers.Count)
        {
            door.OpenDoor();
        }
    }
    private IEnumerator RewindCheck()
    {
        while(true)
        {
            if(!RewindRecorder.isRecorded)
            {
                for (int i = 0; i < starTriggers.Count; i++)
                {
                    if (i == 0)
                    {
                        starTriggers[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        starTriggers[i].gameObject.SetActive(false);
                    }
                }
                yield break; 
            }
        yield return null;
        }
    }    
}
