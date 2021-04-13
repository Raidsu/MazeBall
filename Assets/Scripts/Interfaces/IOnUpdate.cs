namespace Items
{
    public interface IUpdate : IController
    {
        void Execute(float deltaTime);
    }
}