using System;
using System.Collections;
using UnityEngine;

namespace _Berkay.Scripts
{
    public class DashVisual : MonoBehaviour
    {
        [SerializeField] private float _visualOpenGap;
        [SerializeField] private float _visualLifeTime;
        [SerializeField] private GameObject[] _dashVisuals;
        
        private Dasher m_dasher;


        private void Awake()
        {
            m_dasher = GetComponent<Dasher>();
        }

        private void Start()
        {
            m_dasher.OnDashed += OnDashed;
        }

        private void OnDestroy()
        {
            m_dasher.OnDashed -= OnDashed;
        }

        private void OnDashed()
        {
            StartCoroutine(AdjustVisuals());
        }
        
        private IEnumerator AdjustVisuals()
        {
            StartCoroutine(OpenVisuals());
            yield return new WaitForSeconds(_visualLifeTime);
            StartCoroutine(CloseVisuals());
        }

        private IEnumerator OpenVisuals()
        {
            foreach (var visual in _dashVisuals)
            {
                yield return new WaitForSeconds(_visualOpenGap);
                visual.SetActive(true);
            }
        }
        
        private IEnumerator CloseVisuals()
        {
            foreach (var visual in _dashVisuals)
            {
                yield return new WaitForSeconds(_visualOpenGap);
                visual.SetActive(false);
            }
        }
    }
}