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
        clonedConfig.icon = guTemplates.icon;
        clonedConfig.guName = guTemplates.guName;
        return new BaseGu(clonedConfig);
    }
}
public interface IGu
{
    void ActivateSkill(int index, ISkillVisitor visitor);
    List<Skill> GetSkills();
    GuConfig GetGuData();
    void SetSkills(List<Skill> skills);
}