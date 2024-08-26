using Sources.Frameworks.Presentation.Base.Interfaces;
using UnityEngine;

namespace Sources.Frameworks.Presentation.Base.Implementation
{
    public class View : MonoBehaviour, IView
    {
        public Transform Transform => transform;

        public void Destroy() =>
            Object.Destroy(gameObject);

        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);

        public void SetParent(Transform parent) =>
            transform.SetParent(parent);
    }
}