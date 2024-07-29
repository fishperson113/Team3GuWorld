using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IVisitable
{
    void Accept(ISkillVisitor visitor);
}
public abstract class Skill : ScriptableObject, IVisitable
{
    [SerializeField] protected string skillName;
    [SerializeField] protected string description;
    [SerializeField] protected Sprite skillIcon;
    

    public abstract void Accept(ISkillVisitor visitor);
}
