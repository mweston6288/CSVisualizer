namespace Algorithms
{


    abstract class Algorithm
    {
        private int memoryUse;
        private int stackSize;

        protected int MemoryUse { get => memoryUse; set => memoryUse = value; }
        protected int StackSize { get => stackSize; set => stackSize = value; }
    }
}