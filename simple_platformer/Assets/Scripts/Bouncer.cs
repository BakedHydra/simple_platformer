using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            collision.rigidbody.AddForce(Vector3.up * 500);
        }
    }
}
