using UnityEngine;
using static UnityEngine.Mathf;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 300f;

    [SerializeField] private Rigidbody rb_player;
    [SerializeField] private Transform tf_player;
    [SerializeField] private Animator anim_player;
    [SerializeField] private float linear_velocity;
    void FixedUpdate()
    {
        float local_speed = 0f;
        if (Time.timeScale > 0.0f)
        {
            float horizontal = Input.GetAxis("Horizontal");
            if (horizontal != 0)
            {
                local_speed = Speed;
                if (Input.GetKey(KeyCode.LeftShift)) { local_speed += 10f;}
                if (Abs(rb_player.linearVelocity.x) < local_speed)
                { 
                    rb_player.AddForce(new Vector3(horizontal * local_speed, 0, 0), ForceMode.VelocityChange);
                }
                linear_velocity = rb_player.linearVelocity.x;
            }
            if (anim_player != null)
            {
                anim_player.SetFloat("Speed", local_speed);
            }
        }
    }
}