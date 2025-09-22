using UnityEngine;

public class teleporter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.transform.position = new Vector3(0f, 10f, 45f);
        }
    }
}
