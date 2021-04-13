namespace Items
{
    public interface ILateUpdate
    {
        void LateExecute(float deltaTime);
    }
}