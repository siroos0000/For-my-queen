using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TextManegment1 : MonoBehaviour
{
    public UIDocument UIDocument1;
    private Label dialogueText, MainDialogText, Name, guideText;
    private Button nextButton;
    private Image Image;
    int TextCount = 0;
    public Animator Scenes;
    public Banditsence banditsence;
    public ObjectClick ObjectClickScript;
    [SerializeField] public Sprite BanditImage, queen;
    public GameObject Food, bandit, chair1, chair2, BottelInTheSea;
    private bool ClickPhase = false;
    private int ItemCount = 0;
    void Start()
    {

        var root = UIDocument1.rootVisualElement;
        dialogueText = root.Q<Label>("dialogueText");
        MainDialogText = root.Q<Label>("MainDialogText");
        Name = root.Q<Label>("Name");
        guideText = root.Q<Label>("guideText");
        nextButton = root.Q<Button>("nextButton");
        Image = root.Q<Image>("Image");
        nextButton.clicked += ClickToNext;
        StoryTexts();
    }
    private void Update()
    {
        if (ClickPhase)
        {
            ClickCheck();
        }
    }
    private void StoryTexts()
    {
        switch (TextCount)
        {
            case 0:
                dialogueText.text = "افسانه ای در میان مردم" + "\n" + "دهان به دهان میشود....";
                break;
            case 1:
                dialogueText.text = "میگفتند ملکه ای گمشده، \nجایی در این دنیا سرگردان هست";
                break;
            case 2:
                dialogueText.text = "و هر شوالیه ای که او را پیدا بکند \n و برایش بجنگد و از او محافظت کند.";
                break;
            case 3:
                dialogueText.text = "تاج پادشاهی سرزمین گمشده ی\n آتیلا را به دست خواهد آورد.";
                break;
            case 4:
                dialogueText.text = "اما هیچکس نمیداند....";
                break;
            case 5:
                dialogueText.text = "آیا این ملکه واقعا وجود دارد،";
                break;
            case 6:
                dialogueText.text = "یا تمام این افسانه \n چیزی جز یک قصه ی قدیمی نیست";
                break;
            case 7:
                Scenes.SetTrigger("Start");
                dialogueText.text = "";
                nextButton.text = "";
                nextButton.SetEnabled(false);
                break;
            case 8:
                MainDialogText.style.backgroundColor = new StyleColor(Color.darkCyan);
                nextButton.text = "Click to Continue";
                nextButton.SetEnabled(true);
                Image.image = BanditImage.texture;
                Name.text = "راهزن";
                MainDialogText.text = "اینم از غذا کوفتش کن";
                break;
            case 9:
                Food.SetActive(true);
                MainDialogText.text = "فردا شب آماده باش که قراره  رئیس بیاد  ";
                break;
            case 10:
                MainDialogText.text = "مطمئنم دلش نمیخواد ببینه گشنه ای وگرنه بد میشه برات";
                break;
            case 11:
                Image.image = queen.texture;
                Name.text = "فاطمه";
                MainDialogText.text = "برید به جهنم برام مهم نیستید";
                break;
            case 12:
                Image.image = BanditImage.texture;
                Name.text = "راهزن";
                MainDialogText.text = "چی گفتی؟؟؟؟؟";
                break;
            case 13:
                MainDialogText.text = "<color=#bdbdbd><i>نفس عمیق</i></color>" + " اهمیتی نداره! به نظرم باید عاقبتت رو قبول بکنی";
                break;
            case 14:
                MainDialogText.text = "<color=#bdbdbd><i>خنده ی بلند</i></color>";
                break;
            case 15:
                Image.image = null;
                Name.text = "";
                MainDialogText.text = "<b><size=75>5... دقیقه بعد</size></b>";
                bandit.SetActive(false);
                break;
            case 16:
                Image.image = queen.texture;
                Name.text = "فاطمه";
                MainDialogText.text = "باید فکر کنم یه راهی پیدا بکنم حالم از رئیسشون بهم میخوره";
                break;
            case 17:
                MainDialogText.text = "....یه جوری باید از یکی کمک بخوام";
                break;
            case 18:
                MainDialogText.text = "اما کی میتونه کمکم بکنه؟";
                break;
            case 19:
                MainDialogText.text = "<b><size=75>یه ایده دارم!</size></b>";
                break;
            case 20:
                MainDialogText.text = "میتونم با بطری آبی که بهم دادن و کاغذ یه نامه برای کمک بنویسم و بندازم توی دریا";
                break;
            case 21:
                guideText.text = "<b>راهنمایی: </b>" + "روی بطری و کاغذ ضربه بزن";
                MainDialogText.text = "";
                nextButton.SetEnabled(false);
                nextButton.text = "";
                MainDialogText.style.backgroundColor = new StyleColor(Color.clear);
                ClickPhase = true;
                ObjectClickScript.enabled = true;
                break;
            case 22:
                MainDialogText.text = "حالا باید سعی کنم از بین میله ها بندازمش پایین";
                break;
            case 23:
                MainDialogText.text = "امیدارم مشکلی پیش نیاد";
                break;
            case 24:
                chair1.SetActive(false);
                chair2.SetActive(true);
                BottelInTheSea.SetActive(true);
                MainDialogText.text = "امیدوارم نامه به دست کسی برسه و کمک کنه";
                break;
            case 25:
                dialogueText.style.backgroundColor = new StyleColor(Color.black);
                MainDialogText.text = "";
                MainDialogText.style.backgroundColor = new StyleColor(Color.clear);
                Name.text = "";
                Image.image = null;
                dialogueText.text = "در حال بارگذاری بخش بعد...";
                nextButton.SetEnabled(false);
                StartCoroutine(LoadLevel("Part1"));
                break;
            default:
                nextButton.SetEnabled(false);
                break;
        }
    }

    void ClickCheck()
    {
        if (ObjectClickScript.ClickedObject == "paper")
        {
            if (ItemCount == 0)
            {
                guideText.text = "<b>راهنمایی: </b>" + "روی بطری ضربه بزن";
            }
            ItemCount++;
            Debug.Log("ItemCount: " + ItemCount);
            ObjectClickScript.ClickedObject = "";
        }
        if (ObjectClickScript.ClickedObject == "bottle")
        {
            if (ItemCount == 0)
            {
                guideText.text = "<b>راهنمایی: </b>" + "روی کاغذ ضربه بزن";
            }
            ItemCount++;
            Debug.Log("ItemCount: " + ItemCount);
            ObjectClickScript.ClickedObject = "";
        }
        if (ItemCount == 2)
        {
            guideText.text = "";
            MainDialogText.style.backgroundColor = new StyleColor(Color.darkCyan);
            Name.text = "؟؟؟؟";
            Image.image = queen.texture;
            MainDialogText.text = "<b>نامه آماده شد</b> ";
            nextButton.SetEnabled(true);
            nextButton.text = "Click to Continue";
            ClickPhase = false;
        }

    }
    public void ClickToNext()
    {
        TextCount++;
        StoryTexts();
        Debug.Log("TextCount: " + TextCount);
    }
    public IEnumerator LoadLevel(string sceneName)
    {
        // اجازه بده متن Loading ابتدا نمایش داده بشه
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

            dialogueText.text = "در حال بارگذاری بخش بعد... "
                                + progress.ToString("F0") + "%";

            Debug.Log("Loading: " + progress + "%");

            yield return null;
        }
    }
}
