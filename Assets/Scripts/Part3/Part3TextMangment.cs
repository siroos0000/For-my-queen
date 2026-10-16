using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;
public class Part3TextMangment : MonoBehaviour
{
    public UIDocument UIDocument;
    public ClickToEnemy ToEnemy;
    public Animator CamAnimator;
    private Label DialogBackground, DialogText, CharacterName, GuideText, LoadingText;
    private Button ContinueButton;
    private Image CharacterImage;
    int DialogNumber = 0;
    bool fight = true,brokethedoor = false;
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
        if(fight)
        {
            OnFight();
        }
        if(brokethedoor)
        {
            Click();
        }
    }
    private void SetDialogText()
    {
        switch(DialogNumber)
        {
            case 0:
                GuideText.text = "راهنمایی: بر روی راهزن ضربه بزن";
                ContinueButton.SetEnabled(false);
                ContinueButton.text = "";
                break;
            case 1:
                GuideText.text = "";
                ContinueButton.SetEnabled(true);
                ContinueButton.text = "Click To Continue";
                DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "حس عجیبی دارم";
                break;
            case 2:
                ToEnemy.enabled=false;
                DialogText.text = "هرچه سریع تر باید برم و نجاتش بدم!!!";
                break;
            case 3:
                ContinueButton.SetEnabled(false);
                ContinueButton.text = "";
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
                CharacterName.text = "";
                CharacterImage.image = null;
                DialogText.text = "";
                CamAnimator.SetTrigger("Move");
                break;
            case 4:
                ContinueButton.SetEnabled(true);
                ContinueButton.text = "Click To Continue";
                DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "اینجایی!";
                break;
            case 5:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "تو کی هستی؟؟";
                break;
            case 6:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "وقت زیادی برای توضیح دادن نیستش!";
                break;
            case 7:
                DialogText.text = "نامه ات دستم رسید و اومدم کمک";
                break;
            case 8:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "خب، باشه، عجله کن وگرنه جفتمون میوفتیم تو همین سلول";
                break;
            case 9:
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "چشم، الان در رو میشکونم";
                break;
            case 10:
                ToEnemy.enabled = true;
                GuideText.text = "راهنمایی: بر روی در ضربه بزن";
                ContinueButton.SetEnabled(false);
                ContinueButton.text = "";
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
                CharacterName.text = "";
                CharacterImage.image = null;
                DialogText.text = "";
                brokethedoor = true;
                break;
            case 11:
                GuideText.text = "";
                ContinueButton.SetEnabled(true);
                ContinueButton.text = "Click To Continue";
                DialogBackground.style.backgroundColor = new StyleColor(Color.darkCyan);
                CharacterName.text = "سیروس";
                CharacterImage.image = SiroosProfile.texture;
                DialogText.text = "زود باش، بدو بریم";
                break;
            case 12:
                CharacterName.text = "فاطمه";
                CharacterImage.image = QueenProfile.texture;
                DialogText.text = "باشه، اومدم!";
                break;
            case 13:
                ContinueButton.SetEnabled(false);
                ContinueButton.text = "";
                DialogBackground.style.backgroundColor = new StyleColor(Color.clear);
                CharacterName.text = "";
                CharacterImage.image = null;
                DialogText.text = "";
                CamAnimator.SetTrigger("Black");
                StartCoroutine(LoadLevel("Part4"));
                break;
        }
    }
    public void NextDialog()
    {
        DialogNumber++;
        SetDialogText();
    }
    private void OnFight()
    {
        if (ToEnemy != null)
        {
           
            GuideText.text = "راهنمایی: بر روی راهزن ضربه بزن"  + "\n تعداد کشته ها = " + ToEnemy.kills; 

            if (ToEnemy.kills >= 3)
            {
                NextDialog();
                fight = false;
            }
        }
    }
    private void Click()
    {
        if(ToEnemy != null)
        {
            if(ToEnemy.ClickedObject == "Door")
            {
                NextDialog();
                brokethedoor = false;
            }
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
