
namespace Agava.UpgradeSystem
{
    public interface IPriceList<out TPrice>
    {
        int MaxLevel { get; }
        TPrice Price(int level);
    }
}