namespace SolidPrinciple
{
    public interface IPlayer
    {

        public abstract bool NextStep();
    }
    public abstract class Player : IPlayer
    {
        public abstract bool NextStep();
    }

    public interface IHuman : IPlayer
    {
        public string PlayerName { get; set; }
        public int attempt { get; set; }
        public int secretNumber { get; set; }
    }

    public interface IComputer : IPlayer
    {
        public GameSettings gameSettings { get; set; }
        public List<int> PlayersAttempts { get; set; }
    }

    public class HumanPlayer : Player, IHuman
    {
        public string PlayerName { get; set; }
        public int attempt { get; set; }
        public int secretNumber { get; set; }


        public HumanPlayer(string Name)
        {
            PlayerName = Name;
            attempt = 0;
        }
        public override bool NextStep()
        {
            attempt++;
            return true;
        }
    }

    public class ComputerPlayer : Player, IComputer
    {
        public GameSettings gameSettings { get; set; }
        public List<int> PlayersAttempts { get; set; }
        
        public ComputerPlayer()
        {
            gameSettings = new();
        }

        public override bool NextStep()
        {
            return true;
        }
    }
}
