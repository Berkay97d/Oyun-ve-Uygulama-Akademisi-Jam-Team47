using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    [SerializeField] float risingSpeed;
    [SerializeField] GameObject platformStopper;
    bool triggeredStopper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == platformStopper)
        {
            triggeredStopper = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !triggeredStopper)
        {
            gameObject.transform.position += new Vector3(0f, risingSpeed);
        }
    }
}
