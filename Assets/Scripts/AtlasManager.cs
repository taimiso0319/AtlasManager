using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AtlasManager : SingletonMonoBehaviour<AtlasManager> {

    private List<AtlasTexture> iconAtlasList = new List<AtlasTexture>();
    AtlasInfo info = new AtlasInfo();
    public struct AtlasInfo
    {
        public int atlasId;
        public int textureId;
        public Texture2D packedTexture;
        public Rect UVRect;
    }

    public AtlasInfo AddIconTextureToAtlas(Texture2D tex)
    {
        if (iconAtlasList.Count == 0)
        {
            iconAtlasList.Add(new AtlasTexture(1, 88));
        }
        else if(iconAtlasList.Single(a => a.atlasId == iconAtlasList.Count).textureCount >= 200)
        {
            iconAtlasList.Add(new AtlasTexture(iconAtlasList.Count+1, 88));
        }
        AtlasTexture tmp = iconAtlasList.Single(a => a.atlasId == iconAtlasList.Count);
        info.atlasId = iconAtlasList.Count;
        info.textureId = tmp.textureCount;
        info.UVRect = tmp.AddTexture(tex);
        info.packedTexture = tmp.packedTexture;
        return info;
    }
    
    public void InitializeList()
    {
        iconAtlasList.Add(new AtlasTexture(1, 88));
    }
}

public class AtlasTexture
{
    public int atlasId;
    public int textureCount;
    private int textureSquareSize;
    public Texture2D packedTexture;
    private Texture2D[] textures;
    private Rect[] UVRect;
    private int padding = 1;
    public AtlasTexture(int id, int texSize)
    {
        atlasId = id;
        textureCount = 0;
        textureSquareSize = texSize;
        packedTexture = new Texture2D(2048, 2048,TextureFormat.DXT1,false);
        textures = new Texture2D[220];
        for(int i = 0; i < textures.Length; i++)
        {
            textures[i] = new Texture2D(texSize, texSize, TextureFormat.DXT1, false);
        }
    }

    public Rect AddTexture(Texture2D tex)
    {
        textures[textureCount] = tex;
        textureCount++;
        UVRect = packedTexture.PackTextures(textures, padding, textureSquareSize * 10);
        return UVRect[textureCount-1];
    }
}