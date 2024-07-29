using System.Collections.Generic;
using UnityEngine;

public class GuController : MonoBehaviour
{
    public IGu gu { get; set; }
    public void ActivateSkill(int index)
    {
        if (index >= 0 && index < gu.GetSkills().Count)
        {
            //gu.GetSkills()[index].Accept(new SkillEffect());
            Skill skill = gu.GetSkills()[index];
            // Phát sự kiện kỹ năng sử dụng qua SkillEventChannel
            EventManager.Instance.PublishSkillEvent(skill);
        }
        else
        {
            Debug.LogWarning($"Skill index {index} out of range.");
        }
    }

    public List<Skill> GetSkills()
    {
        return gu.GetSkills();
    }
}