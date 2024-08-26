using UnityEngine;

namespace Sources.Frameworks.Presentation.Base.Interfaces
{
    public interface IView
    {
        Transform Transform { get; }

        void Destroy();
        void Show();
        void Hide();
        void SetParent(Transform parent);
    }
}