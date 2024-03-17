using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SceneLoadingShadow : MonoBehaviour
{

    [SerializeField] private RectTransform left;
    [SerializeField] private RectTransform right;
    [SerializeField] private float speed;
    
    private float s = 0f;
    private bool isClosing = false;
    private bool isOpening = false;
    
    private void Update()
    {
        if (left.sizeDelta.x < 0)
        {
            left.sizeDelta = new Vector2(0, left.sizeDelta.y);
            right.sizeDelta = new Vector2(0, right.sizeDelta.y);    
        }
        
        CloseScene();
        OpenScene();
    }

    private void CloseScene()
    {
        if (!isClosing)
        {
            return;
        }
        
        s += Time.deltaTime;
        left.sizeDelta = new Vector2(s *speed, left.sizeDelta.y);
        right.sizeDelta = new Vector2(s *speed, right.sizeDelta.y);
    }

    private void OpenScene()
    {
        if (!isOpening)
        {
            return;
        }

        if (left.sizeDelta.x > 1000)
        {
            left.sizeDelta = new Vector2(1000, left.sizeDelta.y);
            right.sizeDelta = new Vector2(1000, right.sizeDelta.y);
            s = 1000;
        }
        
        DOTween.To(() => s, x => s = x, 0f, 2.5f).OnUpdate(() =>
        {
            left.sizeDelta = new Vector2(s, left.sizeDelta.y);
            right.sizeDelta = new Vector2(s, right.sizeDelta.y);    
        });
           
    }

    public void Open()
    {
        isOpening = true;
        isClosing = false;
    }
    
    public void Close()
    {
        isOpening = false;
        isClosing = true;
    }
}
