using UnityEngine;

public class SkillTester : MonoBehaviour
{
    private SkillUser skillUser;
    public void Initialized(GuController gu)
    {
        skillUser = new SkillUser(gu.gu);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            skillUser.ActivateSkill(0);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            skillUser.ActivateSkill(1);
        }    
    }
}
