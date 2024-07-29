﻿using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public static class GuFactory
{
    public static IGu CreateGu(GuConfig guTemplates)
    {
        return new BaseGu(guTemplates);
    }
}
public interface IGu
{
    void ActivateSkill(int index, ISkillVisitor visitor);
    List<Skill> GetSkills();
    GuConfig GetGuData();
}