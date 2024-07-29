using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class BaseGu : IGu
{
    public GuConfig guData { get; private set; }
    public BaseGu(GuConfig gu)
    {
        guData = gu;
    }

    public void ActivateSkill(int index, ISkillVisitor visitor)
    {
        if (index >= 0 && index < guData.GetSkills().Count)
        {
            guData.GetSkills()[index].Accept(visitor);
        }
        else
        {
            Debug.LogWarning($"Skill index {index} out of range.");
        }
    }
    public List<Skill> GetSkills()
    {
        return guData.GetSkills();
    }
    public GuConfig GetGuData()
    {
        return guData;
    }
}