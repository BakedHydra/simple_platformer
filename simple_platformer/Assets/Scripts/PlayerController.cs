using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 300f;

    [SerializeField] private Rigidbody rb_player;
    [SerializeField] private Transform tf_player;

    private Vector3 ray_offset = new Vector3();

    void Start()
    {
        ray_offset = tf_player.position + new Vector3(0, -0.51f, 0);
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * Speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (Physics.Raycast(ray_offset, new Vector3(0, 0, 90), 100f))
            {
                rb_player.AddForce(Vector3.up * JumpForce);
            }
        }
    }
}
