using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public enum CatState
{
    Idle,
    Walk
}

public class CatController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _animator;
    
    
    private float xOffset;
    private CatState catState;
    

    private void Start()
    {
        xOffset = _player.transform.position.x - transform.position.x;
    }

    private void Update()
    {
        CheckState();
    }

    private void FixedUpdate()
    {
        if (catState == CatState.Walk)
        {
            Move();
        }
    }

    private void CheckState()
    {
        if (Math.Abs(_player.transform.position.x - transform.position.x) > 3 && catState == CatState.Idle)
        {
            SetCatState(CatState.Walk);
            return;
        }

        if (catState == CatState.Walk && Math.Abs(_player.transform.position.x - transform.position.x) < 3)
        {
            SetCatState(CatState.Idle);   
        }
    }

    private void SetCatState(CatState c)
    {
        catState = c;

        Debug.Log(c);

        if (c == CatState.Idle)
        {
            _animator.SetBool("isWalking", false);
        }
        else
        {
            _animator.SetBool("isWalking", true);
        }
    }

    private void Move()
    {
        var direction = Vector3.Normalize(_player.position - transform.position);
        var randomMoveSpeed = Random.Range(2, 9);
        direction.y = 0;
        transform.position += direction * (randomMoveSpeed * Time.deltaTime);
    }
}
