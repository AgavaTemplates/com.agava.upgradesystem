
namespace Agava.UpgradeSystem
{
    public interface IPaySource<in TPrice>
    {
        PayResult Pay(TPrice price);
    }
}