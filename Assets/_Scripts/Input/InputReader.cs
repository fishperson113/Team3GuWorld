using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Skill skillToActivate;
    public GuController guController;
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
    }

    private void ActivateSkill(int index)
    {
        guController.ActivateSkill(index);
    }
}