using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float Speed = 2f;
    public float Distance = 3f;
    private Vector3 startPos;
    //private Vector3 middlePos;
    //private Vector3 offset;
    private void Start()
    {
        startPos = transform.position;
    //    middlePos = startPos;
    }
void Update()
    {
        float movement = Mathf.Abs(Mathf.Sin(Time.time * Speed)) * Distance;
        transform.position = new Vector3(startPos.x - movement, transform.position.y, transform.position.z);
        //offset = middlePos - transform.position;
        //middlePos = transform.position;
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Transform player_transform = collision.transform;
    //        player_transform.Translate(0, 0, offset.z);
    //    }
    //}
}
