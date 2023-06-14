using Sirenix.OdinInspector;
using UnityEngine;

namespace _Scripts.EditorScripts
{
    public class ChessboardTextureGenerator : MonoBehaviour
    {
        [SerializeField] private int size = 8; // Size of the chessboard (number of squares per side)
        [SerializeField] private int squareSize = 64; // Size of each square in pixels
        [SerializeField] private Color color1 = Color.white;
        [SerializeField] private Color color2 = Color.black;

        [Button]
        private Texture2D GenerateChessboardTexture()
        {
            Texture2D texture = new Texture2D(size * squareSize, size * squareSize);

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Color color = ((x + y) % 2 == 0) ? color1 : color2;

                    for (int i = 0; i < squareSize; i++)
                    {
                        for (int j = 0; j < squareSize; j++)
                        {
                            texture.SetPixel(x * squareSize + i, y * squareSize + j, color);
                        }
                    }
                }
            }

            texture.Apply(); // Applies the changes to the texture
            SaveTextureToFile(texture, "Chessboard.png");

            return texture;
        }

        private void SaveTextureToFile(Texture2D texture, string filename)
        {
            byte[] bytes = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.persistentDataPath + "/" + filename, bytes);
            Debug.Log("Chessboard texture saved to " + Application.dataPath + "/" + filename);
        }
    }
}