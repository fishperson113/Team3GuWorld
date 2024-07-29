using UnityEngine;
public class SkillEffect : ISkillVisitor
{
    public void Visit(RangedAttack skill)
    {
        PerformRangedAttack();
    }
    public void Visit(ForceField skill)
    {
        PerformForceField();
    }
    public void Visit(HealSelf skill)
    {
        PerformHealSelf();
    }
    public void Visit(ExampleNewSkill skill)
    {
        Debug.Log("Example New Skill"); // có thể đóng gói hàm để gọi hoặc gọi trực tiếp
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
