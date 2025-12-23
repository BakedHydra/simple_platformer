using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using static UnityEngine.Mathf;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 300f;
    private bool OnGround = false;

    [SerializeField] private Rigidbody rb_player;
    [SerializeField] private Transform tf_player;
    [SerializeField] private Animator anim_player;
    [SerializeField] private PlayableDirector director;

    private bool canMove = true;

    private void Start()
    {
        director.Play();
        director.stopped += OnDirectorStopped;
        canMove = false;
    }

    private void OnDirectorStopped(PlayableDirector obj)
    {
        canMove = true;
    }

    void FixedUpdate()
    {
        float local_speed;
        if (Time.timeScale > 0.0f && canMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            local_speed = Mathf.Abs(Speed * horizontal);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                local_speed *= 2f;
            }
            if (horizontal != 0)
            {
                tf_player.Translate(0, 0, horizontal * local_speed * Time.deltaTime);
            }
            if (anim_player != null)
            {
                anim_player.SetFloat("Speed", local_speed);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (OnGround)
                {
                    anim_player.SetTrigger("Jump");
                    rb_player.AddForce(Vector3.up * JumpForce);
                }
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        OnGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        OnGround = false;
    }
}