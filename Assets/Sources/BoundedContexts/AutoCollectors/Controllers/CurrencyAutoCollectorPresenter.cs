using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.BoundedContexts.AutoCollectors.Presentation.Interfaces;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using Sources.Frameworks.Controllers.Implementation;

namespace Sources.BoundedContexts.AutoCollectors.Controllers
{
    public class CurrencyAutoCollectorPresenter : PresenterBase
    {
        private readonly SoftCurrency _softCurrency;
        private readonly ICurrencyCollectorView _view;

        private CancellationTokenSource _tokenSource;
        private TimeSpan _delay;

        public CurrencyAutoCollectorPresenter(
            SoftCurrency softCurrency,
            ICurrencyCollectorView view)
        {
            _softCurrency = softCurrency ?? throw new ArgumentNullException(nameof(softCurrency));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            _tokenSource = new CancellationTokenSource();
            _delay = TimeSpan.FromSeconds(_softCurrency.Delay);
            _view.DelayText.SetText(_softCurrency.Delay.ToString());
            _view.AmountText.SetText(_softCurrency.CollectorAddedValue.ToString());
            StartCollector();
        }

        public override void Disable()
        { 
            _tokenSource.Cancel();
        }

        private async void StartCollector()
        {
            try
            {
                while (_tokenSource.IsCancellationRequested == false)
                {
                    await UniTask.Delay(_delay, cancellationToken: _tokenSource.Token);
                    _softCurrency.Collect();
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}