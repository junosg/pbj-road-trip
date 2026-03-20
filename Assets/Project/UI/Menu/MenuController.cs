using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MenuController : MonoBehaviour
{
    UIDocument _menuDocument;

    Button _startButton;
    Button _settingsButton;
    Button _creditsButton;
    
    [SerializeField] AudioClip _buttonClickClip;
    [SerializeField] AudioClip _buttonHoverClip;
    [SerializeField] AudioClip _menuBGM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _menuDocument = GetComponent<UIDocument>();
        _startButton = _menuDocument.rootVisualElement.Q<Button>("start-button");
        _settingsButton = _menuDocument.rootVisualElement.Q<Button>("settings-button");
        _creditsButton = _menuDocument.rootVisualElement.Q<Button>("credits-button");

        _startButton.clicked += OnStartButtonClick;
        _settingsButton.clicked += OnSettingsButtonClick;
        _creditsButton.clicked += OnCreditsButtonClick;

        _startButton.RegisterCallback<PointerEnterEvent>(OnButtonHover);
        _settingsButton.RegisterCallback<PointerEnterEvent>(OnButtonHover);
        _creditsButton.RegisterCallback<PointerEnterEvent>(OnButtonHover);

        SoundManager.Instance.PlayMusic(_menuBGM);
    }

    void OnStartButtonClick()
    {
        SoundManager.Instance.PlaySfxOneShot(_buttonClickClip);

        GameSceneManager.Instance.SmoothLoadScene(GameSceneManager.GAME_SCENE_INDEX);
    }

    void OnSettingsButtonClick()
    {
        SoundManager.Instance.PlaySfxOneShot(_buttonClickClip);
    }

    void OnCreditsButtonClick()
    {
        SoundManager.Instance.PlaySfxOneShot(_buttonClickClip);
    }

    void OnButtonHover(PointerEnterEvent evt)
    {
        SoundManager.Instance.PlaySfxOneShot(_buttonHoverClip);
    }
}
