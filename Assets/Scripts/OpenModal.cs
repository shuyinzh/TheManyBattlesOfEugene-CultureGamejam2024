using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenModal : MonoBehaviour
{
    public GameObject[] modals;
    public GameObject closeButton;
    private GameObject activeModal; 

    public void LoadModal(string modalName)
    {
        foreach (GameObject o in modals)
        {
            if (o.name == modalName)
            {
                o.SetActive(true);
                activeModal = o;
                closeButton.SetActive(true);
            }
        }
    }

    public void CloseModal()
    {
        activeModal.SetActive(false);
        closeButton.SetActive(false);
    }
}
