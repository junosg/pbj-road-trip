using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public enum GameOverType
{
    SANITY,
    CRASH
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private UIDocument _gameOverDocument;
    private VisualElement _gameOverElement;
    private VisualElement _sanityOverElement;
    private VisualElement _crashOverElement;
    private Button _retryButton;
    private Button _exitButton;

    [SerializeField] AudioClip _gameOverClip;

    private bool _isGameOver = false;

    public UnityEvent GameOver = new();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    void Start()
    {
        _gameOverDocument = GetComponent<UIDocument>();
        _gameOverElement = _gameOverDocument.rootVisualElement.Q<VisualElement>("game-over");
        _sanityOverElement = _gameOverDocument.rootVisualElement.Q<VisualElement>("game-over-sanity");
        _crashOverElement = _gameOverDocument.rootVisualElement.Q<VisualElement>("game-over-crash");
        _retryButton = _gameOverDocument.rootVisualElement.Q<Button>("retry-button");
        _exitButton = _gameOverDocument.rootVisualElement.Q<Button>("exit-button");

        _retryButton.clicked += OnRetry;
        _exitButton.clicked += OnExit;
    }

    public void SetGameOver(GameOverType gameOverType)
    {
        if (_isGameOver) return;
        _isGameOver = true;

        _gameOverElement.style.display = DisplayStyle.Flex;
        SoundManager.Instance.StopAll();
        SoundManager.Instance.PlaySfxOneShot(_gameOverClip);

        if (gameOverType == GameOverType.SANITY)
        {
            _sanityOverElement.style.display = DisplayStyle.Flex;
        } else
        {
            _crashOverElement.style.display = DisplayStyle.Flex;
        }

        GameOver.Invoke();
    }

    private void OnRetry()
    {
        GameSceneManager.Instance.SmoothLoadScene(GameSceneManager.GAME_SCENE_INDEX);
    }

    private void OnExit()
    {
        GameSceneManager.Instance.SmoothLoadScene(GameSceneManager.MENU_SCENE_INDEX);
    }
}
