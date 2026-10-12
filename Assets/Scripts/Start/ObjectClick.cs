using UnityEngine;

public class ObjectClick : MonoBehaviour
{
    public Camera MainCamera;
    public string ClickedObject;

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
            if (hit.collider.CompareTag("click"))
            {
                ClickedObject = hit.collider.gameObject.name;

                Debug.Log("Clicked Object: " + ClickedObject);

                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}