using UnityEngine;

public class ClickToEnemy : MonoBehaviour
{
    public Camera MainCamera;
    public string ClickedObject;
    Animator animator;
    public int kills = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick(Input.mousePosition);
        }

        if (Input.touchCount > 0 &&
            Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CheckClick(Input.GetTouch(0).position);
        }
    }

    void CheckClick(Vector2 position)
    {
        Vector3 worldPosition =
            MainCamera.ScreenToWorldPoint(position);

        Vector2 point = new Vector2(
            worldPosition.x,
            worldPosition.y
        );

        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                animator = hit.collider.gameObject.GetComponent<Animator>();
                if(animator != null)
                {
                    animator.SetTrigger("Death");
                }
                kills++;
                hit.collider.enabled = false;
            }
            if(hit.collider.CompareTag("click"))
            {
                ClickedObject = hit.collider.name;
                hit.collider.gameObject.SetActive(false);
            }
        }
        
    }
}
