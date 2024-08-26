using System;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.BoundedContexts.SofCurrencyPopUps.Presentation;
using Sources.BoundedContexts.SoftCurrencies.Domain.Models;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.BoundedContexts.SofCurrencyPopUps.Infrastructure.Factories.Views
{
    public class SoftCurrencyPopUpViewFactory
    {
        private readonly SoftCurrencyPopUpView _prefab;

        public SoftCurrencyPopUpViewFactory(SoftCurrencyPopUpView prefab)
        {
            _prefab = prefab ?? throw new ArgumentNullException(nameof(prefab));
        }

        public SoftCurrencyPopUpView Create(SoftCurrency softCurrency, IClickerView view)
        {
            SoftCurrencyPopUpView popUp = Object.Instantiate(
                _prefab, view.ClickButton.Position, Quaternion.identity);
            popUp.SetParent(view.Transform);
            popUp.TextView.SetText(softCurrency.CurrentAddedValue.ToString());
            popUp.SetPoints(view.PopUpMovePoints);
            RectTransform rect =popUp.Transform as RectTransform;
            rect.sizeDelta = new Vector2(1, 1);
            popUp.Show();
            popUp.ShowPopUp();

            return popUp;
        }
    }
}