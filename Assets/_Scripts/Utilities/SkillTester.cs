using UnityEngine;

public class SkillTester : MonoBehaviour
{
    public GuController guController;
    private void Update()
    {
        if (guController != null && guController.gu != null)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ActivateSkill(0);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                ActivateSkill(1);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                ActivateSkill(2);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                ActivateSkill(3);
            }
        }

    }
    private void ActivateSkill(int index)
    {
        guController.ActivateSkill(index);
    }
}
