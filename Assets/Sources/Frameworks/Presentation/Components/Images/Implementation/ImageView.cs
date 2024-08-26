using Sources.Frameworks.Presentation.Components.Images.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Frameworks.Presentation.Components.Images.Implementation
{
    public class ImageView : View, IImageView
    {
        [SerializeField] private Image _image;
        
        public void SetFillAmount(float value) =>
            _image.fillAmount = value;
    }
}