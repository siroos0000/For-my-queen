using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class Part4TextMangement : MonoBehaviour
{
    public UIDocument UIDocument;
    private Label DialogBackground, DialogText, CharacterName, GuideText, LoadingText;
    private Button ContinueButton;
    private Image CharacterImage;
    int DialogNumber = 0;
    public Sprite SiroosProfile, QueenProfile;
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
    }

   
    void Update()
    {
        
    }
    private void SetDialogText()
    {
        switch(DialogNumber)
        {
            case 0:
                DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "به یه جای امن رسیدیم";
                break;
            case 1:
                DialogText.text = "مطمئنم که ما رو گم کردن";
                break;
            case 2:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "مرسی از اینکه نجاتم دادی";
                break;
            case 3:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "نجات دادن تو افتخار من بود";
                break;
            case 4:
                DialogText.text = "نیازی هم به تشکر نیست، فقط خوشحالم که تونستم به موقع برسم";
                break;
            case 5:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "قشنک بود <color=#bdbdbd>خنده ی آروم</color>";
                break;
            case 6:
                DialogText.text = "افسانه ی ملکه ی سرگردان رو شنیدی؟؟";
                break;
            case 7:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "آره";
                break;
            case 8:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "بهش باور داری؟";
                break;
            case 9:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "آره<color=#bdbdbd> لبخند ملایم </color>";
                break;
            case 10:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "خب، من اون ملکه ام";
                break;
            case 11:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "شوخی بامزه ای بود";
                break;
            case 12:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "جدی گفتم!!!!";
                break;
            case 13:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "<size=55><color=#bdbdbd> شوکه شدن </color></size>";
                break;
            case 14:
                DialogText.text = "پس آدم خوش شانسی هستم";
                break;
            case 15:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "<color=#bdbdbd>خنده ی آروم</color> آره ";
                break;
            case 16:
                DialogText.text = "با من میای بریم آتیلا";
                break;
            case 17:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "مگه میشه ملکه‌م رو تنها بذارم؟";
                break;
            case 18:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "<color=#bdbdbd>خنده ی آروم</color>";
                break;
            case 19:
                DialogText.text = "پس بیا بریممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممممم";
                break;
            case 20:
                ContinueButton.SetEnabled(false);
                ContinueButton.text = "";
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
                CharacterName.text = "";
                CharacterImage.image = null;
                DialogText.text = "";
                StartCoroutine(LoadLevel("Part5"));
                break;
        }
    }
    public void NextDialog()
    {
        DialogNumber++;
        SetDialogText();
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
