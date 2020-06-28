using UnityEngine;
using UnityEngine.UI;

namespace Himeki.i18n
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class ImageLocalisator : BaseLocalisator
    {

        [SerializeField] private LocalisedSpritesSetup spritesSetup;

        private Image image;

        void Awake()
        {
            image = GetComponent<Image>();
        }
        public override void refresh()
        {
            refreshImage();
        }

        public void refreshImage()
        {
            SystemLanguage currentLanguage = LocalisationManager.instance.getCurrentLanguage().getLanguage();
            image.sprite = spritesSetup.getSpriteForLanguage(currentLanguage);
        }
    }

}