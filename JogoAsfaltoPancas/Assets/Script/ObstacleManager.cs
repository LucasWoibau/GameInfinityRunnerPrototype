using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] tilesPrefab;

    private Transform _playerTransform;

    [SerializeField]
    private float _spawnZ = -6.0f;
    [SerializeField]
    private int _tileLenght;

    [SerializeField]
    private int _amnTilesOnScreen = 2;
    [SerializeField]
    private int _lastPrefabIndex = 0;

    private float _safeZone = 30f;

    private List<GameObject> _activeTiles;

    void Start()
    {
        _activeTiles = new List<GameObject>();

        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < _amnTilesOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
        }
    }

    void Update()
    {
        if (_playerTransform.position.z - _safeZone > (_spawnZ - _amnTilesOnScreen * _tileLenght))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilesPrefab[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilesPrefab[prefabIndex]);
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * _spawnZ;
        _spawnZ += _tileLenght;
        _activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if(tilesPrefab.Length <= 1)
        {
            return 0;
        }     
        
        int randomIndex = _lastPrefabIndex;
        while(randomIndex == _lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilesPrefab.Length);
        }

        _lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
