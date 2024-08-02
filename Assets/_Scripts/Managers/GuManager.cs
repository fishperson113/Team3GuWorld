using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuManager : Singleton<GuManager>
{
    [SerializeField] private SkillPool skillPool;
    [SerializeField] private GuConfig baseGuConfig;
    public GuEventChannel SpawnGu;
    public IGu CreateGu()
    {
        IGu blankGu = GuFactory.CreateGu(baseGuConfig);

        IGu decoratedGu = new SkillDecorator(blankGu, skillPool.GetSkills());

        SpawnGu.Invoke(decoratedGu);
        return decoratedGu;
    }
    public IGu CreateDefaultInstance()
    {
        return GuFactory.CreateGu(baseGuConfig);
    }    
    public IGu BreedGu(IGu parent1, IGu parent2)
    {
        Skill skill1 = GetRandomSkill(parent1.GetSkills());
        Skill skill2 = GetRandomSkill(parent2.GetSkills());

        List<Skill> childSkills =new List<Skill> {skill1, skill2 };

        IGu blankGu = GuFactory.CreateGu(baseGuConfig);

        IGu decoratedGu = new SkillDecorator(blankGu, childSkills);

        decoratedGu.GetGuData().guName = "Breed";
        SpawnGu.Invoke(decoratedGu);
        return decoratedGu;
    }

    private Skill GetRandomSkill(List<Skill> skills)
    {
        if (skills == null || skills.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, skills.Count);
        return skills[randomIndex];
    }
}