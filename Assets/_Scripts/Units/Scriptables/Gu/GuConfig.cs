﻿using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "BaseGu", menuName = "Gu System/BaseGu")]
public class GuConfig : ScriptableObject
{
    public string guName { get; set; }
    public Sprite icon { get; private set; }
    [SerializeField] private List<Skill> skills = new List<Skill>();

    public void SetSkills(List<Skill> skills)
    {
        this.skills = new List<Skill>(skills);
    }
    public List<Skill> GetSkills()
    {
        return skills;
    }
    public Sprite GetGuSprite()
    {
        return icon;
    }    
  
}

