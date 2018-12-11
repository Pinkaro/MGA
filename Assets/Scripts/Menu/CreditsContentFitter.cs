using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsContentFitter : MonoBehaviour {

    public void Awake()
    {
        Vector2 min = new Vector2();
        Vector2 max = new Vector2();

        foreach (Transform child in transform)
        {
            //Debug.Log(child.GetComponent<RectTransform>().rect.width);
            //Debug.Log(child.GetComponent<RectTransform>().rect.height);
            RectTransform rTrans = child.GetComponent<RectTransform>();

            //min
            if ((child.position.x) < min.x)
            {
                min.x = child.position.x;
            }
            if ((child.position.y - (rTrans.rect.height/2f)) < min.y)
            {
                min.y = child.position.y - (rTrans.rect.height / 2f);
            }

            //max
            if (child.position.x < max.x)
            {
                max.x = child.position.x;
            }
            if ((child.position.y + (rTrans.rect.height / 2f)) > max.y)
            {
                max.y = child.position.y + (rTrans.rect.height / 2f);
            }            
        }

        Debug.Log("Size X: " + (max.x - min.x));
        Debug.Log("Size Y: " + (max.y - min.y));
    }

}
