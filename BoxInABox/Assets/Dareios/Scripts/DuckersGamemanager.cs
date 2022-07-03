using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckersGamemanager : MonoBehaviour
{
    public GameObject prefabCar;
    public GameObject prefabBaseItems;
    public GameObject heldItem;
    public GameObject itemManager;
    public GameObject player;

    private int blockedLane;
    private bool itemActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabCar, new Vector3(-10, 0.5f, -6), Quaternion.LookRotation(Vector3.right));
        Instantiate(prefabCar, new Vector3(10, 0.5f, -1.5f), Quaternion.LookRotation(Vector3.left));
        Instantiate(prefabCar, new Vector3(10, 0.5f, 3), Quaternion.LookRotation(Vector3.left));

        System.Random rnd = new System.Random();
        int lane = rnd.Next(1, 4);
        Instantiate(prefabBaseItems.GetComponent<BoxItemMapping>().GetItemPrefab(BoxItemState.Item.Banana), new Vector3(Random.Range(-7f, 7f), 0.5f, changeItemLane(lane)), Quaternion.Euler(-16.9f, 27.8f, 84.9f));
        lane = rnd.Next(1, 4);
        Instantiate(prefabBaseItems.GetComponent<BoxItemMapping>().GetItemPrefab(BoxItemState.Item.Mallet), new Vector3(Random.Range(-7f, 7f), 0.5f, changeItemLane(lane)), Quaternion.Euler(-24.1f, 50.2f, -41.8f));
        lane = rnd.Next(1, 4);
        Instantiate(prefabBaseItems.GetComponent<BoxItemMapping>().GetItemPrefab(BoxItemState.Item.Motorcycle), new Vector3(Random.Range(-7f, 7f), 0.5f, changeItemLane(lane)), Quaternion.Euler(0f, -90f, -60f));
        lane = rnd.Next(1, 4);
        Instantiate(prefabBaseItems.GetComponent<BoxItemMapping>().GetItemPrefab(BoxItemState.Item.ButterflyCatchingNet), new Vector3(Random.Range(-7f, 7f), 0.5f, changeItemLane(lane)), Quaternion.Euler(2.4f, 60.4f, 50f));
        lane = rnd.Next(1, 4);
        Instantiate(prefabBaseItems.GetComponent<BoxItemMapping>().GetItemPrefab(BoxItemState.Item.HourGlass), new Vector3(Random.Range(-7f, 7f), 0.5f, changeItemLane(lane)), Quaternion.Euler(33.3f, 0f, 0f));


        heldItem = prefabBaseItems.GetComponent<BoxItemMapping>().GetHeldItemPrefab();
        if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.Banana)
        {
            ActivateItemNumbered(0);
        }
        else if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.ButterflyCatchingNet)
        {
            ActivateItemNumbered(1);
        }
        else if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.Mallet)
        {
            ActivateItemNumbered(2);
        }
        else if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.Motorcycle)
        {
            ActivateItemNumbered(3);
        }
        else if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.HourGlass)
        {
            ActivateItemNumbered(4);
        }
    }

    public void ActivateItemNumbered(int itemNumber)
    {
        for(int i = 0; i < itemManager.transform.childCount; i++)
        {
            Debug.Log("set false");
            itemManager.transform.GetChild(i).gameObject.SetActive(false);
        }
        Debug.Log("set active");
        itemManager.transform.GetChild(itemNumber).gameObject.SetActive(true);
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
                Instantiate(prefabCar, new Vector3(-12, 0.5f, -6), Quaternion.LookRotation(Vector3.right));
            }
            else
            {
                Instantiate(prefabCar, new Vector3(12, 0.5f, carLane * 4.5f - 10.5f), Quaternion.LookRotation(Vector3.left));
            }

            blockedLane = carLane;
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Return))
        {
            if (!itemActivated)
            {
                ActivateItem();
                itemActivated = true;
            }
        }
    }

    void ActivateItem()
    {
        if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.Banana)
        {
            player.transform.localScale *= 2;
        }
        else if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.ButterflyCatchingNet)
        {
            System.Random rnd = new System.Random();
            int objectIndex = rnd.Next(0, GameObject.FindGameObjectsWithTag("itemToCollect").Length);
            GameObject.FindGameObjectsWithTag("itemToCollect")[objectIndex].transform.position = player.transform.position;
        }
        else if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.Mallet)
        {
            System.Random rnd = new System.Random();
            int objectIndex = rnd.Next(0, GameObject.FindGameObjectsWithTag("duckersCar").Length);
            Destroy(GameObject.FindGameObjectsWithTag("duckersCar")[objectIndex]);
        }
        else if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.Motorcycle)
        {
            player.GetComponent<DuckersCarController>().setSpeed(4.8f);
        }
        else if (heldItem.GetComponent<ItemIdentifier>().item == BoxItemState.Item.HourGlass)
        {
            prefabCar.GetComponent<DuckersCarController>().setSpeed(4.0f);
        }
    }

    float changeItemLane(int randomized)
    {
        if (randomized == 1)
        {
            return -4.5f;
        }
        else if (randomized == 2)
        {
            return 0.0f;
        }
        else
        {
            return 4.5f;
        }
    }
}
