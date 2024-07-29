using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    [SerializeField] private SkillEventChannel skillEventChannel;
    [SerializeField] private GuEventChannel guEventChannel;
    public void PublishSkillEvent(Skill skill)
    {
        skillEventChannel.Invoke(skill);
    }
    public void PublishGuEvent(IGu gu)
    {
        guEventChannel.Invoke(gu);
    }
}
