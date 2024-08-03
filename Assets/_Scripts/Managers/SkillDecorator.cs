using System.Collections.Generic;

public class SkillDecorator : GuDecorator
{
    public SkillDecorator(IGu gu, List<Skill> skillsToAdd) : base(gu)
    {
        AddSkills(skillsToAdd);
    }
    private void AddSkills(List<Skill> skills)
    {
        List<Skill> existingSkills = baseGu.GetSkills();
        foreach (var skill in skills)
        {
            if (!existingSkills.Contains(skill))
            {
                existingSkills.Add(skill);
            }
        }
    }
}