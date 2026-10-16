using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Part5TextMangement : MonoBehaviour
{
    public UIDocument UIDocument;
    public UIDocument EndPartUI;
    //public GoToNext toNext;
    private Label DialogBackground, DialogText, CharacterName, GuideText, LoadingText;
    private Button ContinueButton,Exit, Menu;
    private Image CharacterImage;
    private VisualElement EndingRoot;
    private int DialogNumber = 0;
    public Sprite SiroosProfile, QueenProfile, priestProfile;
    public GameObject Blackscreen;
    public Animator ScreenControl,kingAndQueenAnimator;
    void Start()
    {
        var root = UIDocument.rootVisualElement;
        EndingRoot = EndPartUI.rootVisualElement;

        EndingRoot.style.display = DisplayStyle.None;
        Exit = EndingRoot.Q<Button>("Exit");
        Menu = EndingRoot.Q<Button>("Menu");
        Menu.clicked += ToMainMenu;
        Exit.clicked += ExitTheGame;
        DialogBackground = root.Q<Label>("DialogBackground");
        DialogText = root.Q<Label>("DialogText");
        CharacterName = root.Q<Label>("CharacterName");
        GuideText = root.Q<Label>("GuideText");
        LoadingText = root.Q<Label>("LoadingText");
        ContinueButton = root.Q<Button>("ContinueButton");
        CharacterImage = root.Q<Image>("CharacterImage");
        
       ContinueButton.clicked += NextDialog;
        SetDialogText();
        Blackscreen.SetActive(true);
       Menu.clicked += ToMainMenu;
       Exit.clicked += ExitTheGame;
        //EndPart.SetActive(false);
    }

    private void SetDialogText()
    { 
        switch(DialogNumber)
        {
            case 0:
                LoadingText.text = "آتیلا";
                break;
            case 1:
            LoadingText.text = "دو سال بعد....";
            break;
        case 2:
                LoadingText.text = "";
            ScreenControl.SetBool("Move", true);
            ContinueButton.SetEnabled(false);
            break;
        case 3:
            ContinueButton.SetEnabled(true);
            DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
            CharacterImage.image = priestProfile.texture;
            CharacterName.text = "<size=40>کاهن اعظم</size>";
            DialogText.text = "امروز، در برابر چشمان آسمان و مردمان این سرزمین، گرد هم آمده‌ایم تا پیوندی مقدس را گواهی دهیم";
            break;
        case 4:
            DialogText.text = "پیوند دو قلب که از این پس، یک سرنوشت خواهند داشت";
            break;
        case 5:
            DialogText.text = "ای پادشاه آتیلا، آیا این ملکه را به‌عنوان همسر و همراه خویش می‌پذیری؟";
            break;
        case 6:
            DialogText.text = "آیا در روزهای شکوه و در شب‌های تاریک، در کنار او خواهی ماند ";
            break;
            case 7:
                DialogText.text = "و تا پایان راه از عشق و وفاداری‌ات پاسداری خواهی کرد؟";
                break;
        case 8:
            CharacterName.text = "سیروس";
            CharacterImage.image = SiroosProfile.texture;
            DialogText.text = "می‌پذیرم. تاج و تخت من روزی فرو خواهند ریخت، اما عهد من با ملکه ام هرگز.";
            break;
        case 9:
            CharacterImage.image = priestProfile.texture;
            CharacterName.text = "<size=40>کاهن اعظم</size>";
            DialogText.text = "و تو، ای ملکه، آیا این مرد را به‌عنوان همسر خویش می‌پذیری؟";
            break;
        case 10:
            DialogText.text = "آیا در کنار او قدم خواهی برداشت، نه فقط در مقام ملکه این سرزمین، بلکه به‌عنوان همراه و هم‌سرنوشت او؟";
            break;
        case 11:
            CharacterName.text = "فاطمه";
            CharacterImage.image = QueenProfile.texture;
            DialogText.text = "می‌پذیرم. برای مردی که قلبم او را برگزیده است";
            break;
        case 12:
            CharacterImage.image = priestProfile.texture;
            CharacterName.text = "<size=40>کاهن اعظم</size>";
            DialogText.text = "پس به گواهی این سرزمین و به حرمت عهدی که در برابر یکدیگر بستید";
            break;
        case 13:
            DialogText.text = "شما را زن و شوهر اعلام می‌کنم. از این لحظه، دو سرنوشت در هم تنیده شده‌اند و دو قلب، خانه‌ای مشترک یافته‌اند.";
            break;
        case 14:
            DialogText.text = "باشد که پادشاهی‌تان با خرد استوار بماند، با شجاعت شکوفا شود و با عشق جاودانه گردد. زنده باد پادشاه و ملکهٔ آتیلا!";
            break;
        case 15:
            ContinueButton.SetEnabled(false);
            ContinueButton.text = "";
            DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
            CharacterName.text = "";
            CharacterImage.image = null;
            DialogText.text = "";
            kingAndQueenAnimator.SetTrigger("Kiss");
            break;
        case 16:
            ScreenControl.SetBool("Move", false);
              //  toNext.AnimationEnds = false;
              //  toNext.enabled = true;
                break;
        case 17:
                EndingRoot.style.display = DisplayStyle.Flex;
                //EndPart.SetActive(true);
                break;

        }
    }
    public void ToMainMenu()
    {
        StartCoroutine(LoadLevel("Menu"));
    }
    public void ExitTheGame()
    {
        Application.Quit();
    }
    public void NextDialog()
    {
        DialogNumber++;
        SetDialogText();
        Debug.Log(DialogNumber);
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

            LoadingText.text = "در حال بارگذاری ... "
                                + progress.ToString("F0") + "%";

            Debug.Log("Loading: " + progress + "%");

            yield return null;
        }
    }
}
