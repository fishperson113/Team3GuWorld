using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevUI : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void CreateGu()
    {
        GuManager.Instance.CreateGu();
    }
    public void SetActive(Empty empty)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
