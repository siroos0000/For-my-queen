using UnityEngine;

public class NextDialogApply : MonoBehaviour
{
    public Part3TextMangment mangment;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            mangment.NextDialog();
        }
    }
}
