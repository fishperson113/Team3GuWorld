using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class PlayerClone : MonoBehaviour
{
    private RewindRecorder rewindRecorder;

    private SpriteRenderer spriteRenderer;

    private Stack<RewindData> forwardData;
    private Stack<RewindData> backwardData;
    private Queue<RewindData> rewindData;

    private Material mat;
    private float appearTime;
    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rewindRecorder = GameObject.FindGameObjectWithTag("Player").GetComponent<RewindRecorder>();
    }
    private void Start()
    {
        mat = spriteRenderer.material;
        mat.SetFloat("Fade", 1);
    }
    public void rewind(Stack<RewindData> data)
    {
        rewindData = new Queue<RewindData>();
        foreach (RewindData item in data)
        {
            rewindData.Enqueue(item);
        }
        appearTime = data.Count * Time.fixedDeltaTime;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
    }
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (!rewindRecorder.isRecorded)
        {
            if (rewindData.Count==0)
            {
                deletedClone();
                return;
            }
            RewindData newData = rewindData.Dequeue();
            gameObject.transform.position = newData.position;
            gameObject.transform.localScale = newData.scale;
        }
        
    }
    IEnumerator disolve()
    {
        transform.parent = null;
        while (mat.GetFloat("Fade") != 0)
        {
            mat.SetFloat("Fade", Mathf.Max(mat.GetFloat("Fade") - Time.deltaTime, 0));
            yield return null;
        }
        Destroy(gameObject);
    }
    private void deletedClone()
    {
        if (spriteRenderer.sprite != null && mat.GetFloat("Fade") == 1)
        {
            StartCoroutine(disolve());
        }
    }
}