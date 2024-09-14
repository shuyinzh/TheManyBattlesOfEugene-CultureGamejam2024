using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZeitgeistDisplay : MonoBehaviour
{
    public TMP_Text text;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.Zeitgeist.ToString();
    }
}
