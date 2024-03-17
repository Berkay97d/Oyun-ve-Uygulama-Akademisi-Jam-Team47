using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadingShadow : MonoBehaviour
{

    [SerializeField] private RectTransform left;
    [SerializeField] private RectTransform right;
    [SerializeField] private float speed;
    
    private float s = 0f;
    private bool can = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            can = true;
        }

        if (!can)
        {
            return;
        }
        
        s += Time.deltaTime;
        left.sizeDelta = new Vector2(s *speed, left.sizeDelta.y);
        right.sizeDelta = new Vector2(s *speed, right.sizeDelta.y);
    }
}
