using UnityEngine;

public class Banditsence : MonoBehaviour
{
    private Animator BanditAnimator;
    private Rigidbody2D BanditRigidbody;
    public float speed = 3.5f;
    public bool isBanditActive = false;
    public TextManegment1 textManegment1;
    void Start()
    {
        BanditAnimator = GetComponent<Animator>();
        BanditRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(isBanditActive)
        {
            Bandit_movement();
        }
        if(!isBanditActive)
        {
            bandit_idle();
        }
    }
    private void Bandit_movement()
    {
        BanditRigidbody.linearVelocity = (new Vector2(speed, 0));
        BanditAnimator.SetInteger("AnimState", 2);
        
    }
    private void bandit_idle()
    {
        BanditRigidbody.linearVelocity = (new Vector2(0, 0));
        BanditAnimator.SetInteger("AnimState", 0);
        //textManegment1.ClickToNext();
        //enabled = false;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            isBanditActive = false;
            bandit_idle();
            textManegment1.ClickToNext();
            enabled = false;
        }
    }
}
