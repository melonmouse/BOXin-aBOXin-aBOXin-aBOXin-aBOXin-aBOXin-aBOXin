using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckersGamemanager : MonoBehaviour
{
    public GameObject prefabCar;
    public GameObject prefabBaseItems;
    private int blockedLane;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabCar, new Vector3(-10, 0.5f, -6), Quaternion.identity);
        Instantiate(prefabCar, new Vector3(10, 0.5f, -1.5f), Quaternion.identity);
        Instantiate(prefabCar, new Vector3(10, 0.5f, 3), Quaternion.identity);

        System.Random rnd = new System.Random();
        int lane = rnd.Next(1, 4);
        Instantiate(prefabBaseItems.GetComponent<BoxItemMapping>().GetItemPrefab(BoxItemState.Item.Banana), new Vector3(Random.Range(-7f, 7f), 0.5f, changeItemLane(lane)), Quaternion.Euler(8f, 5f, 52.6f));
        lane = rnd.Next(1, 4);
        Instantiate(prefabBaseItems.GetComponent<BoxItemMapping>().GetItemPrefab(BoxItemState.Item.Mallet), new Vector3(Random.Range(-7f, 7f), 0.5f, changeItemLane(lane)), Quaternion.identity);
        lane = rnd.Next(1, 4);
        Instantiate(prefabBaseItems.GetComponent<BoxItemMapping>().GetItemPrefab(BoxItemState.Item.Motorcycle), new Vector3(Random.Range(-7f, 7f), 0.5f, changeItemLane(lane)), Quaternion.identity);
        lane = rnd.Next(1, 4);
        Instantiate(prefabBaseItems.GetComponent<BoxItemMapping>().GetItemPrefab(BoxItemState.Item.ButterflyCatchingNet), new Vector3(Random.Range(-7f, 7f), 0.5f, changeItemLane(lane)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] carsOnScreen = GameObject.FindGameObjectsWithTag("duckersCar");
        int numberOfCars = carsOnScreen.Length;

        if (numberOfCars < 6)
        {
            System.Random rnd = new System.Random();
            int carLane = rnd.Next(1, 4);
            while(carLane == blockedLane)
            {
                carLane = rnd.Next(1, 4);
            }
            if (carLane == 1)
            {
                Instantiate(prefabCar, new Vector3(-12, 0.5f, -6), Quaternion.identity);
            }
            else
            {
                Instantiate(prefabCar, new Vector3(12, 0.5f, carLane * 4.5f - 10.5f), Quaternion.identity);
            }

            blockedLane = carLane;
        }
    }

    float changeItemLane(int randomized)
    {
        if (randomized == 1)
        {
            return -6f;
        }
        else if (randomized == 2)
        {
            return -1.5f;
        }
        else
        {
            return 3f;
        }
    }
}
