using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void LateUpdate()
    {
        gameObject.transform.position = _player.transform.position + new Vector3(0f, 0f, -10f);
    }
}
