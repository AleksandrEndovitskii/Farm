using UnityEngine;
using Utils;

namespace Managers
{
    public class ImageManager : MonoBehaviour, IInitializable
    {
        private string _imagesFolderName;

        public void Initialize()
        {
            _imagesFolderName = "Images";
        }

        public Sprite GetImage(string imageName)
        {
            var sprite = Resources.Load<Sprite>(_imagesFolderName + "/" + imageName);

            if (sprite == null)
            {
                Debug.LogWarning(string.Format("No image was provided for {0} - loaded sprite is empty.", imageName));
            }

            return sprite;
        }
    }
}
