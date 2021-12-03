using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    private Sprite buttonSprite;
    [SerializeField] private RawImage buttonImage;
    private int itemId;

    public int ItemId
    {
        set
        {
            itemId = value;
        }
    }

    public Sprite ButtonSprite
    {
        set
        {
            buttonSprite = value;
            buttonImage.texture = buttonSprite.texture;
        }
    } 

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(UIManager.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 1.2f, 0.2f);
        }
        else
        {
            transform.DOScale(Vector3.one, 0.2f);
        }
    }

    void SelectObject()
    {
        DataHandler.Instance.SetFurniture(itemId);
    }
}
