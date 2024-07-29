using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    [SerializeField] private SkillEventChannel skillEventChannel;
    [SerializeField] private GuEventChannel guEventChannel;
    [SerializeField] private IntEventChannel intEventChannel;
    public void PublishSkillEvent(Skill skill)
    {
        skillEventChannel.Invoke(skill);
    }
    public void PublishGuEvent(IGu gu)
    {
        guEventChannel.Invoke(gu);
    }
    public void PublishIntEvent(int value)
    {
        intEventChannel.Invoke(value);
    }
}
