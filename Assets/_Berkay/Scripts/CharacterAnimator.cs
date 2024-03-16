using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private CharacterMovement m_characterMovement;
        private bool isMoving;

        private void Start()
        {
            m_characterMovement = GetComponent<CharacterMovement>();
         
            StartCoroutine(CheckIsMoving());
        }

        private void Update()
        {
            CheckRun();
            CheckGrounded();
            CheckVerticalSpeed();
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
            Debug.Log(isG);
            _animator.SetBool("isGrounded",isG);
        }

        private void CheckVerticalSpeed()
        {
            _animator.SetFloat("velocityY", m_characterMovement.GetVerticalSpeed());
        }

        
        
    }
}