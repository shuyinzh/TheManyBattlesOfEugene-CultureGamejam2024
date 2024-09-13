using TMPro;
using UnityEngine;

public class NpcInfo : MonoBehaviour
{
    public NPC npc;
    public TMP_Text nameText;
    public TMP_Text hpText;
    
    private void Update()
    {
        nameText.text = npc.Name;
        hpText.text = npc.Health.currentHP + " / " + npc.Health.maxHP;
    }
}