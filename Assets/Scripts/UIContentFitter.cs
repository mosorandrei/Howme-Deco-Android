using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContentFitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fit()
    {
        HorizontalLayoutGroup horizontalGroup = GetComponent<HorizontalLayoutGroup>();
        int childCount = transform.childCount - 1;
        float childWidth = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        float width = horizontalGroup.spacing * childCount + childWidth * childCount + horizontalGroup.padding.left;

        GetComponent<RectTransform>().sizeDelta = new Vector2(width, 200);
    }
}
