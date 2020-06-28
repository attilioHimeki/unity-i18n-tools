using UnityEngine;
using System.Linq;

namespace Himeki.i18n
{

    [CreateAssetMenu(fileName = "Localised Sprites Setup", menuName = "Himeki/i18n/Localised Sprites Setup", order = 1)]
    public class LocalisedSpritesSetup : ScriptableObject
    {
        [SerializeField] private Sprite defaultSprite;
        [Tooltip("List of sprites for each language to be supported in the game.")]
        [SerializeField] private LocalisedSpriteEntry[] localisedSprites;

        [System.Serializable]
        public struct LocalisedSpriteEntry
        {
            public SystemLanguage language;
            public Sprite sprite;
        }

        public Sprite getSpriteForLanguage(SystemLanguage lang)
        {
            for (int i = 0; i < localisedSprites.Length; i++)
            {
                if (localisedSprites[i].language == lang)
                {
                    return localisedSprites[i].sprite;
                }
            }

            return defaultSprite;
        }
    }
}
