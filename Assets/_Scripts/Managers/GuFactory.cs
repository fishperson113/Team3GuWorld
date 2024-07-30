using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
public static class GuFactory
{
    public static IGu CreateGu(GuConfig guTemplates)
    {
        GuConfig clonedConfig = ScriptableObject.CreateInstance<GuConfig>();
        clonedConfig.SetSkills(guTemplates.GetSkills());
        return new BaseGu(clonedConfig);
    }
}
public interface IGu
{
<<<<<<< HEAD
    void ActivateSkill(int index, ISkillVisitor visitor);
    List<Skill> GetSkills();
    GuConfig GetGuData();
=======
    void SetSkills(List<Skill> skills);
    List<Skill> GetSkills();
    GuConfig GetGuData();
    
>>>>>>> c3e5728 (chore: commit before rebase)
}