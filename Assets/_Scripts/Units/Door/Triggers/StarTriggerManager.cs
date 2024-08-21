using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTriggerManager : MonoBehaviour
{
    [SerializeField] private GameObject doorA;  // Cửa cần quản lý
    [SerializeField] private List<StarTrigger> starTriggers;

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
        if(!RewindRecorder.isRecorded) {
            starTriggers[0].ResetTrigger(); //isShot=false
            starTriggers[0].SetActive(true);
            return; 
        }
        else
        {
            StartCoroutine(RewindCheck());
            for (int i = 0; i < starTriggers.Count; i++)
            {
                starTriggers[i].ResetTrigger(); //isShot=false
            }
            starTriggers[StarShot].SetActive(true);
        }
    }
    private void HandleStarTrigger()
    {
        StarShot++;
        if (StarShot < starTriggers.Count)
        {
            starTriggers[StarShot].SetActive(true);
        }
        else
        {
            // Nếu tất cả ngôi sao đã bị bắn, mở cửa
            door.OpenDoor();
        }
    }
    private IEnumerator RewindCheck()
    {
        while(true)
        {
            if(!BulletManager.Instance.IsAnyBulletOnScreen())
            {
                StarShot = 1;
                for (int i = 0; i < starTriggers.Count; i++)
                {
                    if (i == 0 && StarShot != starTriggers.Count)
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
