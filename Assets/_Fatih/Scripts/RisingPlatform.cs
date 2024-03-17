using System.Collections;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    [SerializeField] float risingSpeed;
    [SerializeField] GameObject platformStopper;
    bool triggeredStopper;

    Vector3 firstPosition;

    private void Start()
    {
        firstPosition = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == platformStopper)
        {
            triggeredStopper = true;
            Invoke(nameof(PlatformPosResetter), 10f); 
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !triggeredStopper)
        {
            gameObject.transform.position += new Vector3(0f, risingSpeed);
        }
    }

    void PlatformPosResetter()
    {
        gameObject.transform.position = firstPosition;
        triggeredStopper = false;
    }

}
