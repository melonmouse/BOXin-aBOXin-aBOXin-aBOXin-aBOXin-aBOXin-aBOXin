using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnItems : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;
    
    [SerializeField]
    private Transform itemsContainer;

    [SerializeField]
    private Transform start;
    
    [SerializeField]
    private Transform end;

    [SerializeField]
    private float rateAtWhichItemsAreSpawnedInSeconds = 3.0f;
    float nextTime = 0;
    
    [SerializeField]
    private bool shouldSpawnItems;

    private Queue<GameObject> _items;
    private const int _itemsCapacity = 100;

    private void Start()
    {
        _items = new Queue<GameObject>(_itemsCapacity);
        nextTime = Time.time;
    }

    private void Update()
    {
        if (shouldSpawnItems)
        {
            if (Time.time >= nextTime &&
                _items.Count < _itemsCapacity)
            {
                nextTime += rateAtWhichItemsAreSpawnedInSeconds; 
                
                var item = Instantiate(prefabs[Random.Range(0, prefabs.Count)], GetRandomPointBetweenStartAndEnd(),
                    Random.rotation);
                
                item.transform.SetParent(itemsContainer);
                
                _items.Enqueue(item);
            }

            if (_items.Count == _itemsCapacity)
            {
                var itemToDestroy = _items.Dequeue();
                try { Destroy(itemToDestroy); }
                catch (Exception) { Debug.Log("Was already destroyed"); }
            }
        }
    }

    private Vector3 GetRandomPointBetweenStartAndEnd()
    {
        return Vector3.Lerp(start.position, end.position, Random.Range(0f, 1f));

    }
}
