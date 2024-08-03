using UnityEngine;

public class InputReader : MonoBehaviour
{
    public GuController guController;
    public EventChannel[] togglerEventChannel;
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
        if(Input.GetKeyDown(KeyCode.Q)) // DevUI
        {
            togglerEventChannel[0].Invoke(new Empty());
        }    
        if(Input.GetKeyDown(KeyCode.E))// GuView
        {
            togglerEventChannel[1].Invoke(new Empty());
        }
        if (Input.GetKeyDown(KeyCode.I)) // Inventory
        {
            togglerEventChannel[2].Invoke(new Empty());
        }
    }
    public void SetGuController(IGu gu)
    {
        guController.gu = gu;
    }
    private void ActivateSkill(int index)
    {
       guController.ActivateSkill(index);
    }
}