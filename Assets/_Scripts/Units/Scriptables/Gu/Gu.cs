using UnityEngine;
using System.Collections.Generic;
using UnityEngine.U2D;
[CreateAssetMenu(fileName = "Gu", menuName = "Gu System/Gu")]
public class Gu : ScriptableObject
{
    [SerializeField] private string guName;
    [SerializeField] private Sprite icon;
    [SerializeField] private List<Skill> skills = new List<Skill>();

    public void Initialize(string name, Sprite sprite, List<Skill> skillList)
    {
        guName = name;
        icon = sprite;
        skills = new List<Skill>(skillList);
    }
    public void ActivateSkill(int index, ISkillVisitor visitor)
    {
        if (index >= 0 && index < skills.Count)
        {
            skills[index].Accept(visitor);
        }
        else
        {
            Debug.LogWarning($"Skill index {index} out of range.");
        }
    }
    public void AddSkill(Skill skill)
    {
        if (!skills.Contains(skill))
        {
            skills.Add(skill);
        }
    }
    public List<Skill> GetSkills()
    {
        return skills;
    }

    public Sprite getGuSprite()
    {
        return icon;
    }

}
