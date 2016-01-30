namespace GGJ.Movement
{
    public interface IEntityController
    {
        float GetMovementAxis();
        event Action Jump;
        event Action Attack;
    }
}
