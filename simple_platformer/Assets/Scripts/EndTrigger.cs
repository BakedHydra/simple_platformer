using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        GameObject
            .FindGameObjectWithTag("GameManager")
            .GetComponent<ExitScript>()
            .ToWin_script();
    }
}
