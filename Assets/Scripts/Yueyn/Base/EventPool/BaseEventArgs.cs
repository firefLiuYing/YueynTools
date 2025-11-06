using Yueyn.Base.ReferencePool;

namespace Yueyn.Base.EventPool
{
    public abstract class BaseEventArgs:IReference
    {
        public BaseEventArgs()
        {
            
        }

        public abstract int Id { get; }
        public abstract void Clear();
    }
}