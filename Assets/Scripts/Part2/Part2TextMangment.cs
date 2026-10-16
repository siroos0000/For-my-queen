
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class Part2TextMangment : MonoBehaviour
{
    public Animator PanlAnimator;
    public UIDocument UIDocument;
    public Part2KnightMovement KnightMovement;
    public NextDialog1 nextdialog;
    private Label BlackScreenDialog, DialogBackground, Dialog, ProfileName;
    private Button ToNextButton;
    private Image ProfileImage;
    public Sprite SiroosProfile, LightBanditProfile,HeavyBanditProfile;
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
                BlackScreenDialog.text = "10ساعت بعدی";
                break;
            case 1:
                BlackScreenDialog.text = "در نزدیکی پناهگاه راهزن ها";
                break;
            case 2:
                PanlAnimator.SetBool("Normal",true);
                BlackScreenDialog.text = "";
                ToNextButton.SetEnabled(false);
                ToNextButton.text = "";
                break;
            case 3:
                nextdialog.enabled = false;
                ToNextButton.SetEnabled(true);
                ToNextButton.text = "Click to Continue";
                DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
                Dialog.text = " طبق چیزی که نوشته باید همین نزدیکی ها باشه";
                ProfileImage.image = SiroosProfile.texture;
                ProfileName.text = "سیروس";
                break;
            case 4:
                Dialog.text =  "حس بدی دارم که به کسی خبر ندادم";
                break;
            case 5:
                Dialog.text = "چاره ای جز شکست دادنشون ندارم";
                break;
            case 6:
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
                ProfileImage.image = null;
                ProfileName.text = "";
                Dialog.text = "";
                ToNextButton.SetEnabled(false);
                ToNextButton.text = "";
                KnightMovement.MovementApply(true);
                break;
            case 7:
                ToNextButton.SetEnabled(true);
                ToNextButton.text = "Click to Continue";
                DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
                ProfileImage.image = SiroosProfile.texture;
                ProfileName.text = "سیروس";
                Dialog.text = "<color=#383838><b>فکر کنم پیداشون کردم، فعلا باید ساکت بمونم و منتظر یه فرصت خوب برای حمله باشم</b></color>";
                break;
            case 8:
                ProfileImage.image = HeavyBanditProfile.texture;
                ProfileName.text = "راهزن 1";
                Dialog.text = "خبر آوردن که رئیس  کمتر از 1 ساعت دیگه میرسه";
                break;
            case 9:
                ProfileImage.image = LightBanditProfile.texture;
                ProfileName.text = "راهزن 2";
                Dialog.text = "زودتر از زمانی که اعلام کرده بود شدش";
                break;
            case 10:
                ProfileImage.image = HeavyBanditProfile.texture;
                ProfileName.text = "راهزن 1";
                Dialog.text = "آره، گفته جشن بزرگی قراره بگیره";
                break;
            case 11:
                ProfileName.text = "راهزن 3";
                Dialog.text = "این همه کار برای اون زنی که زندانی شدش هست؟؟";
                break;
            case 12:
                ProfileName.text = "راهزن 1";
                Dialog.text = "آره، خیلی عجیبه رئیس هیچوقت اینکار رو نمیکرد";
                break;
            case 13:
                ProfileImage.image = LightBanditProfile.texture;
                ProfileName.text = "راهزن 2";
                Dialog.text = "به نظر من تا وقتی که میشه خوش گذرند مهم نیستش";
                break;
            case 14:
                ProfileImage.image = HeavyBanditProfile.texture;
                ProfileName.text = "راهزن 3";
                Dialog.text = "بچه ها غذا آماده شدش!!";
                break;
            case 15:
                ProfileImage.image = SiroosProfile.texture;
                ProfileName.text = "سیروس";
                Dialog.text = "<color=#383838><b>حالا وقت حمله هستش</b></color>";
                break;
            case 16:
                Dialog.text = "<color=#383838><b>به اولی باید بی سر و صدا حمله بکنم،از شر باقی مونده‌اشون هم راحت تر خلاص میشم</b></color>";
                break;
            case 17:
                nextdialog.enabled = true;
                nextdialog.AnimationEnds = false;
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
                Dialog.text = "";
                ProfileImage.image = null;
                ProfileName.text = "";
                ToNextButton.SetEnabled(false);
                ToNextButton.text = "";
                PanlAnimator.SetBool("Normal", false);
                break;
            case 18:
                BlackScreenDialog.text = "در حال بارگذاری بخش بعد... ";
                StartCoroutine(LoadLevel("Part3"));
                break;
        }
    }
    public IEnumerator LoadLevel(string sceneName)
    {
        yield return null;

        AsyncOperation operation =
            SceneManager.LoadSceneAsync(sceneName);

        if (operation == null)
        {
            Debug.LogError("Scene could not be loaded: " + sceneName);
            yield break;
        }

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f) * 100f;

            BlackScreenDialog.text = "در حال بارگذاری بخش بعد... "
                                + progress.ToString("F0") + "%";

            Debug.Log("Loading: " + progress + "%");

            yield return null;
        }
    }
    public void NextDialog()
    {
        DialogNumber++;
        StroyLine();
        Debug.Log("DialogNumber: " + DialogNumber);
    }

}
