using UnityEngine;

namespace _Berkay.Scripts
{
    public static class GizmosExtra
    {
        public static void DrawWireSquare(Vector3 position, Quaternion orientation, Vector2 size)
        {
            var oldMatrix = Gizmos.matrix;
            Gizmos.matrix = Matrix4x4.TRS(position, orientation, size);
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
            Gizmos.matrix = oldMatrix;
        }
    }
}