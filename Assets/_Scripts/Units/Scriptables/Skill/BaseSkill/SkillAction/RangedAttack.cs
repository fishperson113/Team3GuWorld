
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttack", menuName = "Skill System/Attacks/Ranged")]
public class RangedAttack : BasicAttack
{
    public override void Accept(ISkillVisitor visitor)
    {
        visitor.Visit(this);
    }
}
