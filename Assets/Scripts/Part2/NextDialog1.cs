using UnityEngine;

public class NextDialog1 : MonoBehaviour
{
    public Part2TextMangment TextMangment;
    public bool AnimationEnds = false;
    void Update()
    {
        if (AnimationEnds)
        {
            TextMangment.NextDialog();
            enabled = false;
        }
    }
}
