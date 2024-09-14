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

    bool isCardInHand = false; // TODO: if a card view modal is open, disable EnlargeOnHover for hand cards

    float enlargeSpeed = 5f;
    float shrinkSpeed = 7f;
    float upSpeed = 20f;

    void Start()
    {
        originalScale = transform.localScale;
        enlargedScale = originalScale * 1.8f;
        if (transform.parent.name == "CardHand")
        {
            isCardInHand = true;
        }
    }

    void Update()
    {
        if (enlarging)
        {
            if (transform.localScale.x < enlargedScale.x)
            {
               transform.localScale += new Vector3(enlargeSpeed * Time.deltaTime, enlargeSpeed * Time.deltaTime, 0);
               if (isCardInHand) 
                {
                    transform.position += new Vector3(0, upSpeed * Time.deltaTime, 0);
                }
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
                if (isCardInHand) 
                {
                    transform.position -= new Vector3(0, upSpeed * shrinkSpeed / enlargeSpeed * Time.deltaTime, 0);
                }
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
