
namespace Agava.UpgradeSystem
{
    public interface ISave<T>
    {
        void Save(T value);
        T Load();
    }
}