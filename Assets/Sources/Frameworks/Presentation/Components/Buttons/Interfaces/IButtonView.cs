using System;
using UnityEngine;
using UnityEngine.Events;

namespace Sources.Frameworks.Presentation.Components
{
    public interface IButtonView
    {
        Vector3 Position { get; }
        
        void AddClickListener(UnityAction onClick);
        void RemoveClickListener(UnityAction onClick);
    }
}