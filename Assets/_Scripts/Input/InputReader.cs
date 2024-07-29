using UnityEngine;

public class InputReader : MonoBehaviour
{
    public GameObject guPrefab;
   /*// public GuController guController;
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
    }

    private void ActivateSkill(int index)
    {
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
}