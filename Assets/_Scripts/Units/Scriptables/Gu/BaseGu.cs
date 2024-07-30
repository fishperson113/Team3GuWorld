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
<<<<<<< HEAD

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
=======
    public void SetSkills(List<Skill> skills)
    {
        guData.SetSkills(skills);
>>>>>>> c3e5728 (chore: commit before rebase)
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