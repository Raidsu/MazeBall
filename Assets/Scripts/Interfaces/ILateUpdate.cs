namespace Items
{
    public interface ILateUpdate : IController
    {
        void LateExecute(float deltaTime);
    }
}