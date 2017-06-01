using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour {

    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float xoffset = 100f;
    public float yoffset = 100f;
    // Use this for initialization
    private void Start()
    {
        xoffset = Random.Range(0f, 9999f);
        yoffset = Random.Range(0f, 9999f);
    }
    void Update () {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
	}
	
    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        // Generate a perlin noise map for the texture
        for(int x = 0; x < width; ++x)
        {
            for(int y = 0; y < height; ++y)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }

    Color CalculateColor (int x, int y)
    {
        float xCoord = (float) x / width * scale + xoffset;
        float yCoord = (float) y / height * scale + yoffset;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
