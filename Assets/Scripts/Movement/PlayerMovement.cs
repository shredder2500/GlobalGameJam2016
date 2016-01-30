namespace GGJ.Movement
{
    public class PlayerEntity : BaseMovement
    {
        public PlayerEntity()
            : base(new PlayerController())
        { }
    }
}
