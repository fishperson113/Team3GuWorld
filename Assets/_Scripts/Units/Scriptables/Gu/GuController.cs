using System.Collections.Generic;
using UnityEngine;

public class GuController : MonoBehaviour
{
    public IGu gu { get; set; }
    public SkillEventChannel skillEventChannel;
    public void ActivateSkill(int index)
    {
        gu.ActivateSkill(index, new SkillEffect(skillEventChannel));
    }

    public List<Skill> GetSkills()
    {
        return gu.GetSkills();
    }
}