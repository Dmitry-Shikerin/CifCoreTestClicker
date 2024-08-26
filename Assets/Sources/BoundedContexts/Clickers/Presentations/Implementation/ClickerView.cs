using Sources.BoundedContexts.Clickers.Controllers;
using Sources.BoundedContexts.Clickers.Presentations.Interfaces;
using Sources.Frameworks.Presentation;
using Sources.Frameworks.Presentation.Components;
using Sources.Frameworks.Presentation.Components.Buttons.Implementation;
using UnityEngine;

namespace Sources.BoundedContexts.Clickers.Presentations.Implementation
{
    public class ClickerView : PresentableView<ClickerPresenter>, IClickerView
    {
        [SerializeField] private ButtonView _clickButton;

        public IButtonView ClickButton => _clickButton;
    }
}