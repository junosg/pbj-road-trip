using UnityEngine;

public class Mirror : MonoBehaviour, IEvent
{

    [SerializeField] private GameObject mirror;
    public bool hasAppeared = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mirror.SetActive(false);
    }
    
    public void Appear()
    {
        hasAppeared = true;
        mirror.SetActive(true);
        SanityManager.Instance.DecreaseSanity(3);
    }
}
