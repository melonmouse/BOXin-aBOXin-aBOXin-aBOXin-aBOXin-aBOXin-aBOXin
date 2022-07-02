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
    private float rateAtWhichItemsAreSpawned = 60.0f;
    
    [SerializeField]
    private bool shouldSpawnItems;

    private List<GameObject> _items;
    private const int _itemsCapacity = 10;

    private void Start()
    {
        _items = new List<GameObject>(_itemsCapacity);
    }

    private void Update()
    {
        if (shouldSpawnItems)
        {
            if (Time.frameCount % rateAtWhichItemsAreSpawned == 0 &&
                _items.Count < _itemsCapacity)
            {
                var item = Instantiate(prefabs[Random.Range(0, prefabs.Count - 1)], GetRandomPointBetweenStartAndEnd(),
                    Quaternion.identity);
                
                item.transform.SetParent(itemsContainer);
                
                _items.Add(item);
            }
        }
    }

    private Vector3 GetRandomPointBetweenStartAndEnd()
    {
        Debug.Log(Random.Range(0, 1));
        return Vector3.Lerp(start.position, end.position, Random.Range(0f, 1f));

    }
}
