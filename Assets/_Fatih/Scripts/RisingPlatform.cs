using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    [SerializeField] private FollowOnlyX _followOnlyX;
    [SerializeField] float risingSpeed;
    [SerializeField] GameObject platformStopper;
    [SerializeField] private float speed;
    [SerializeField] private float _maxHeight;
    
    
    bool triggeredStopper;
    private bool isRising ;
    Vector3 firstPosition;

    private void Start()
    {
        firstPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (!isRising) return;
        if (_followOnlyX.m_YPosition > _maxHeight) return;
        
        _followOnlyX.SetYPos(_followOnlyX.m_YPosition + speed + Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == platformStopper)
        {
            isRising = false;
            triggeredStopper = true;
            Invoke(nameof(PlatformPosResetter), 10f); 
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !triggeredStopper)
        {
            isRising = true;
            gameObject.transform.position += new Vector3(0f, risingSpeed);
        }
    }

    void PlatformPosResetter()
    {
        gameObject.transform.position = firstPosition;
        triggeredStopper = false;
    }

}
