using UnityEngine;

public class SkillTester : MonoBehaviour
{
    

    public void UseSkill(Skill skill)
    {
        if (skill == null)
        {
            Debug.LogWarning("Skill is null");
            return;
        }

        var skillEffect = new SkillEffect();
        skillEffect.ExecuteSkill(skill);
    }
}
