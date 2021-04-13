namespace Items
{
    internal sealed class RequiredItems : Items
    {
        internal override void DoEffect()
        {
            GetSetCounter(0);
            GetSetCounter(1);
        }
    }
}