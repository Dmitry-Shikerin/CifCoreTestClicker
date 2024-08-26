using System.Collections.Generic;
using Sources.BoundedContexts.SofCurrencyPopUps.Presentation;
using Sources.Frameworks.Presentation.Base.Interfaces;
using Sources.Frameworks.Presentation.Components;
using Sources.Frameworks.Presentation.Components.Texts.Interfaces;
using UnityEngine;

namespace Sources.BoundedContexts.Clickers.Presentations.Interfaces
{
    public interface IClickerView : IView
    {
        SoftCurrencyPopUpView PopUpPrefab { get; }
        IReadOnlyList<Transform> PopUpMovePoints { get; }
        ITextView AddedCurrencyText { get; }
        IButtonView ClickButton { get; }
    }
}