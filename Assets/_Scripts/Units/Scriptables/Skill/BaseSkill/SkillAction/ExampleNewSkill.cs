
public class ExampleNewSkill: BasicAttack // kế thừa 1 trong 3 class BasicAttack, BasicHeal, BasicDefend
{
    public override void Accept(ISkillVisitor visitor)
    {
        visitor.Visit(this);    // thêm visit trong ISkillVisitor
    }
}
