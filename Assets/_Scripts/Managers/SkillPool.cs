using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewSkillManager", menuName = "Skill System/Skill Manager")]
public class SkillPool : ScriptableObject
{
    [SerializeField] private List<Skill> skills = new List<Skill>();

    public List<Skill> GetSkills()
    {
        return skills;
    }
}