using UnityEngine;
using UnityEngine.UI;

public class GhostScareController : MonoBehaviour
{
    [SerializeField] Texture2D _highSanityGhost;
    [SerializeField] Texture2D _lowSanityGhost;

    private Animator _animator;
    private RawImage _rawImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rawImage = GetComponent<RawImage>();

        SanityManager.Instance.SanityUpdated.AddListener(OnSanityUpdated);
    }

    public void TriggerScare()
    {
        _animator.SetTrigger("Scare");
    }

    private void OnSanityUpdated(float value)
    {
        if (value <= SanityManager.LOW_SANITY_THRESHOLD)
        {
            _rawImage.texture = _lowSanityGhost;
        }
    }
}
