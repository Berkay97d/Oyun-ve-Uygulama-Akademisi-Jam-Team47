using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

namespace _Berkay.Scripts.Common
{
    public class BoxArea2D : Area2D
    {
        [SerializeField] private bool _axisAligned;
        

        public Vector2 GetSize()
        {
            return transform.lossyScale.Abs();
        }

        public float GetAngle()
        {
            return _axisAligned ? 0f : transform.eulerAngles.z;
        }
        
        public override T Overlap<T>()
        {
            return Collision2D.OverlapBox<T>(GetPosition(), GetSize(), GetAngle(), GetLayerMask());
        }

        public override IEnumerable<T> OverlapAll<T>()
        {
            throw new System.NotImplementedException();
        }


        public override void DrawTempGizmos(float duration, Color color)
        {
            TempGizmos.DrawWireSquare(GetPosition(), Quaternion.Euler(Vector3.forward * GetAngle()), GetSize(), duration, color);
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = UnityEditor.Handles.yAxisColor;
            GizmosExtra.DrawWireSquare(GetPosition(), Quaternion.Euler(Vector3.forward * GetAngle()), GetSize());
        }

#endif
    }
}