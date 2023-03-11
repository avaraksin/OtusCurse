namespace Clonable
{
    public interface IMyCloneable<T> where T : class
    {
        public T MyClone();
    }
}
