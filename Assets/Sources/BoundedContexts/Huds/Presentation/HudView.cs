using Sources.BoundedContexts.Clickers.Presentations.Implementation;
using Sources.Frameworks.Presentation;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.BoundedContexts.Huds.Presentation
{
    public class HudView : View
    {
        [field: SerializeField] public ClickerView ClickerView { get; private set; }
    }
}