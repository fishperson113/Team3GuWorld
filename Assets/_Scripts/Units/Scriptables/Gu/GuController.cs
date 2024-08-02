using System.Collections.Generic;
using UnityEngine;
public class GuController : MonoBehaviour
{
    public IGu gu;
    public SkillEventChannel ActiveSkill;
    private void Start()
    {
        LoadImage();
    }
    private void LoadImage()
    {
        if(gu == null)
        {
            Debug.LogWarning("Gu data is not set.");
            return;
        }

        GuConfig guData = gu.GetGuData();
        if (guData == null)
        {
            Debug.LogWarning("GuConfig data is null.");
            return;
        }

        if (guData.icon == null)
        {
            Debug.LogWarning("GuConfig icon is null.");
            return;
        }

        SpriteRenderer guImage = this.GetComponent<SpriteRenderer>();
        if (guImage == null)
        {
            Debug.LogWarning("SpriteRenderer component not found.");
            return;
        }

        guImage.sprite = guData.icon;
        Debug.Log("Icon set to: " + guData.icon.name);
    }

    public void ActivateSkill(int index)
    {
        if (index >= 0 && index < gu.GetSkills().Count)
        {
            Skill skill = gu.GetSkills()[index];
            // Phát sự kiện kỹ năng sử dụng qua SkillEventChannel
            ActiveSkill.Invoke(skill);
        }
        else
        {
            Debug.LogWarning($"Skill index {index} out of range.");
        }
    }
}