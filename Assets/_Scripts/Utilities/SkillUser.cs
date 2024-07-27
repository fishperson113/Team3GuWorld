using UnityEngine;

public class SkillUser
{
    //Sử dụng để player activate skill trên người cổ trùng
    private IGu gu;
    private ISkillVisitor skillVisitor;

    public SkillUser(IGu gu)
    {
        this.gu = gu;
        skillVisitor = new SkillEffect();

        if (gu == null)
        {
            Debug.LogError("Gu is not assigned.");
        }
    }

    public void ActivateSkill(int index)
    {
        if (gu != null)
        {
            gu.ActivateSkill(index, skillVisitor);
        }
    }
}
