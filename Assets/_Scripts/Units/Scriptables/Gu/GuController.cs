using System.Collections.Generic;
using UnityEngine;

public class GuController : MonoBehaviour
{
    public IGu gu { get; set; }

    public void ActivateSkill(int index, ISkillVisitor visitor)
    {
        gu.ActivateSkill(index, visitor);
    }

    public List<Skill> GetSkills()
    {
        return gu.GetSkills();
    }
}