namespace GGJ.Movement
{
    public class PlayerEntity : Entity
    {
        public PlayerEntity()
            : base(new PlayerController())
        { }
    }
}
