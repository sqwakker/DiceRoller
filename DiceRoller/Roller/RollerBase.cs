namespace DiceRoller.Roller;

abstract class RollerBase : IRoller
{
    protected Random Rand { get; }

    protected RollerBase()
    {
        Rand = new Random((int)(DateTime.Now.Ticks));
    }

    public string Name => this.GetType().Name;
    public abstract string Description { get; }
    public abstract bool Success(int target);

    protected int GetDiceRoll()
    {
        return Rand.Next(1, 7);
    }

    protected abstract bool RollDices(int target);
}