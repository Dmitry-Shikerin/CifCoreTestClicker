using Sources.Frameworks.Presentation.Base.Implementation;
using Sources.Frameworks.Presentation.Components.Buttons.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Sources.Frameworks.Presentation.Components.Buttons.Implementation
{
    public class ButtonView : View, IButtonView
    {
        [SerializeField] private Button _button;

        public Vector3 Position => transform.position;

        public void AddClickListener(UnityAction onClick) =>
            _button.onClick.AddListener(onClick);

        public void RemoveClickListener(UnityAction onClick) =>
            _button.onClick.RemoveListener(onClick);
    }
}