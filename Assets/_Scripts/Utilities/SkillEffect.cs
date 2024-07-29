using UnityEngine;
public class SkillEffect : ISkillVisitor
{
    private SkillEventChannel skillEventChannel;
    public SkillEffect(SkillEventChannel channel)
    {
        skillEventChannel = channel;
    }
    public void ExecuteSkill(Skill skill)
    {
        skill.Accept(this);
    }
    public void Visit(RangedAttack skill)
    {
        PerformRangedAttack();
        skillEventChannel.Invoke(skill);
    }
    public void Visit(ForceField skill)
    {
        PerformForceField();
        skillEventChannel.Invoke(skill);
    }
    public void Visit(HealSelf skill)
    {
        PerformHealSelf();
        skillEventChannel.Invoke(skill);
    }
    public void Visit(ExampleNewSkill skill)
    {
        Debug.Log("Example New Skill"); // có thể đóng gói hàm để gọi hoặc gọi trực tiếp
        skillEventChannel.Invoke(skill);
    }
    void PerformRangedAttack()
    {
        Transform firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = firePoint.position;
        Vector2 direction = Helpers.CalculateDirection(mousePosition, firePointPosition);
        ShootProjectile.Shoot(direction, firePoint);
    }
    void PerformForceField()
    {
        Debug.Log("FF");
    }
    void PerformHealSelf()
    {
        Debug.Log("Heal Self");
    }
}
