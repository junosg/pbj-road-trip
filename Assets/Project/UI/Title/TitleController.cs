using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField] GameObject _titleLoad;
    [SerializeField] GameObject _panel;
    [SerializeField] TMP_InputField _playerNameField;
    [SerializeField] Button _enterButton;

    void Start()
    {
        _enterButton.onClick.AddListener(OnEnterButtonClicked);
    }

    public void DisplayPanel()
    {
        _panel.SetActive(true);
        _titleLoad.SetActive(false);
    }

    public void IncreaseTextScale()
    {
        _enterButton.gameObject.GetComponent<RectTransform>().localScale = new(1.2f, 1.2f, 1.2f);
    }

    public void RevertTextScale()
    {
        _enterButton.gameObject.GetComponent<RectTransform>().localScale = new(1, 1, 1);
    }

    private void OnEnterButtonClicked()
    {
        PlayerDataManager.Instance.SetPlayerName(_playerNameField.text);
        SceneManager.LoadScene(GameSceneManager.MENU_SCENE_INDEX);
    }
}
