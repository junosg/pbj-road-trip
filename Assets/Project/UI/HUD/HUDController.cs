using UnityEngine;
using UnityEngine.UIElements;

public class HUDController : MonoBehaviour
{
    UIDocument _hudDocument;
    VisualElement _sanityBarFill;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hudDocument = GetComponent<UIDocument>();

        _sanityBarFill = _hudDocument.rootVisualElement.Q<VisualElement>("sanity-bar-fill");
        _sanityBarFill.style.backgroundColor = Color.green;

        if (SanityManager.Instance)
        {
            Debug.Log("Sanity Manager Exists");
            SanityManager.Instance.SanityUpdated.AddListener(SetSanityBarFillSize);
        }
    }

    public void SetSanityBarFillSize(float value)
    {
        Length widthLength = new(value, LengthUnit.Percent);

        if (value > 40) _sanityBarFill.style.backgroundColor = Color.green;
        else  _sanityBarFill.style.backgroundColor = Color.red;

        _sanityBarFill.style.width = widthLength;
    }
}
