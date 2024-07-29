using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class BaseGu : IGu
{
    private GuConfig guData;
    public BaseGu(GuConfig gu)
    {
        guData = gu;
    }

    public List<Skill> GetSkills()
    {
        return guData.GetSkills();
    }
}