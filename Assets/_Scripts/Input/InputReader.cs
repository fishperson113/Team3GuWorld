using UnityEngine;

public class InputReader : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject guPrefab;
   /*// public GuController guController;
=======
    public GuController guController;
    public EventChannel togglerEventChannel;
    public GuEventChannel EquipGu;
    private IGu guToEquip;
    private IGu currentGu;
>>>>>>> c3e5728 (chore: commit before rebase)
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            ActivateSkill(0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ActivateSkill(1);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            ActivateSkill(2);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            CheckEquipGu();
            togglerEventChannel.Invoke(new Empty());
        }    
    }
    private void CheckEquipGu()
    {
        if(guController!=null)
        {
            Equip(guController.gu);
        }
        else
        {
            if (currentGu != null && currentGu == guToEquip)
            {
                return;
            }

            // Unregister the current gu if it is not the gu to equip
            if (currentGu != null && currentGu != guToEquip)
            {
                UnregisterGu(currentGu);
            }

            // Create a DefaultInstance for display
            guToEquip = GuManager.Instance.CreateDefaultInstance();
            Equip(guToEquip);
        }
    }    

    private void ActivateSkill(int index)
    {
<<<<<<< HEAD
      //  guController.ActivateSkill(index);
    }*/
   public void ActivateSkill(IGu Gu)
    {
        GameObject guObject = Instantiate(guPrefab);
        GuController guController = guObject.GetComponent<GuController>();
        guController.gu = Gu;
        if (Input.GetKeyDown(KeyCode.X))
            guController.ActivateSkill(0);
    }    
=======
        guController.ActivateSkill(index);
    }

    private void Equip(IGu gu)
    {
        currentGu = gu;
        EquipGu.Invoke(currentGu);
    }

    private void UnregisterGu(IGu gu)
    {
        currentGu = null;
    }
>>>>>>> c3e5728 (chore: commit before rebase)
}