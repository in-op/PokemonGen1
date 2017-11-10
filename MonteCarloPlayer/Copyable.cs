namespace MonteCarloPlayer
{
    public interface Copyable<T>
    {
        T DeepCopy();
        void CopyTo(T other);
    }
}
