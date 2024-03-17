using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;


[ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
public class FollowOnlyX : CinemachineExtension
{
    [Tooltip("Lock the camera's Z position to this value")]
    public float m_YPosition = -10;

    
    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            
            pos.y = m_YPosition;
            
            state.RawPosition = pos;
        }
    }

    public void SetYPos(float pos)
    {
        m_YPosition = pos;
    }
}