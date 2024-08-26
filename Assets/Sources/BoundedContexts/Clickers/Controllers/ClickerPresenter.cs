using System;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.BoundedContexts.Energies.Domain.Models;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using Sources.Frameworks.Controllers.Implementation;

namespace Sources.BoundedContexts.Clickers.Controllers
{
    public class ClickerPresenter : PresenterBase
    {
        private readonly Energy _energy;
        private readonly SoftCurrency _softCurrency;
        private readonly IClickerView _view;

        public ClickerPresenter(
            Energy energy,
            SoftCurrency softCurrency,
            IClickerView view)
        {
            _energy = energy ?? throw new ArgumentNullException(nameof(energy));
            _softCurrency = softCurrency ?? throw new ArgumentNullException(nameof(softCurrency));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public override void Enable() =>
            _view.ClickButton.AddClickListener(OnClick);

        public override void Disable() =>
            _view.ClickButton.RemoveClickListener(OnClick);

        private void OnClick()
        {
            if (_energy.TryTap() == false)
                return;
            
            _softCurrency.Increase();
        }
    }
}