
public class TauntCard: BaseCard
{
    public int tauntValue;
    
    public override void whenPlayed()
    {
        battleManager.playTauntCard(tauntValue);
    }
}