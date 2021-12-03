using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName="Add Item/Item")]

public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public float itemPrice;
    public GameObject itemPrefab;
    public Sprite itemImage;
}
