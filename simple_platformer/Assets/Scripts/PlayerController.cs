using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 300f;

    [SerializeField] private Rigidbody rb_player;
    [SerializeField] private Transform tf_player;

    private Vector3 ray_offset = new Vector3();

    //void Start()
    //{
    //}
    void Update()
    {
        ray_offset = tf_player.position + new Vector3(0, -0.4f, 0);
        Ray ray = new(ray_offset, Vector3.down);
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * Speed * Time.deltaTime, 0, 0);
        //Debug.DrawRay(ray_offset, Vector3.down);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (Physics.Raycast(ray, out _, 0.33f))
            {                
                rb_player.AddForce(Vector3.up * JumpForce);
            }
        }
    }
}