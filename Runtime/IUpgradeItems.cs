
namespace Agava.UpgradeSystem
{
    public interface IUpgradeItems<out TItem>
    {
        int MaxLevel { get; }
        TItem Item(int level);
    }
}