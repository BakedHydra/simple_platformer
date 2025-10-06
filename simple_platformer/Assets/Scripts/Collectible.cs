using UnityEditor.UI;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            FindFirstObjectByType<ExitScript>().GetComponent<ExitScript>().coin_counter++;
        }
    }
}