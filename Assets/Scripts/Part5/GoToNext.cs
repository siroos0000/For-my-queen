using UnityEngine;

public class GoToNext : MonoBehaviour
{
    public Part5TextMangement TextMangment;
    public bool AnimationEnds = false;
    void Update()
    {
        if (AnimationEnds)
        {
            TextMangment.NextDialog();
            AnimationEnds = false;
            enabled = false;
        }
    }
    private void Awake()
    {
        AnimationEnds = false;
    }
}
