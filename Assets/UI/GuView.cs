using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GuView: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI guNameText;
    [SerializeField] private Image guIconImage;
    [SerializeField] private Transform skillsPanel;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void UpdateView(IGu gu)
    {
        GuConfig guConfig = gu.GetGuData(); 
        guNameText.text = guConfig.guName;
        guIconImage.sprite = guConfig.icon;
    }
    public void SetActive(Empty empty)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
