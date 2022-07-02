using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturedObjectManager : MonoBehaviour
{

    public float capturedObjectRotationSpeed;
    public BoxItemMapping boxItemMapping;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("transform.childCount is " + transform.childCount);
        //transform.GetChild(2).gameObject.SetActive(true);
        ActivateObjectFromLastMiniGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, capturedObjectRotationSpeed * Time.deltaTime, 0);
    }

    void ActivateObjectFromLastMiniGame()
    {

        /*
        int objectNumberFromLastMiniGame = 0; //<-- if there is no object from last minigame
        ActivateItemNumbered(objectNumberFromLastMiniGame);
        */

        //here I fetch the item from last mini game
        GameObject heldItemPrefab = boxItemMapping.GetHeldItemPrefab(); // if there is an error it is the dot
        //GameObject heldItemPrefab = Instantiate(boxItemMapping.GetHeldItemPrefab(), GameObject.Find("ItemFromLastMiniGame").transform);

        // below I will activate on the current held object on the top right corner
        if (heldItemPrefab.GetComponent<ItemIdentifier>().item == BoxItemState.Item.Banana)
        {
            ActivateItemNumbered(0);
        }
        else if (heldItemPrefab.GetComponent<ItemIdentifier>().item == BoxItemState.Item.ButterflyCatchingNet)
        {
            ActivateItemNumbered(1);
        }
        else if (heldItemPrefab.GetComponent<ItemIdentifier>().item == BoxItemState.Item.Mallet)
        {
            ActivateItemNumbered(2);
        }
        else if (heldItemPrefab.GetComponent<ItemIdentifier>().item == BoxItemState.Item.Motorcycle)
        {
            ActivateItemNumbered(3);
        }
        else
        {
            // do nothing, because there is nothing to display since no item was passed from the last mini game
            // AND also set Motorcycle as held item in that case, so now, if the player does not catch any item, the motorcyle will be the item held to the next scene
            GameObject.Find("MotorcyclePlaceholder").GetComponent<ItemIdentifier>().SetAsHeldItem();
        }
    }

    // TODO: put all the items for the meta game as children of the Objectcaptured GameObject, pay attention to the order, because the child number will be the tag used when putting them under collectibles
    // TODO: put all the items as collectible as children of the Collectibles GameObject

    public void ActivateItemNumbered(int objectNumber)
    {
        // show object captured on the top right of screen
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(objectNumber).gameObject.SetActive(true);

    }
}
