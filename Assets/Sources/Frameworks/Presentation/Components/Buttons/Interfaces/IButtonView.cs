using System;
using UnityEngine.Events;

namespace Sources.Frameworks.Presentation.Components
{
    public interface IButtonView
    {
        void AddClickListener(UnityAction onClick);
        void RemoveClickListener(UnityAction onClick);
    }
}