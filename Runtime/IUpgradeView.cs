
namespace Agava.UpgradeSystem
{
    public interface IUpgradeView<TItem, TPrice>
    {
        void Render(int currentLevel, TItem item, TPrice price);
        void RenderCompleted(int currentLevel, TItem item);
    }
}