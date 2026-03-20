using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MenuController : MonoBehaviour
{
    UIDocument _menuDocument;

    Button _startButton;
    Button _settingsButton;
    Button _creditsButton;
    
    [SerializeField] AudioClip _buttonClick;

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
    }

    void OnStartButtonClick()
    {
        SoundManager.Instance.PlaySfx(_buttonClick);

        GameSceneManager.Instance.SmoothLoadScene(GameSceneManager.GAME_SCENE_INDEX);
    }

    void OnSettingsButtonClick()
    {
        SoundManager.Instance.PlaySfx(_buttonClick);
    }

    void OnCreditsButtonClick()
    {
        SoundManager.Instance.PlaySfx(_buttonClick);
    }
}
