using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckersGamemanager : MonoBehaviour
{
    public GameObject prefabCar;
    private int blockedLane;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabCar, new Vector3(-10, 0.5f, -6), Quaternion.identity);
        Instantiate(prefabCar, new Vector3(10, 0.5f, -1.5f), Quaternion.identity);
        Instantiate(prefabCar, new Vector3(10, 0.5f, 3), Quaternion.identity);
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
}
