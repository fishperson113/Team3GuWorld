
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
}