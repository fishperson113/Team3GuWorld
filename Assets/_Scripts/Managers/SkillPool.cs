using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewSkillManager", menuName = "Skill System/Skill Manager")]
public class SkillPool : ScriptableObject
{
    [SerializeField] private List<Skill> skills = new List<Skill>();

<<<<<<< HEAD
    private ISkillVisitor skillVisitor;

    private void OnEnable()
    {
        skillVisitor = new SkillEffect();
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
=======
>>>>>>> c3e5728 (chore: commit before rebase)
    public List<Skill> GetSkills()
    {
        return skills;
    }
}