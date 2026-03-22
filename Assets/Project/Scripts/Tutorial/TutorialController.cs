using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class TutorialController : MonoBehaviour
{
    UIDocument _tutorialDocument;
    VisualElement _sanityTutorial;
    VisualElement _stalkerTutorial;
    VisualElement _passengerTutorial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _tutorialDocument = GetComponent<UIDocument>();
        _sanityTutorial = _tutorialDocument.rootVisualElement.Q<VisualElement>("sanity-tutorial");
        _stalkerTutorial = _tutorialDocument.rootVisualElement.Q<VisualElement>("stalker-tutorial");
        _passengerTutorial = _tutorialDocument.rootVisualElement.Q<VisualElement>("passenger-tutorial");

        StartCoroutine("DisplaySanityTutorial", 3f);
    }

    public IEnumerator DisplaySanityTutorial(float vanishDelay)
    {
        _sanityTutorial.style.display = DisplayStyle.Flex;

        yield return new WaitForSeconds(vanishDelay);

        _sanityTutorial.style.display = DisplayStyle.None;
    }

    public IEnumerator DisplayStalkerTutorial(float vanishDelay)
    {
        _stalkerTutorial.style.display = DisplayStyle.Flex;

        yield return new WaitForSeconds(vanishDelay);

        _stalkerTutorial.style.display = DisplayStyle.None;
    }

    public IEnumerator DisplayPassengerTutorial(float vanishDelay)
    {
        _passengerTutorial.style.display = DisplayStyle.Flex;

        yield return new WaitForSeconds(vanishDelay);

        _passengerTutorial.style.display = DisplayStyle.None;
    }
}
