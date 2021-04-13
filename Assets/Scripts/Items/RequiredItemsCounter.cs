namespace Items
{
    public class RequiredItemsCounter
    {
        internal ushort CurentNumOfRequiredItems { get; set; }

        public RequiredItemsCounter()
        {
            CurentNumOfRequiredItems = 0;
        }

        internal void IncreaseCounter()
        {
            if (CurentNumOfRequiredItems<3)
                CurentNumOfRequiredItems++;
        }

        internal ushort GetCounterValue()
        {
            return CurentNumOfRequiredItems;
        }
    }
}