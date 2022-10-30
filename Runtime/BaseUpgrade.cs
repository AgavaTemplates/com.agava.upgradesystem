using System;

namespace Agava.UpgradeSystem
{
    public class BaseUpgrade<TItem, TPrice> : IUpgrade<TItem>
    {
        private readonly ISave<int> _save;
        private readonly IUpgradeItems<TItem> _itemList;
        private readonly IPriceList<TPrice> _priceList;
        private readonly IUpgradeView<TItem, TPrice> _view;

        public BaseUpgrade(ISave<int> save, IUpgradeItems<TItem> upgradeList, IPriceList<TPrice> priceList, IUpgradeView<TItem, TPrice> view)
        {
            _save = save;
            _itemList = upgradeList;
            _priceList = priceList;
            _view = view;

            if (upgradeList.MaxLevel - priceList.MaxLevel != 1)
                throw new InvalidOperationException();
        }

        public TItem Current
        {
            get
            {
                var level = _save.Load();
                return _itemList.Item(level);
            }
        }

        public void Upgrade(IPaySource<TPrice> paySource)
        {
            var level = _save.Load();

            if (level >= _itemList.MaxLevel - 1)
                throw new InvalidOperationException();

            var payResult = paySource.Pay(_priceList.Price(level));

            if (payResult != PayResult.Completed)
                throw new InvalidOperationException();

            level++;
            _save.Save(level);

            if (level < _priceList.MaxLevel)
                _view.Render(level, _itemList.Item(level), _priceList.Price(level));
            else
                _view.RenderCompleted(level, _itemList.Item(level));
        }
    }
}