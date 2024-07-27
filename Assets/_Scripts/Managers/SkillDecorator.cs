using System.Collections.Generic;

public class SkillDecorator : GuDecorator
{
    private SkillPool skillPool;
    public SkillDecorator(IGu gu, SkillPool skillPool) : base(gu)
    {
        this.skillPool = skillPool;
        List<Skill> skillsToAdd = GetRandomSkillsFromPool();
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
    private List<Skill> GetRandomSkillsFromPool()
    {
        List<Skill> randomSkills = new List<Skill>();
        int skillCount = 4; // Số kỹ năng ngẫu nhiên

        for (int i = 0; i < skillCount; i++)
        {
            int randomSkillIndex = UnityEngine.Random.Range(0, skillPool.GetSkills().Count);
            Skill randomSkill = skillPool.GetSkills()[randomSkillIndex];

            if (!randomSkills.Contains(randomSkill))
            {
                randomSkills.Add(randomSkill);
            }
        }

        return randomSkills;
    }
}