using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private GraphicRaycaster raycaster;
    private PointerEventData pointerData;
    private EventSystem eventSystem;

    public Transform selectionPoint;

    private static UIManager instance;

    public static UIManager Instance 
    {   get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
        pointerData = new PointerEventData(eventSystem);

        pointerData.position = selectionPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool OnEntered(GameObject button) 
    {
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
        {
            if(result.gameObject == button)
            {
                return true;
            }
        }

        return false;
    }
}
