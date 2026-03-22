using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MenuController : MonoBehaviour
{
    UIDocument _menuDocument;

    VisualElement _mainMenu;
    VisualElement _leaderboardMenu;
    MultiColumnListView _leaderboard;

    Button _startButton;
    Button _leaderboardButton;
    Button _leaderboardBackButton;
    Button _creditsButton;
    
    [SerializeField] AudioClip _buttonClickClip;
    [SerializeField] AudioClip _buttonHoverClip;
    [SerializeField] AudioClip _menuBGM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LeaderboardManager.Instance.GetTop10());
        _menuDocument = GetComponent<UIDocument>();

        _mainMenu = _menuDocument.rootVisualElement.Q<VisualElement>("main-menu");
        _leaderboardMenu = _menuDocument.rootVisualElement.Q<VisualElement>("leaderboard-menu");

        _leaderboard = _menuDocument.rootVisualElement.Q<MultiColumnListView>("leaderboard");

        _startButton = _menuDocument.rootVisualElement.Q<Button>("start-button");
        _leaderboardButton = _menuDocument.rootVisualElement.Q<Button>("leaderboard-button");
        _leaderboardBackButton = _menuDocument.rootVisualElement.Q<Button>("leaderboard-back-button");
        _creditsButton = _menuDocument.rootVisualElement.Q<Button>("credits-button");

        _startButton.clicked += OnStartButtonClick;
        _leaderboardButton.clicked += OnLeaderboardButtonClick;
        _leaderboardBackButton.clicked += OnLeaderboardBackButtonClick;
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

    void OnLeaderboardButtonClick()
    {
        SoundManager.Instance.PlaySfxOneShot(_buttonClickClip);
        
        _mainMenu.style.display = DisplayStyle.None;        
        _leaderboardMenu.style.display = DisplayStyle.Flex;
        
        _leaderboard.columns["player"].bindCell = (element, index) =>
        {
            (element as Label).text = LeaderboardManager.Instance.TopTen[index].player;
        };
        
        _leaderboard.columns["time"].bindCell = (element, index) =>
        {
            float.TryParse(LeaderboardManager.Instance.TopTen[index].time, out float value);
            int minutes = Mathf.FloorToInt(value / 60);
            int seconds = Mathf.FloorToInt(value % 60);
            (element as Label).text = $"{minutes:00}:{seconds:00}";
        };

        _leaderboard.itemsSource = LeaderboardManager.Instance.TopTen;
    }

    void OnLeaderboardBackButtonClick()
    {
        SoundManager.Instance.PlaySfxOneShot(_buttonClickClip);
        _mainMenu.style.display = DisplayStyle.Flex;        
        _leaderboardMenu.style.display = DisplayStyle.None;
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
