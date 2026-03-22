using UnityEngine;
using UnityEngine.UIElements;

public class HUDController : MonoBehaviour
{
    UIDocument _hudDocument;
    VisualElement _sanityBarFill;

    [SerializeField] Color _highSanityFillColor;
    [SerializeField] Color _lowSanityFillColor;
    Label _timer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hudDocument = GetComponent<UIDocument>();

        _sanityBarFill = _hudDocument.rootVisualElement.Q<VisualElement>("sanity-bar-fill");        
        _timer = _hudDocument.rootVisualElement.Q<Label>("timer");

        if (SanityManager.Instance)
        {
            Debug.Log("Sanity Manager Exists");
            SanityManager.Instance.SanityUpdated.AddListener(SetSanityBarFillSize);
        }

        if (TimerController.Instance)
        {
            Debug.Log("Timer Exists");
            TimerController.Instance.TimerUpdated.AddListener(SetTimer);
        }
    }

    public void SetSanityBarFillSize(float value)
    {
        Length widthLength = new(value, LengthUnit.Percent);

        if (value > 40) _sanityBarFill.style.backgroundColor = _highSanityFillColor;
        else  _sanityBarFill.style.backgroundColor = _lowSanityFillColor;

        _sanityBarFill.style.width = widthLength;
    }

    public void SetTimer(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        _timer.text = $"{minutes:00}:{seconds:00}";
    }
}
