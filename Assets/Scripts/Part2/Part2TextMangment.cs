
using UnityEngine;
using UnityEngine.UIElements;

public class Part2TextMangment : MonoBehaviour
{
    public Animator PanlAnimator;
    public UIDocument UIDocument;
    private Label BlackScreenDialog, DialogBackground, Dialog, ProfileName;
    private Button ToNextButton;
    private Image ProfileImage;
    int DialogNumber;
    void Start()
    {
        var root = UIDocument.rootVisualElement;
        BlackScreenDialog = root.Q<Label>("BlackScreenDialog");
        DialogBackground = root.Q<Label>("DialogBackground");
        Dialog = root.Q<Label>("Dialog");
        ProfileName = root.Q<Label>("ProfileName");
        ToNextButton = root.Q<Button>("ToNextButton");
        ProfileImage = root.Q<Image>("ProfileImage");
        ToNextButton.clicked += NextDialog;
        StroyLine();
    }
    void Update()
    {
        
    }
    private void StroyLine()
    {
        switch(DialogNumber)
        {
            case 0:
                BlackScreenDialog.text = "10 ساعت بعد";
                break;
            case 1:
                BlackScreenDialog.text = "در نزدیکی پناهگاه راهزن ها";
                break;
            case 2:
                PanlAnimator.SetBool("Normal",true);
                break;
        }
    }
    public void NextDialog()
    {
        DialogNumber++;
        StroyLine();
        Debug.Log("DialogNumber: " + DialogNumber);
    }

}
