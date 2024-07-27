using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "BaseGu", menuName = "Gu System/BaseGu")]
public class GuConfig : ScriptableObject
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
    public List<Skill> GetSkills()
    {
        return skills;
    }
}

