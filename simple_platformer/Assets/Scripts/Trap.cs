using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<ExitScript>().GetComponent<ExitScript>().PlayerReceivedDamage_script();
            other.GetComponent<Transform>().position = new Vector3(0, 0.8f, 0);
        }
    }
}
