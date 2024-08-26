using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.BoundedContexts.AutoCollectors.Domain;
using Sources.BoundedContexts.AutoCollectors.Presentation.Interfaces;
using Sources.Frameworks.Controllers.Implementation;
using UnityEngine;

namespace Sources.BoundedContexts.AutoCollectors.Controllers
{
    public class CurrencyAutoCollectorPresenter : PresenterBase
    {
        private readonly CurrencyCollector _currencyCollector;
        private readonly ICurrencyCollectorView _view;

        private CancellationTokenSource _tokenSource;
        private TimeSpan _delay;

        public CurrencyAutoCollectorPresenter(
            CurrencyCollector currencyCollector,
            ICurrencyCollectorView view)
        {
            _currencyCollector = currencyCollector ?? throw new ArgumentNullException(nameof(currencyCollector));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            _tokenSource = new CancellationTokenSource();
            _delay = TimeSpan.FromSeconds(1);
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
                    Debug.Log($"Add currency");
                }
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}