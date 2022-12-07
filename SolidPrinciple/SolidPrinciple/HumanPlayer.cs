namespace SolidPrinciple
{
    /// <summary>
    /// Игрок - человек
    /// </summary>
    public class HumanPlayer : Player, IHuman
    {
        public string PlayerName { get; set; }
        public bool GameOver { get; set; } = false;

        public HumanPlayer(string Name)
        {
            PlayerName = Name;
        }
        public override bool NextStep()
        {
            return true;
        }
    }
}
