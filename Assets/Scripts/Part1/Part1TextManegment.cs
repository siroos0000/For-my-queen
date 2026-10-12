using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class Part1TextManegment : MonoBehaviour
{
    public UIDocument UIDocument;
    private Label DialogBackground, DialogText, CharacterName,GuideText,LoadingText;
    private Button ContinueButton;
    private Image CharacterImage;
    public Sprite SiroosImage, JamalImage;
    public Animator CamAnimator;
    public ObjectClick objectClick;
    private bool ClickChecker = false;
    private string ClickedObject;
    private int DialogNumber = 0;
    public GameObject LoadingPanel;
    void Start()
    {
        var root = UIDocument.rootVisualElement;
        DialogBackground = root.Q<Label>("DialogBackground");
        DialogText = root.Q<Label>("DialogText");
        CharacterName = root.Q<Label>("CharacterName");
        GuideText = root.Q<Label>("GuideText");
        LoadingText = root.Q<Label>("LoadingText");
        ContinueButton = root.Q<Button>("ContinueButton");
        CharacterImage = root.Q<Image>("CharacterImage");
        ContinueButton.clicked += NextDialog;
        SetDialogText();
        CamAnimator.enabled = false;
        objectClick.enabled = false;

    }
    void Update()
    {
        if(ClickChecker)
        {
            ClickCheck();
        }
    }
    public void SetDialogText()
    {
        switch(DialogNumber)
        {
            case 0:
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
               // ContinueButton.text = "";
                ContinueButton.SetEnabled(false);
                break;
            case 1:
                DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
                ContinueButton.SetEnabled(true);
                ContinueButton.text = "Click to Continue";
                DialogText.text = "سلام سیروس، چه عجب! خیلی  وقته نیومدی اینجا که همدیگه رو ببینیم";
                CharacterName.text = "جمال";
                CharacterImage.image = JamalImage.texture;
                break;
            case 2:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosImage.texture;
                DialogText.text = "آره، درگیر تمرین بودم امروز بعد مدت ها یه استراحت دادم";
                break;
            case 3:
                CharacterName.text = "جمال";
                CharacterImage.image = JamalImage.texture;
                DialogText.text = "توهم خیلی جدی گرفتی، یکم از زندگی لذت ببر";
                break;
            case 4:
                DialogText.text = "حالا اینجا چیکار میکنی؟";
                break;
            case 5:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosImage.texture;
                DialogText.text = "ارتش رو ترک کردم و دارم برای یه ماجراجویی طولانی آماده میشم";
                break;
            case 6:
                DialogText.text = "اینجا اومدم یکم منابع تهیه بکنم";
                break;
            case 7:
                CharacterName.text = "جمال";
                CharacterImage.image = JamalImage.texture;
                DialogText.text = "باشه، چیزایی که لازم داری رو بگو من برات جمع میکنم و بهت میدم";
                break;
            case 8:
                DialogText.text = "کنجکاو شدم، هدفت برای این ماجراجویی چیه";
                break;
            case 9:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosImage.texture;
                DialogText.text = "میخوام تجربه کسب بکنم و تبدیل به یه ماجراجوی قدرتمند بشم";
                break;
            case 10:
                DialogText.text = "و در نهایت میخوام سرزمین های خودم رو پیدا بکنم و گسترش بدمش";
                break;
            case 11:
                CharacterName.text = "جمال";
                CharacterImage.image = JamalImage.texture;
                DialogText.text = "خیلی ریسکی هست ولی مطمئنم از پسش بر میای";
                break;
            case 12:
                DialogText.text = "شاید هم توی راه ملکه ی گمشده رو هم پیدا کردی <color=#bdbdbd> خنده </color>";
                break;
            case 13:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosImage.texture;
                DialogText.text = "شاید<color=#bdbdbd> لبخند ملایم </color>";
                break;
            case 14:
                CharacterName.text = "جمال";
                CharacterImage.image = JamalImage.texture;
                DialogText.text = "وایستا ببینم!!!! نکنه هنوز به افسانه ی ملکه باور داری";
                break;
            case 15:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosImage.texture;
                DialogText.text = "شاید<color=#bdbdbd> لبخند ملایم </color>";
                break;
            case 16:
                CharacterName.text = "جمال";
                CharacterImage.image = JamalImage.texture;
                DialogText.text = "همه میدونن، خرافاتی بیش نیست";
                break;
            case 17:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosImage.texture;
                DialogText.text = "خفه‌شو و برو منابع رو آماده بکن من برای آخرین بار میرم ساحل زو ببینم<color=#bdbdbd> نفس عمیق </color>";
                break;
            case 18:
                CharacterName.text = "جمال";
                CharacterImage.image = JamalImage.texture;
                DialogText.text = "باشه، میرم آماده میکنم، فقط یادت رفت بهم بگی چه چیزایی میخوای احتمالا فکرت درگیر همون ملکه بود<color=#bdbdbd> خنده ی بلند </color>";
                break;
            case 19:
                DialogText.text = "";
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
                CharacterImage.image = null;
                CharacterName.text = "";
                ContinueButton.SetEnabled(false);
                ContinueButton.text = "";
                CamAnimator.enabled = true;
                CamAnimator.SetBool("EndPart", true);
                break;
            case 20:
                DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosImage.texture;
                ContinueButton.SetEnabled(true);
                ContinueButton.text = "Click to Continue";
                DialogText.text= "نمیدونم آینده قراره چی بشه ولی باید مثل همیشه تلاشم رو بکنم!"; 
                break;
            case 21:
                DialogText.text = "دلم هم قراره برای اینجا تنگ بشه";
                break;
            case 22:
                CamAnimator.SetBool("EndPart", false);
                CharacterImage.image = null;
                CharacterName.text = "";
                DialogText.text = "<size=55><b> 5دقیقه بعد   .....</b></size>";
                break;
            case 23:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosImage.texture;
                DialogText.text = "عجیبه یه بطری داره به این سمت میاد، انگار توش یه نامه هم هست";
                break;
            case 24:
                DialogText.text = "حس خیلی عجیبی نسبت بهش دارم، باید بازش بکنم";
                break;
            case 25:
                
                DialogText.text = "";
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
                CharacterImage.image = null;
                CharacterName.text = "";
                ContinueButton.SetEnabled(false);
                ContinueButton.text = "";
                ClickChecker = true;
                GuideText.text = "<b>راهنمایی:</b> روی بطری ضربه بزن ";
                objectClick.enabled = true;
                break;
            case 26:
                GuideText.text = "";
                DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosImage.texture;
                ContinueButton.SetEnabled(true);
                ContinueButton.text = "Click to Continue";
                DialogText.text = "<size=55><color=#bdbdbd> خواندن نامه </color></size>";
                break;
            case 27:
                DialogText.text = "باید سریع تر حرکت بکنم!";
                break;
            case 28:
                DialogText.text = "";
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
                CharacterImage.image = null;
                CharacterName.text = "";
                ContinueButton.SetEnabled(false);
                ContinueButton.text = "";
                LoadingPanel.SetActive(true);
                LoadingText.text = "در حال بارگذاری بخش بعد... ";
                StartCoroutine(LoadLevel("Part2"));
                break;
                
        }
    }
    public void NextDialog()
    {
        DialogNumber++;
        SetDialogText();
    }
    public void ClickCheck()
    {
        ClickedObject = objectClick.ClickedObject;
        if(ClickedObject == "Bottel")
        {
            NextDialog();
            ClickChecker = false;
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

            LoadingText.text = "در حال بارگذاری بخش بعد... "
                                + progress.ToString("F0") + "%";

            Debug.Log("Loading: " + progress + "%");

            yield return null;
        }
    }
}
