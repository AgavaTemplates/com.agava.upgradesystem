
namespace Agava.UpgradeSystem
{
    public interface IUpgrade<out TItem>
    {
        TItem Current { get; }
    }
}