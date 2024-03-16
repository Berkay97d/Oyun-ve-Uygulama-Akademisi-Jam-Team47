using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Berkay.Scripts.Common
{
    public static class Collision2D
    {
        public const int OBSTACLE_LAYER = 1 << 8;
        
        
        private static readonly Collider2D[] COLLIDER_BUFFER = new Collider2D[100];
        private static readonly RaycastHit2D[] RAYCAST_BUFFER = new RaycastHit2D[100];


        public static RaycastResult2D<T> Raycast<T>(Vector2 origin, Vector2 direction, float distance, int layerMask)
        {
            var count = Physics2D.RaycastNonAlloc(origin, direction, RAYCAST_BUFFER, distance, layerMask);

            for (var i = 0; i < count; i++)
            {
                if (RAYCAST_BUFFER[i].collider.TryGetComponent(out T type))
                {
                    return new RaycastResult2D<T>
                    {
                        hit = RAYCAST_BUFFER[i],
                        target = type
                    };
                }
            }

            return default;
        }
        
        public static T OverlapCircle<T>(Vector2 position, float radius, int layerMask)
        {
            var count = Physics2D.OverlapCircleNonAlloc(position, radius, COLLIDER_BUFFER, layerMask);

            for (var i = 0; i < count; i++)
            {
                if (COLLIDER_BUFFER[i].TryGetComponent(out T type)) return type;
            }

            return default;
        }

        public static IEnumerable<T> OverlapCircleAll<T>(Vector2 position, float radius, int layerMask)
        {
            var count = Physics2D.OverlapCircleNonAlloc(position, radius, COLLIDER_BUFFER, layerMask);

            for (var i = 0; i < count; i++)
            {
                if (COLLIDER_BUFFER[i].TryGetComponent(out T type)) yield return type;
            }
        }

        public static T OverlapBox<T>(Vector2 position, Vector2 size, float angle, int layerMask)
        {
            var count = Physics2D.OverlapBoxNonAlloc(position, size, angle, COLLIDER_BUFFER, layerMask);

            for (var i = 0; i < count; i++)
            {
                if (COLLIDER_BUFFER[i].TryGetComponent(out T type)) return type;
            }

            return default;
        }
        
        public static IEnumerable<T> OverlapBoxAll<T>(Vector2 position, Vector2 size, float angle, int layerMask)
        {
            var count = Physics2D.OverlapBoxNonAlloc(position, size, angle, COLLIDER_BUFFER, layerMask);

            for (var i = 0; i < count; i++)
            {
                if (COLLIDER_BUFFER[i].TryGetComponent(out T type)) yield return type;
            }
        }
        
        
        public struct RaycastResult2D<T>
        {
            public RaycastHit2D hit;
            public T target;
        }
    }
}