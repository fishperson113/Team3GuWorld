
public interface ISkillVisitor
{
    void Visit(RangedAttack attack);
    void Visit(ForceField skill);
    void Visit(HealSelf skill);
    void Visit(ExampleNewSkill skill); // triển khai nó trong SkillEffectVisitor
}


