using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformDirection
{
    Left,
    Right
}

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _left;
    [SerializeField] private Transform _right;
    [SerializeField] private float _speed;
    
    private PlatformDirection m_platformDirection = PlatformDirection.Right;
    private Vector3 m_leftStartPos;
    private Vector3 m_rightStartPos;


    private void Awake()
    {
        m_leftStartPos = _left.transform.position;
        m_rightStartPos = _right.transform.position;
    }

    private void Update()
    {
        FixReferencePositions();
        CheckDirection();
        Move();
    }

    private void CheckDirection()
    {
        if (m_platformDirection == PlatformDirection.Right && transform.position.x > _right.position.x)
        {
            m_platformDirection = PlatformDirection.Left;
        }
        
        if (m_platformDirection == PlatformDirection.Left && transform.position.x < _left.position.x)
        {
            m_platformDirection = PlatformDirection.Right;
        }
    }
    
    private void Move()
    {
        if (m_platformDirection == PlatformDirection.Right)
        {
            transform.position += Vector3.right * (_speed * Time.deltaTime);
            return;
        }
        
        transform.position += Vector3.left * (_speed * Time.deltaTime);
    }

    private void FixReferencePositions()
    {
        _left.transform.position = m_leftStartPos;
        _right.transform.position = m_rightStartPos;
    }

}
