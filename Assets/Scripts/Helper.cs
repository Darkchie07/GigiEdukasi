using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class Helper
{

    /// <summary>
    /// convert texture2d ke sprite
    /// </summary>
    /// <param name="_tex"></param>
    /// <returns></returns>
    public static Sprite TextureToSprite(Texture2D _tex)
    {
        Sprite newSprite = Sprite.Create(_tex, new Rect(0.0f, 0.0f, _tex.width, _tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        return newSprite;
    }


    /// <summary>
    /// convert texture2d menjadi base64 string
    /// </summary>
    /// <param name="tex"></param>
    /// <returns></returns>
    public static string TextureToBase64(Texture2D tex)
    {
        if (tex == null)
            return null;

        byte[] pngByte = duplicateTexture(tex).EncodeToPNG();
        string b64 = Convert.ToBase64String(pngByte);
        return b64;
    }

    /// <summary>
    /// convert b64 string jadi texture
    /// </summary>
    /// <param name="base64"></param>
    /// <returns></returns>
    public static Texture2D Base64ToTexture(string base64)
    {
        if (string.IsNullOrEmpty(base64))
            return null;



        byte[] pngByte = Convert.FromBase64String(base64);

        Texture2D tex = new Texture2D(128, 128);
        tex.LoadImage(pngByte);

        return tex;
    }

    public static Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }


    /// <summary>
    /// change scene
    /// </summary>
    /// <param name="_targetSceneName"></param>
    public static void ChangeScene(string _targetSceneName)
    {
        SceneManager.LoadScene(_targetSceneName);
    }

    public static void GoToPemantauanSikatGigi()
    {
        ChangeScene("PemantauanSikatGigi");
    }

    /// <summary>
    /// LOGOUT SYSTEM
    /// </summary>
    public static void LogOut()
    {
        RespondenData.Instance.currentDataSelected.status = "1";
        RespondenData.Instance.SaveData();
        Debug.Log("logout");
    }

}
