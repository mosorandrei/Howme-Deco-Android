using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DataHandler : MonoBehaviour
{
    private GameObject furniture;
    private int currId = 0;

    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items;
    [SerializeField] private string label;
    
    private static DataHandler instance;
    public static DataHandler Instance 
    {   get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }


    private async void Start()
    {
        items = new List<Item>();

        // LoadItems();

        await Get(label);
        CreateButtons();
    }

    // void LoadItems()
    // {
    //     var itemsObj = Resources.LoadAll("Items", typeof(Item));
    //     foreach (var item in itemsObj)
    //     {
    //         items.Add(item as Item);
    //     }
    // }

    void CreateButtons()
    {
        foreach (Item i in items)     
        {
            ButtonManager buttonManager = Instantiate(buttonPrefab, buttonContainer.transform);
            buttonManager.ItemId = currId;
            buttonManager.ButtonSprite = i.itemImage;
            currId++;
        }

        buttonContainer.GetComponent<UIContentFitter>().Fit();
    }

    public void SetFurniture(int id)
    {
        furniture = items[id].itemPrefab;
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }

    public async Task Get(string label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
        foreach (var location in locations)
        {
            print("[ADDRESSABLE] Loading asset!");
            var obj = await Addressables.LoadAssetAsync<Item>(location).Task;
            items.Add(obj);
        }
    }
}
