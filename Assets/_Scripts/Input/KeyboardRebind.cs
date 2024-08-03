using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class KeyboardRebind : MonoBehaviour
{
    public InputActionReference inputActionReference;

    [HideInInspector] public string actionName;
    public TextMeshProUGUI rebindText;
    public UnityEngine.UI.Button rebindButton;
    public int selectedBinding;
    [HideInInspector] public int bindingIndex;
    public TextMeshProUGUI waitingText;
    public Image imageCover;
    public Image ArrowImage;
    public Image longImageCover;
    public TextMeshProUGUI longRebindText;
    public TextMeshProUGUI unmmapedText;
    public List<KeyboardRebind> otherKeys;
    public List<InputActionReference> dependenceAction;
    private void OnEnable()
    {
        rebindButton.onClick.AddListener(() => { DoRebind(); ShowWaitingText(); });
        if (inputActionReference != null)
        {
            KeyboardManager.Instance.LoadBindingOveride(actionName);
            GetBindingInfo();
            UpdateUI();
            UpdateDependence();
        }
        KeyboardManager.rebindComplete += HideWaitingText;
        KeyboardManager.rebindCancel += HideWaitingText;
        KeyboardManager.rebindCancel += UpdateUI;
        KeyboardManager.rebindCancel += UpdateDependence;
        KeyboardManager.rebindComplete += UpdateUI;
        KeyboardManager.rebindComplete += UpdateDependence;
    }
    private void OnDisable()
    {
        KeyboardManager.rebindComplete -= UpdateUI;
        KeyboardManager.rebindComplete -= HideWaitingText;
        KeyboardManager.rebindCancel -= HideWaitingText;
        KeyboardManager.rebindCancel -= UpdateUI;
        KeyboardManager.rebindCancel -= UpdateDependence;
        KeyboardManager.rebindComplete -= UpdateDependence;
    }
    private void OnValidate()
    {
        if (inputActionReference == null)
        {
            return;
        }
        GetBindingInfo();
        UpdateUI();
    }
    private void GetBindingInfo()
    {
        if (inputActionReference.action != null)
        {
            actionName = inputActionReference.action.name;
        }
        if (inputActionReference.action.bindings.Count > selectedBinding)
        {
            bindingIndex = selectedBinding;
        }
    }
    private void UpdateUI()
    {
        if (Application.isPlaying)
        {
            HandleTextUI(KeyboardManager.Instance.getBindingName(actionName, bindingIndex));
        }
        else
        {
            HandleTextUI(inputActionReference.action.GetBindingDisplayString(bindingIndex));
        }
    }
    private void UpdateDependence()
    {
        foreach (InputActionReference dependInput in dependenceAction)
        {
            KeyboardManager.Instance.input.FindAction(dependInput.action.name).ApplyBindingOverride(0, KeyboardManager.Instance.input.FindAction(actionName).bindings[bindingIndex]);
        }
    }
    private void DoRebind()
    {
        KeyboardManager.Instance.DoRebind(actionName, bindingIndex, otherKeys);
    }
    private void ShowWaitingText()
    {
        imageCover.enabled = false;
        rebindText.enabled = false;
        longRebindText.enabled = false;
        longImageCover.enabled = false;
        waitingText.enabled = true;
        ArrowImage.enabled = false;
        unmmapedText.enabled = false;
    }
    private void HideWaitingText()
    {
        waitingText.enabled = false;
    }
    private void HandleTextUI(string text)
    {
        if (inputActionReference.action.bindings[0].isComposite)
        {
            text = text.Remove(0, 5);
        }
        if (string.IsNullOrEmpty(text))
        {
            ArrowImage.enabled = false;
            rebindText.enabled = false;
            imageCover.enabled = false;
            longImageCover.enabled = false;
            longRebindText.enabled = false;
            unmmapedText.enabled = true;
        }
        else if (text == "Up")
        {
            ArrowImage.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
            ArrowImage.enabled = true;
            rebindText.enabled = false;
            imageCover.enabled = true;
            longImageCover.enabled = false;
            longRebindText.enabled = false;
            unmmapedText.enabled = false;
        }
        else if (text == "Down")
        {
            ArrowImage.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 270);
            ArrowImage.enabled = true;
            rebindText.enabled = false;
            imageCover.enabled = true;
            longImageCover.enabled = false;
            longRebindText.enabled = false;
            unmmapedText.enabled = false;
        }
        else if (text == "Left")
        {
            ArrowImage.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 180);
            ArrowImage.enabled = true;
            rebindText.enabled = false;
            imageCover.enabled = true;
            longImageCover.enabled = false;
            longRebindText.enabled = false;
            unmmapedText.enabled = false;
        }
        else if (text == "Right")
        {
            ArrowImage.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
            ArrowImage.enabled = true;
            rebindText.enabled = false;
            imageCover.enabled = true;
            longImageCover.enabled = false;
            longRebindText.enabled = false;
            unmmapedText.enabled = false;
        }
        else if (text.Length >= 2)
        {
            ArrowImage.enabled = false;
            longImageCover.enabled = true;
            longRebindText.enabled = true;
            rebindText.enabled = false;
            imageCover.enabled = false;
            unmmapedText.enabled = false;
        }
        else
        {
            ArrowImage.enabled = false;
            longImageCover.enabled = false;
            longRebindText.enabled = false;
            rebindText.enabled = true;
            imageCover.enabled = true;
            unmmapedText.enabled = false;
        }
        rebindText.text = text;
        longRebindText.text = text;
    }
    public void resetBinding()
    {
        KeyboardManager.Instance.ResetBinding(actionName, bindingIndex);
        UpdateUI();
        UpdateDependence();
    }
}