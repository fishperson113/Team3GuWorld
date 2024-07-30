using UnityEngine;

[CreateAssetMenu(fileName = "HealSelf", menuName = "Skill System/Heal/HealSelf")]

public class HealSelf : BasicHeal
{
    public override void Accept(ISkillVisitor visitor)
    {
        visitor.Visit(this);
    }
}
