using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Berkay.Scripts.Common
{
    public abstract class Area2D : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask = Physics2D.AllLayers;


        public Vector2 GetPosition()
        {
            return transform.position;
        }
        
        
        public abstract T Overlap<T>();
        public abstract IEnumerable<T> OverlapAll<T>();
        public abstract void DrawTempGizmos(float duration, Color color);
        

        public int GetLayerMask()
        {
            return _layerMask;
        }
    }
}