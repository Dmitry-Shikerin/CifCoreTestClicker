using System.Collections.Generic;
using Sources.BoundedContexts.Clickers.Controllers;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.Frameworks.Presentation;
using Sources.Frameworks.Presentation.Base.Implementation;
using Sources.Frameworks.Presentation.Components;
using Sources.Frameworks.Presentation.Components.Buttons.Implementation;
using Sources.Frameworks.Presentation.Components.Buttons.Interfaces;
using Sources.Frameworks.Presentation.Components.Texts.Implementation;
using Sources.Frameworks.Presentation.Components.Texts.Interfaces;
using UnityEngine;

namespace Sources.BoundedContexts.Clickers.Presentations.Implementation
{
    public class ClickerView : PresentableView<ClickerPresenter>, IClickerView
    {
        [SerializeField] private TextView _addedCurrencyText;
        [SerializeField] private ButtonView _clickButton;
        [SerializeField] private List<Transform> _popUpMovePoints;

        public IReadOnlyList<Transform> PopUpMovePoints => _popUpMovePoints;
        public ITextView AddedCurrencyText => _addedCurrencyText;
        public IButtonView ClickButton => _clickButton;
    }
}