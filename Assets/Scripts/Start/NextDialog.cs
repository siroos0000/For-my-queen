using UnityEngine;

public class NextDialog : MonoBehaviour
{
    public TextManegment1 textManegment1;
    public void OnClick()
    {
       Debug.Log("ClickToNext");
        textManegment1.ClickToNext();
    }
}
