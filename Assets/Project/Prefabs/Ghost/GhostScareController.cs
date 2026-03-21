using UnityEngine;

public class GhostScareController : MonoBehaviour
{
    private Animator _animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TriggerScare()
    {
        _animator.SetTrigger("Scare");
    }
}
