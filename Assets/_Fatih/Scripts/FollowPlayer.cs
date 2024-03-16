using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void LateUpdate()
    {
        this.gameObject.transform.position = _player.transform.position + new Vector3(0, 1.5f, -1f);
    }
}
