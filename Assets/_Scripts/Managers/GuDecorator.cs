
using System.Collections.Generic;
public abstract class GuDecorator : IGu
{
    protected IGu baseGu;

    protected GuDecorator(IGu gu)
    {
        baseGu = gu;
    }
    public void Decorate(IGu gu)
    {
        baseGu = gu;
    }
    public virtual void ActivateSkill(int index, ISkillVisitor visitor)
    {
        baseGu.ActivateSkill(index, visitor);
    }
    public List<Skill> GetSkills()
    {
        return baseGu.GetSkills();
    }
<<<<<<< HEAD
=======
    public void SetSkills(List<Skill> skills)
    {
        baseGu.SetSkills(skills);
    }
>>>>>>> c3e5728 (chore: commit before rebase)
    public GuConfig GetGuData()
    {
        return baseGu.GetGuData();
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> c3e5728 (chore: commit before rebase)
