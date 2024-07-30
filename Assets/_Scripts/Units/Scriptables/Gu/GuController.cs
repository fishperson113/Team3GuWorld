using System.Collections.Generic;
using UnityEngine;

public class GuController : MonoBehaviour
{
    public IGu gu { get; set; }
    public SkillEventChannel ActiveSkill;
    public void ActivateSkill(int index)
    {
        if (index >= 0 && index < gu.GetSkills().Count)
        {
            Skill skill = gu.GetSkills()[index];
            // Phát sự kiện kỹ năng sử dụng qua SkillEventChannel
            ActiveSkill.Invoke(skill);
        }
        else
        {
            Debug.LogWarning($"Skill index {index} out of range.");
        }
    }
}