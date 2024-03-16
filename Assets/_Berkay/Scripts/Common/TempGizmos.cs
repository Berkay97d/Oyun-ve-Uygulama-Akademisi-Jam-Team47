#if UNITY_EDITOR
using System;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;
#else
using UnityEngine;
#endif

namespace _Berkay.Scripts.Common
{
    public static class TempGizmos
    {
        #if UNITY_EDITOR
        
        private static Behaviour ms_Behaviour;

        
        private static Behaviour GetBehaviour()
        {
            if (ms_Behaviour) return ms_Behaviour;

            ms_Behaviour = new GameObject("[TempGizmos Behaviour]")
                .AddComponent<Behaviour>();
            
            Object.DontDestroyOnLoad(ms_Behaviour);

            return ms_Behaviour;
        }


        public static async void DrawWireSphere(Vector3 position, float radius, float duration, Color color)
        {
            var behaviour = GetBehaviour();
            
            behaviour.onDrawGizmos += Draw;

            await UniTask.WaitForSeconds(duration);

            behaviour.onDrawGizmos -= Draw;
            
            void Draw()
            {
                Gizmos.color = color;
                Gizmos.DrawWireSphere(position, radius);
            }
        }
        
        public static async void DrawWireCircle(Vector3 position, Vector3 normal, float radius, float duration, Color color)
        {
            var behaviour = GetBehaviour();
            
            behaviour.onDrawGizmos += Draw;

            await UniTask.WaitForSeconds(duration);

            behaviour.onDrawGizmos -= Draw;
            
            void Draw()
            {
                Handles.color = color;
                Handles.DrawWireDisc(position, normal, radius);
            }
        }

        public static void DrawWireCircle(Vector3 position, float radius, float duration, Color color)
        {
            DrawWireCircle(position, Vector3.forward, radius, duration, color);
        }

        public static async void DrawWireSquare(Vector3 position, Quaternion rotation, Vector2 size, float duration, Color color)
        {
            var behaviour = GetBehaviour();
            
            behaviour.onDrawGizmos += Draw;

            await UniTask.WaitForSeconds(duration);

            behaviour.onDrawGizmos -= Draw;
            
            void Draw()
            {
                Gizmos.color = color;
                GizmosExtra.DrawWireSquare(position, rotation, size);
            }
        }
        
        
        private class Behaviour : MonoBehaviour
        {
            public event Action onDrawGizmos;
            
            
            private void OnDrawGizmos()
            {
                onDrawGizmos?.Invoke();
            }
        }
        
#else
        
        public static void DrawWireSphere(Vector3 position, float radius, float duration, Color color) {}
        public static void DrawWireCircle(Vector3 position, Vector3 normal, float radius, float duration, Color color) {}
        public static void DrawWireCircle(Vector3 position, float radius, float duration, Color color) {}
        public static void DrawWireSquare(Vector3 position, Quaternion rotation, Vector2 size, float duration, Color color) {}

#endif
    }
}