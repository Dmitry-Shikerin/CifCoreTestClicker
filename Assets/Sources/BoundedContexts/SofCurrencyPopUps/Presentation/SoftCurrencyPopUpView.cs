using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Frameworks.Presentation;
using Sources.Frameworks.Presentation.Base.Implementation;
using Sources.Frameworks.Presentation.Components.Texts.Implementation;
using Sources.Frameworks.Presentation.Components.Texts.Interfaces;
using UnityEngine;

namespace Sources.BoundedContexts.SofCurrencyPopUps.Presentation
{
    public class SoftCurrencyPopUpView : View
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private TextView _textView;

        private CancellationTokenSource _tokenSource;
        private List<Transform> _points;
        
        public ITextView TextView => _textView;

        private void OnEnable() =>
            _tokenSource = new CancellationTokenSource();

        private void OnDisable() =>
            _tokenSource.Cancel();

        public void SetPoints(IEnumerable<Transform> points) =>
            _points = new List<Transform>(points);

        public async void ShowPopUp()
        {
            try
            {
                foreach (Transform point in _points)
                    await Move(_tokenSource.Token, point.position);
                 
                Destroy();
            }
            catch (OperationCanceledException)
            {
            }
        }
        
        private void Move(Vector3 to)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, to, Time.deltaTime * _speed * 60);
        }
        
        private async UniTask Move(CancellationToken token, Vector3 to)
        {
            while (Vector3.Distance(transform.position, to) > 0.01f)
            {
                Move(to);
                await UniTask.Yield(token);
            }
        }
    }
}