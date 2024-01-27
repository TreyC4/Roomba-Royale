using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] Camera _camera;
    [SerializeField] int _offsetX;
    [SerializeField] int _offsetY;

    GameObject _spawnedObject;

    int _randomX;
    int _randomY;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Spawn();
        }
    }

    void Spawn(){
        int randomObjectId = Random.Range(0, _objects.Length);
        Vector2 position = GetRandomCoordiantes();
        _spawnedObject = Instantiate(_objects[randomObjectId], position, Quaternion.identity) as GameObject;
    }

    Vector2 GetRandomCoordiantes(){
        _randomX = Random.Range(0 + _offsetX, Screen.width - _offsetX);
        _randomY = Random.Range(0 + _offsetY, Screen.height - _offsetY);
        
        Vector2 coordinates = new Vector2(_randomX, _randomY);

        Vector2 screenToWorldPosition = _camera.ScreenToWorldPoint();

        return screenToWorldPosition;
    }
}
