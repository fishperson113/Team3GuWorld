public class HealSelf : BasicHeal
{
    public override void Accept(ISkillVisitor visitor)
    {
        visitor.Visit(this);
    }
}
