namespace MonteCarloPlayer
{
    public interface Copyable<T>
    {
        T DeepCopy();
        void CopyFrom(T other);
    }
}
