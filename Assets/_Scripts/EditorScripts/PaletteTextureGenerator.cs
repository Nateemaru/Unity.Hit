using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.EditorScripts
{
    public class PaletteTextureGenerator : MonoBehaviour
    {
        [SerializeField] private int _width = 256;
        [SerializeField] private int _height = 32;

        [Button]
        private Texture2D GenerateColorPaletteTexture()
        {
            Texture2D texture = new Texture2D(_width, _height);

            float stepSize = 1f / _width;

            for (int x = 0; x < _width; x++)
            {
                Color color = Color.HSVToRGB(x * stepSize, 1f, 1f);

                for (int y = 0; y < _height; y++)
                {
                    texture.SetPixel(x, y, color);
                }
            }

            texture.Apply(); // Applies the changes to the texture
            SaveTextureToFile(texture, "ColorPalette.png");

            return texture;
        }

        private void SaveTextureToFile(Texture2D texture, string filename)
        {
            byte[] bytes = texture.EncodeToPNG();

            // Create a new folder called "Textures" in the project's "Assets" folder
            string folderPath = Application.persistentDataPath + "/" + filename;
            System.IO.Directory.CreateDirectory(folderPath);

            // Save the texture to the folder
            string filePath = folderPath + filename;
            System.IO.File.WriteAllBytes(filePath, bytes);

            // Refresh the Unity Editor to show the newly created file
            UnityEditor.AssetDatabase.Refresh();

            Debug.Log("Color palette saved to " + filePath);
        }
    }
}