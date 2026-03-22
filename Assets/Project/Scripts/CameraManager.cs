using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineCamera _camera;

    public static CameraManager Instance { get; private set; }
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    public void ZoomIn()
    {
        _camera.Lens.FieldOfView = 40;
    }

    public void ZoomOut()
    {
        _camera.Lens.FieldOfView = 60;
    }
}
