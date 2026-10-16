
using UnityEngine;
using UnityEngine.UIElements;

public class Mute : MonoBehaviour
{
    public UIDocument UIDocument;
    public AudioSource audioSource;
    public Sprite MuteImage, UnmuteImage;
    private Label settingsPanel;
    private Slider volumeSlider;
    private Button muteButton;
    private Button settingButton;

    private bool mute = false;
    private bool setting = false;
    private float previousVolume = 1f;
    private const string VolumeKey = "SavedVolume";
    private void Start()
    {
        var root = UIDocument.rootVisualElement;

        
        settingsPanel = root.Q<Label>("SettingsPanel");
        volumeSlider = root.Q<Slider>("VolumeSlider");
        muteButton = root.Q<Button>("MuteButton");
        settingButton = root.Q<Button>("SettingButton");

        
        if (settingsPanel != null)
            settingsPanel.style.display = DisplayStyle.None;

        float savedVolume = PlayerPrefs.GetFloat(
             VolumeKey,
            audioSource != null ? audioSource.volume : 1f
            );
        if (volumeSlider != null && audioSource != null)
        {
            audioSource.volume = savedVolume;

            previousVolume = savedVolume > 0f ? savedVolume : 1f;
            mute = savedVolume <= 0f;
            audioSource.mute = mute;

            volumeSlider.lowValue = 0f;
            volumeSlider.highValue = 1f;
            volumeSlider.value = savedVolume;

            UpdateVolumeText(savedVolume);

            volumeSlider.RegisterValueChangedCallback(evt =>
            {
                ChangeVolume(evt.newValue);
                UpdateVolumeText(evt.newValue);
            });
        }


        if (muteButton != null)
            muteButton.clicked += OnClick;

        if (settingButton != null)
            settingButton.clicked += OnSettingClick;
    }
    public void OnClick()
    {
        if (audioSource == null)
            return;

        mute = !mute;

        if (mute)
        {
            if (audioSource.volume > 0)
                previousVolume = audioSource.volume;
            muteButton.iconImage = MuteImage.texture;
            audioSource.mute = true;
        }
        else
        {
            muteButton.iconImage = UnmuteImage.texture;
            audioSource.mute = false;
            audioSource.volume = previousVolume;
        }
    }

    public void OnSettingClick()
    {
        setting = !setting;

        if (settingsPanel != null)
        {
            settingsPanel.style.display = setting
                ? DisplayStyle.Flex
                : DisplayStyle.None;
        }
    }

    public void ChangeVolume(float value)
    {
        if (audioSource == null)
            return;

        audioSource.volume = value;

        
        PlayerPrefs.SetFloat(VolumeKey, value);

        if (value > 0f)
            previousVolume = value;

        mute = value <= 0f;
        audioSource.mute = mute;
    }

    private void UpdateVolumeText(float value)
    {
        if (volumeSlider != null)
        { 
            volumeSlider.label = $"Volume: {Mathf.RoundToInt(value * 100)}%";
        }
    }
    private void OnDestroy()
    {
        if (muteButton != null)
            muteButton.clicked -= OnClick;

        if (settingButton != null)
            settingButton.clicked -= OnSettingClick;

        PlayerPrefs.Save();
    }

}
