using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeOnHover : MonoBehaviour
{
    Sprite sprite;
    Sprite highlightSprite;
    Vector3 originalScale;
    Vector3 enlargedScale;

    bool enlarging = false;
    bool shrinking = false;

    float enlargeSpeed = 5f;
    float shrinkSpeed = 7f;

    void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.8f;
    }

    void Update()
    {
        if (enlarging)
        {
            if (transform.localScale.x < enlargedScale.x)
            {
               transform.localScale += new Vector3(enlargeSpeed * Time.deltaTime, enlargeSpeed * Time.deltaTime, 0);
            }
            else 
            {
                enlarging = false;
            }
        }
        if (shrinking)
        {
            if (transform.localScale.x > originalScale.x)
            {
                transform.localScale -= new Vector3(shrinkSpeed * Time.deltaTime, shrinkSpeed * Time.deltaTime, 0);
            }
            else 
            {
                shrinking = false;
            }
        }
    }

    void OnMouseOver()
    {
        shrinking = false;
        enlarging = true;
    }

    void OnMouseExit()
    {
        enlarging = false;
        shrinking = true;
    }
}
