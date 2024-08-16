using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PlayerClone : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Stack<RewindData> backwardData;
    private Stack<RewindData> forwardData;

    private Stack<RewindData> objBackwardData;
    private Stack<RewindData> objForwardData;
    [SerializeField]private RewindableObject objInteract;

    private Material mat;

    
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        mat = spriteRenderer.material;
        mat.SetFloat("Fade", 1);
    }
    public void Rewind(Stack<RewindData> data, RewindableObject objData)
    {
        InitRewindData(data, ref this.forwardData, ref this.backwardData);
        if (objData != null)
        {
            if (objData.GetRewindData().Count > 0)
            {
                objInteract = objData;
                InitRewindData(objData.GetRewindData(), ref this.objForwardData, ref this.objBackwardData);
                Debug.Log("co gi do");
            }
            objData.GetRewindData().Clear();
        }
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (!RewindRecorder.isRecorded)
        {
            if (forwardData.Count == 0)
            {
                DeletedClone();
                backwardData.Clear();

                if(objInteract !=null)
                    objBackwardData.Clear();

                return;
            }
            RewindData newData = forwardData.Pop();
            ApplyRewindData(newData);
            backwardData.Push(newData);

            if (objInteract != null && objForwardData.Count > 0)
            {
                RewindData objData = objForwardData.Pop();
                ApplyObjectRewindData(objInteract, objData);
                objBackwardData.Push(objData);
            }
        }
        else
        {
            if (backwardData.Count > 0)
            {
                RewindData newData = backwardData.Pop();
                forwardData.Push(newData);
                ApplyRewindData(newData);

                if (objInteract != null && objBackwardData.Count > 0)
                {
                    RewindData objData = objBackwardData.Pop();
                    objForwardData.Push(objData);
                    ApplyObjectRewindData(objInteract, objData);
                }
            }
            else
            {
                DeletedClone();
                forwardData.Clear();
                if(objInteract!=null)
                    objForwardData.Clear();
            }

        }
    }
    private void ApplyRewindData(RewindData data)
    {
        transform.position = data.position;
        transform.rotation = data.rotation;
        transform.localScale = data.scale;
    }
    private void ApplyObjectRewindData(RewindableObject obj, RewindData data)
    {
        obj.transform.position = data.position;
        obj.transform.rotation = data.rotation;
        obj.transform.localScale = data.scale;
    }
    IEnumerator Disolve()
    {
        transform.parent = null;
        while (mat.GetFloat("Fade") != 0)
        {
            mat.SetFloat("Fade", Mathf.Max(mat.GetFloat("Fade") - Time.deltaTime, 0));
            yield return null;
        }
        Destroy(gameObject);
    }
    private void DeletedClone()
    {
        if (spriteRenderer.sprite != null && mat.GetFloat("Fade") == 1)
        {
            StartCoroutine(Disolve());
        }
    }
    private void InitRewindData(Stack<RewindData> data, ref Stack<RewindData> forwardData, ref Stack<RewindData> backwardData)
    {
        RewindData[] arr = new RewindData[data.Count];
        data.CopyTo(arr, 0);
        Array.Reverse(arr);
        forwardData = new Stack<RewindData>(arr);
        backwardData = new Stack<RewindData>();
    }
}