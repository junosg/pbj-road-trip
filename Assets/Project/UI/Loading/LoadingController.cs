using UnityEngine;
using UnityEngine.UIElements;

public class LoadingController : MonoBehaviour
{
    UIDocument _loadingDocument;
    VisualElement _loadingBarFill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;

        _loadingDocument = GetComponent<UIDocument>();
        _loadingBarFill = _loadingDocument.rootVisualElement.Q<VisualElement>("loading-bar-fill");

        GameSceneManager.Instance.ProgressUpdated.AddListener(SetLoadingBarFillValue);
        GameSceneManager.Instance.LoadSceneAsync();
    }

    void SetLoadingBarFillValue(float value)
    {
        Length widthLength = new(Mathf.Clamp(value * 100, 0, 100), LengthUnit.Percent);
        _loadingBarFill.style.width = widthLength;
    }
}
