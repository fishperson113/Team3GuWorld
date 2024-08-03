using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class KeyboardManager : Singleton<KeyboardManager>
{
    public PlayerInput input;
    public static event Action rebindComplete, rebindCancel, waitingForRebind;
    public static event Action<InputAction, int> rebindStarted;

    protected override void Awake()
    {
        base.Awake();

        input = new PlayerInput();
        LoadBindingOveride("normal/Walk");
        LoadBindingOveride("normal/Jump");
        LoadBindingOveride("normal/Rewind");
        LoadBindingOveride("normal/Interact");
        LoadBindingOveride("normal/RightArrow");
        LoadBindingOveride("normal/LeftArrow");
        LoadBindingOveride("normal/UpArrow");
        LoadBindingOveride("normal/DownArrow");
    }
    public void DoRebind(string actionName, int bindingIndex, List<KeyboardRebind> otherKeys)
    {
        InputAction action = input.asset.FindAction(actionName);
        if (action == null || action.bindings.Count <= bindingIndex || bindingIndex < 0)
        {
            return;
        }
        action.Disable();

        waitingForRebind?.Invoke();

        var rebind = action.PerformInteractiveRebinding(bindingIndex);
        rebind.OnComplete(operation =>
        {
            action.Enable();
            operation.Dispose();
            RemoveDuplicate(actionName, bindingIndex, otherKeys);
            SaveBindingOveride(action);
            rebindComplete?.Invoke();
        });

        rebind.OnCancel(operation =>
        {
            action.Enable();
            operation.Dispose();
            action.ApplyBindingOverride(bindingIndex, "");
            SaveBindingOveride(action);
            rebindCancel?.Invoke();
        });
        rebind.WithCancelingThrough("<KeyBoard>/escape");
        rebindStarted?.Invoke(action, bindingIndex);
        rebind.Start();
    }

    public string getBindingName(string actionName, int bindingIndex)
    {
        if (input == null) input = new PlayerInput();
        InputAction action = input.asset.FindAction(actionName);
        return action.GetBindingDisplayString(bindingIndex);
    }
    private void SaveBindingOveride(InputAction action)
    {
        for (int i = 0; i < action.bindings.Count; ++i)
        {
            if (i == 0 && action.bindings[0].isComposite) continue;
            if (string.IsNullOrEmpty(action.bindings[i].overridePath))
            {
                PlayerPrefs.SetString(action.actionMap + action.name + i, "empty");
            }
            else
            {
                PlayerPrefs.SetString(action.actionMap + action.name + i, action.bindings[i].overridePath);
            }
        }
    }
    public void LoadBindingOveride(string actionName)
    {
        if (input == null) input = new PlayerInput();
        InputAction action = input.asset.FindAction(actionName);

        for (int i = 0; i < action.bindings.Count; ++i)
        {
            if (i == 0 && action.bindings[0].isComposite) continue;
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString(action.actionMap + action.name + i)))
            {
                if (PlayerPrefs.GetString(action.actionMap + action.name + i) == "empty")
                {
                    action.ApplyBindingOverride(i, "");
                }
                else
                {
                    action.ApplyBindingOverride(i, PlayerPrefs.GetString(action.actionMap + action.name + i));
                }
            }
        }
    }
    public void ResetBinding(string actionName, int bindingIndex)
    {
        InputAction action = input.asset.FindAction(actionName);

        if (action == null || action.bindings.Count <= bindingIndex)
        {
            return;
        }
        action.RemoveBindingOverride(bindingIndex);
        action.ApplyBindingOverride(bindingIndex, action.bindings[bindingIndex].path);
        SaveBindingOveride(action);
    }
    public void RemoveDuplicate(string actionName, int bindingIndex, List<KeyboardRebind> otherKeys)
    {
        foreach (KeyboardRebind key in otherKeys)
        {
            InputAction keyAction = input.asset.FindAction(key.actionName);
            InputAction mainAction = input.asset.FindAction(actionName);

            string keyName = getBindingName(key.actionName, key.bindingIndex);
            string mainName = getBindingName(actionName, bindingIndex);

            if (keyAction.bindings[0].isComposite)
            {
                keyName = keyName.Remove(0, 5);
            }
            if (mainAction.bindings[0].isComposite)
            {
                mainName = mainName.Remove(0, 5);
            }

            if (mainName == keyName && !string.IsNullOrEmpty(mainName))
            {
                keyAction.ApplyBindingOverride(key.bindingIndex, "");
                SaveBindingOveride(keyAction);
            }
        }
    }
}