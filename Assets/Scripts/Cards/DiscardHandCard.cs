public class DiscardHandCard : BaseCard
{
    public override void whenPlayed()
    {
        battleManager.playDiscardCard();
    }
}