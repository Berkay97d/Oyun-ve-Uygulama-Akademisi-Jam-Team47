using System.Collections.Generic;
using UnityEngine;
namespace _Berkay.Scripts.Common
{
    public class CircleArea2D : Area2D
    {
        [SerializeField] private float _radius = 1f;
        

        public float GetRadius()
        {
            return _radius;
        }

        public void SetRadius(float radius)
        {
            _radius = radius;
        }

        public override T Overlap<T>()
        {
            return Collision2D.OverlapCircle<T>(GetPosition(), GetRadius(), GetLayerMask());
        }

        public override IEnumerable<T> OverlapAll<T>()
        {
            return Collision2D.OverlapCircleAll<T>(GetPosition(), GetRadius(), GetLayerMask());
        }

        public override void DrawTempGizmos(float duration, Color color)
        {
            TempGizmos.DrawWireCircle(GetPosition(), GetRadius(), duration, color);
        }

#if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            UnityEditor.Handles.color = UnityEditor.Handles.yAxisColor;
            UnityEditor.Handles.DrawWireDisc(GetPosition(), Vector3.forward, GetRadius());
        }

#endif
    }
}