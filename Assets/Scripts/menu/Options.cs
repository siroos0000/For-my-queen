using UnityEngine;

public class Options : MonoBehaviour
{
    public bool Option = false;
    public Movement m;
    void Update()
    {
        if(Option)
        {
            m.Options = true;
            enabled = false;
        }
    }
}
