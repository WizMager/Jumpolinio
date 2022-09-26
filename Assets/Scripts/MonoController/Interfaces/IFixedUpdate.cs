namespace MonoController.Interfaces
{
    public interface IFixedUpdate : IController
    {
        void FixedUpdate(float fixedDeltaTime);
    }
}