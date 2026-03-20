using UnityEngine;

public class Mirror : SanityEvents
{
    
    public override bool Active { get; set; }
    [SerializeField] private GameObject mirror;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mirror.SetActive(false);
    }
    
    public override void Appear()
    {
        Debug.Log("Radio Appear");
        Active = true;
        mirror.SetActive(true);
        SanityManager.Instance.DecreaseSanity(3);
    }

    
}
