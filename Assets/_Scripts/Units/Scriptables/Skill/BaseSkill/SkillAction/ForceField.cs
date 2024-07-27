using UnityEngine;
[CreateAssetMenu(fileName = "ForceField", menuName = "Skill System/Defend/Force Field")]

public class ForceField : BasicDefend
{
    public override void Accept(ISkillVisitor visitor)
    {
        visitor.Visit(this);
    }
}
