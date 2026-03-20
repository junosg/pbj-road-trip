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
        Debug.Log(_sanityBarFill);

        if (SanityManager.Instance)
        {
            Debug.Log("Sanity Manager Exists");
            SanityManager.Instance.SanityUpdated.AddListener(SetSanityBarFillSize);
        }
    }

    public void SetSanityBarFillSize(float value)
    {
        Debug.Log(value);
        Length widthLength = new(value, LengthUnit.Percent);
        _sanityBarFill.style.width = widthLength;
    }
}
