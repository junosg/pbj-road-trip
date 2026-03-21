using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MenuController : MonoBehaviour
{
    UIDocument _menuDocument;

    VisualElement _mainMenu;
    VisualElement _settingsMenu;

    Button _startButton;
    Button _creditsButton;
    
    [SerializeField] AudioClip _buttonClickClip;
    [SerializeField] AudioClip _buttonHoverClip;
    [SerializeField] AudioClip _menuBGM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _menuDocument = GetComponent<UIDocument>();

        _mainMenu = _menuDocument.rootVisualElement.Q<VisualElement>("main-menu");

        _startButton = _menuDocument.rootVisualElement.Q<Button>("start-button");
        _creditsButton = _menuDocument.rootVisualElement.Q<Button>("credits-button");

        _startButton.clicked += OnStartButtonClick;
        _creditsButton.clicked += OnCreditsButtonClick;

        _startButton.RegisterCallback<PointerEnterEvent>(OnButtonHover);
        _creditsButton.RegisterCallback<PointerEnterEvent>(OnButtonHover);

        SoundManager.Instance.PlayMusic(_menuBGM);
    }

    void OnStartButtonClick()
    {
        SoundManager.Instance.PlaySfxOneShot(_buttonClickClip);

        GameSceneManager.Instance.SmoothLoadScene(GameSceneManager.GAME_SCENE_INDEX);
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
