public class CharmeCard : BaseCard
{
    public int charmValue;
    
    public override void whenPlayed()
    {
        battleManager.playCharmeCard(charmValue);
    }
}