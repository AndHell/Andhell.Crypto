namespace Andhell.Crypto
{
    public interface IKey
    {
        byte[] Bytes { get; }

        IProtectedKey Storable();

        void Clear();
    }

    public interface IProtectedKey
    {
        byte[] ProtectedBytes { get; }

        string ProtectedString { get; }

        void Clear();
    }
}