using Sources.Frameworks.Presentation.Base.Implementation;
using Sources.Frameworks.Presentation.Components.Texts.Interfaces;
using TMPro;
using UnityEngine;

namespace Sources.Frameworks.Presentation.Components.Texts.Implementation
{
    public class TextView : View, ITextView
    {
        [SerializeField] private TMP_Text _text;
        
        public void SetText(string text) =>
            _text.text = text;
    }
}