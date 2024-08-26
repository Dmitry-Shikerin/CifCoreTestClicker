using Sources.BoundedContexts.Energies.Controllers;
using Sources.BoundedContexts.Energies.Presentation.Interfaces;
using Sources.Frameworks.Presentation;
using Sources.Frameworks.Presentation.Components.Images.Implementation;
using Sources.Frameworks.Presentation.Components.Images.Interfaces;
using UnityEngine;

namespace Sources.BoundedContexts.Energies.Presentation.Implementation
{
    public class EnergyView : PresentableView<EnergyPresenter>, IEnergyView
    {
        [SerializeField] private ImageView _imageView;
        
        public IImageView ImageView => _imageView;
    }
}