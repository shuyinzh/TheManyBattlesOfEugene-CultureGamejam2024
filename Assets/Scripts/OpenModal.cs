using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenModal : MonoBehaviour
{
    public GameObject[] modals;

    public void LoadModal(string modalName)
    {
        foreach (GameObject o in modals)
        {
            if (o.name == modalName)
            {
                o.SetActive(true);
            }
        }
    }

    public void CloseModal(string modalName)
    {
        foreach (GameObject o in modals)
        {
            if (o.name == modalName)
            {
                o.SetActive(false);
            }
        }
    }
}
