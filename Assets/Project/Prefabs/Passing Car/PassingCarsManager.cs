using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder;

public class PassingCarsManager : MonoBehaviour
{
    [SerializeField] float _spawnDelay = 20f;
    [SerializeField] float _spawnRate = 5f;
    [SerializeField] GameObject _carPool;
    [SerializeField] Transform[] _spawnPoints;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnCar", _spawnDelay, _spawnRate);

        GameManager.Instance.GameOver.AddListener(OnGameOver);
    }

    void SpawnCar()
    {
        Transform[] cars = _carPool.GetComponentsInChildren<Transform>(true);
        Transform[] inactiveCars = cars.Where((car) => car.gameObject.activeSelf == false).ToArray();

        if (inactiveCars.Length <= 0) return;

        int carIndex = Random.Range(0, inactiveCars.Length);
        int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

        if (inactiveCars[carIndex].gameObject.activeSelf) return;

        inactiveCars[carIndex].transform.position = _spawnPoints[spawnPointIndex].position;
        inactiveCars[carIndex].gameObject.SetActive(true);
    }

    void OnGameOver()
    {
        Transform[] cars = _carPool.GetComponentsInChildren<Transform>();

        foreach(Transform car in cars)
        {
            car.gameObject.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
