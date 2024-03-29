﻿using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Animator[] _dashAnimators;

        private PlayerHealthSystem m_playerHealthSystem;
        private CharacterMovement m_characterMovement;
        private PlayerAttacker m_playerAttacker;
        private bool isMoving;

        private void Start()
        {
            m_characterMovement = GetComponent<CharacterMovement>();
            m_playerHealthSystem = GetComponent<PlayerHealthSystem>();
            m_playerAttacker = GetComponent<PlayerAttacker>();
            
            StartCoroutine(CheckIsMoving());
            
            m_playerHealthSystem.OnDeath += OnDeath;
            m_playerAttacker.OnPlayerAttack += OnPlayerAttack;
        }

        private void OnPlayerAttack()
        {
            _animator.SetTrigger("onAttack");
        }

        private void OnDestroy()
        {
            m_playerHealthSystem.OnDeath -= OnDeath;
            m_playerAttacker.OnPlayerAttack -= OnPlayerAttack;
        }

        private void Update()
        {
            if (m_playerHealthSystem.GetIsDead()) return;
            
            CheckRun();
            CheckGrounded();
            CheckVerticalSpeed();
            
            CheckDashRun();
            CheckDashGrounded();
            CheckDashVerticalSpeed();
        }

        private void OnDeath()
        {
            _animator.SetTrigger("onDeath");
        }
        
        private IEnumerator CheckIsMoving()
        {
            while (true)
            {
                yield return null;
                
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                {
                    isMoving = true;
                }
                else
                {
                    yield return new WaitForSeconds(0.01f);
                    
                    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
                    {
                        continue;
                    }
                    
                    isMoving = false;
                }
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void CheckRun()
        {
            var absSpeed = Math.Abs(m_characterMovement.GetHorizontalSpeed());
            _animator.SetBool("isMoving", isMoving);   
        }

        private void CheckGrounded()
        {
            var isG = m_characterMovement.IsGrounded();
            _animator.SetBool("isGrounded",isG);
        }

        private void CheckVerticalSpeed()
        {
            _animator.SetFloat("velocityY", m_characterMovement.GetVerticalSpeed());
        }

        private void CheckDashRun()
        {
            foreach (var animator in _dashAnimators)
            {
                animator.SetBool("isMoving", isMoving);   
            }
        }

        private void CheckDashGrounded()
        {
            foreach (var animator in _dashAnimators)
            {
                var isG = m_characterMovement.IsGrounded();
                animator.SetBool("isGrounded",isG);
            }   
        }

        private void CheckDashVerticalSpeed()
        {
            foreach (var animator in _dashAnimators)
            {
                animator.SetFloat("velocityY", m_characterMovement.GetVerticalSpeed());
            }
        }

        
        
    }
}