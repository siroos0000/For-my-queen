using UnityEngine;

public class Part2KnightMovement : MonoBehaviour
{

    public float speed = 3f;
    public CharacterController Controller;
    public Animator animator;
    Vector2 v2;
    bool IsWalking = false;
    public Part2TextMangment TextManegment;
    void Start()
    {

    }

    void Update()
    {
        if (IsWalking)
        {
            Move();

        }
        else
        {
            Idle();
        }
    }
    private void Move()
    {
        v2 = new Vector2(speed, 0);
        Controller.Move(v2 * Time.deltaTime);
        animator.SetBool("IsWalking", true);
    }
    private void Idle()
    {
        v2 = new Vector2(0, 0);
        Controller.Move(v2 * Time.deltaTime);
        animator.SetBool("IsWalking", false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            IsWalking = false;
            TextManegment.NextDialog();
            Debug.Log("Knight has reached the finish line.");
        }
    }
    public void MovementApply(bool Walk = false)
    {
        IsWalking = Walk;
    }
}

