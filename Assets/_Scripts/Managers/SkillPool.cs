using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewSkillManager", menuName = "Skill System/Skill Manager")]
public class SkillPool : ScriptableObject
{
    [SerializeField] private List<Skill> skills = new List<Skill>();
    [SerializeField] private SkillEventChannel skillEventChannel; // Thêm skillEventChannel

    private ISkillVisitor skillVisitor;

    private void OnEnable()
    {
        skillVisitor = new SkillEffect(skillEventChannel);
    }
    public void ActivateSkill(int index)
    {
        if (index >= 0 && index < skills.Count)
        {
            Skill skill = skills[index];
            skill.Accept(skillVisitor); 
        }
        else
        {
            Debug.LogWarning($"Skill index {index} out of range.");
        }
    }
    public List<Skill> GetSkills()
    {
        return skills;
    }
}
