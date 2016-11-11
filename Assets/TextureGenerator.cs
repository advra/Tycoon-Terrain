using UnityEngine;
using System.Collections;

public static class TextureGenerator {

    //method to create a texture out of a one dimension color method

    public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        //this is used to fix texture to have true color (no blur)
        texture.filterMode = FilterMode.Point;      //linear mooth smooth and point for pixel perfect
        texture.wrapMode = TextureWrapMode.Clamp;   //prevents render of image seeping through
        texture.SetPixels(colorMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);

        Color[] colorMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]);
            }
        }
        return TextureFromColorMap(colorMap, width, height);
    }
}
