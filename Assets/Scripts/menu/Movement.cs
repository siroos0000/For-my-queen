using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    CharacterController chController;
    Vector3 v3;
    bool movement = true;
    public Animator QueenAnimation,CamShowmenu;
    public UIDocument uIDocument;
    private Button GameStarter;
    private Label LoadingScreen,GameNAme;
    public bool Options = false;
    void Start()
    {
        chController = GetComponent<CharacterController>();
        var root = uIDocument.rootVisualElement;
        GameStarter = root.Q<Button>("GameStarter");
        LoadingScreen = root.Q<Label>("LoadingScreen");
        GameNAme = root.Q<Label>("GameNAme");
        GameStarter.clicked += OnClick;
    }
    void Update()
    {
        if(movement)
        {
            move();
        }
        if(Options)
        {
            OptionShow();
            Options = false;
        }
    }
    public void move()
    {
        v3 = new Vector3(speed * Time.deltaTime, 0, 0);
        chController.Move(v3);
        QueenAnimation.SetBool("IsWalking", true);
    }
    public void ShowMenu()
    {
        movement = false;
        QueenAnimation.SetBool("IsWalking", false);
        CamShowmenu.Play("MenuShow");
    }
    public void OptionShow()
    {
        GameStarter.text = "شروع بازی";
        GameStarter.SetEnabled(true);
        GameNAme.text = "For my Queen <size=110> <color=#FF0000>❤</color> </size>";
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
          ShowMenu();
        }
    }
    private void OnClick()
    {
        Debug.Log("Button clicked!");
        LoadingScreen.style.backgroundColor = new StyleColor(Color.black);
        GameNAme.text = "";
        GameStarter.text = "";
        GameStarter.SetEnabled(false);
        StartCoroutine(LoadLevel("START"));
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
            LoadingScreen.text = "در حال بارگذاری بخش بعد... "
                                + progress.ToString("F0") + "%";

            Debug.Log("Loading: " + progress + "%");

            yield return null;
        }
    }

}
