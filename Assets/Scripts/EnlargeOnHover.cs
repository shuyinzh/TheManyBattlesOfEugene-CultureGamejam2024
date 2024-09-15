using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeOnHover : MonoBehaviour
{
    Sprite sprite;
    Sprite highlightSprite;
    
    Vector3 originalPosition;
    Vector3 originalScale;
    Vector3 enlargedScale;

    string originalSortingLayerName;
    SpriteRenderer ownRenderer;
    SpriteRenderer artworkRenderer;
    Canvas canvasRenderer;
    SpriteRenderer glowRenderer1;
    SpriteRenderer glowRenderer2;

    bool enlarging = false;
    bool shrinking = false;

    bool isCardInHand = false; // TODO: if a card view modal is open, disable EnlargeOnHover for hand cards

    float enlargeSpeed = 5f;
    float shrinkSpeed = 7f;
    float upSpeed = 20f;

    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
        enlargedScale = originalScale * 1.8f;
        if (transform.parent.name == "CardHand")
        {
            isCardInHand = true;
        }
        ownRenderer = GetComponent<SpriteRenderer>();
        artworkRenderer = transform.Find("Artwork").GetComponent<SpriteRenderer>();
        canvasRenderer = transform.Find("Canvas").GetComponent<Canvas>();
        GameObject glowObject = transform.Find("Glow").gameObject;
        glowRenderer1 = glowObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        glowRenderer2 = glowObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        originalSortingLayerName = ownRenderer.sortingLayerName;
    }

    void Update()
    {
        if (enlarging)
        {
            ElevateSortingLayer();
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
                transform.localScale = enlargedScale;
                
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
                transform.localScale = originalScale;
                transform.position = originalPosition;
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
        ResetSortingLayer();
    }


    void ElevateSortingLayer()
    {
        ownRenderer.sortingLayerName = "SelectedCard";
        artworkRenderer.sortingLayerName = "SelectedCard";
        canvasRenderer.sortingLayerName = "SelectedCard";
        glowRenderer1.sortingLayerName = "SelectedCard";
        glowRenderer2.sortingLayerName = "SelectedCard";
    }

    void ResetSortingLayer()
    {
        ownRenderer.sortingLayerName = originalSortingLayerName;
        artworkRenderer.sortingLayerName = originalSortingLayerName;
        canvasRenderer.sortingLayerName = originalSortingLayerName;
        glowRenderer1.sortingLayerName = originalSortingLayerName;
        glowRenderer2.sortingLayerName = originalSortingLayerName;
    }
}
