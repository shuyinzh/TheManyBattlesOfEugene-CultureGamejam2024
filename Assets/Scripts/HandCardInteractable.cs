using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardInteractable : MonoBehaviour
{
    public GameObject selectedObject;
    public Player player;
    Vector3 originalPosition;
    Vector3 offset;
    
    public static event Action<GameObject> OnCardPlayed;

    void Update()
    {
        // click and drag
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

            if (targetObject && targetObject.transform.gameObject == transform.gameObject)
            {
                selectedObject = targetObject.transform.gameObject;
                originalPosition = targetObject.transform.position;
                offset = selectedObject.transform.position - mousePosition;
            }
        }

        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }

        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            ReleaseCard(mousePosition);
        }
    }

    void ReleaseCard(Vector3 releasingPosition)
    {
        // if card is in upper half of the screen, releasing it plays the card. otherwise it is returned to the hand.
        if (releasingPosition.y >= 0)
        {
            Debug.Log("Releasing card!");

            if (player.HasSufficientZeitgeist(selectedObject.GetComponent<BaseCard>().Cost))
            {
                // play card
                // TODO: visual feedback - green shimmer?
                Debug.Log("Can play card! Cost: " + selectedObject.GetComponent<BaseCard>().Cost + " Current Zeitgeist: " + player.Zeitgeist);
                OnCardPlayed?.Invoke(selectedObject);
                selectedObject.transform.position = originalPosition - new Vector3(-5f, 5f, 0); // TODO animate being put in discard pile
                selectedObject = null;
            }
            else 
            {
                // TODO: visual feedback - red shimmer?
                Debug.Log("CANNOT play card! Cost: " + selectedObject.GetComponent<BaseCard>().Cost + " Current Zeitgeist: " + player.Zeitgeist);
                selectedObject.transform.position = originalPosition;
                selectedObject = null;
            }



        }
        else
        {
            selectedObject.transform.position = originalPosition;
            selectedObject = null;
        }
    }
}