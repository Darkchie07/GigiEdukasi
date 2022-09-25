using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
using UnityGoogleDrive;

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
    /// LOGOUT SYSTEM
    /// </summary>
    public static void LogOut()
    {
        RespondenData.Instance.currentDataSelected.status = "1";
        RespondenData.Instance.SaveDataResponden();
        RespondenData.Instance.RemoveDataGigi();
        RespondenData.Instance.RemoveDebris();
        Debug.Log("logout");
    }


    #region CHANGE SCENE
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

    public static void GoToHomeMenu()
    {
        ChangeScene("HomeMenu");
    }
    #endregion

    #region METHOD TO UPLOAD FORM RESPONDEN DATA
    private static string UrlFormRespondenData = "https://docs.google.com/forms/d/e/1FAIpQLScg6Da0f_0NEzxQ_1Vb493TqvcdES0GsobKzj1noiaOt5ZzJg/formResponse";
    public static IEnumerator CoroutineUploadFormRespondenData(string _nama, string _umur, string _sekolah, string _jnsKelamin, Action _success, Action _error)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.2022054591", _nama);
        form.AddField("entry.1244274817", _umur);
        form.AddField("entry.1004956508", _sekolah);
        form.AddField("entry.1943644062", _jnsKelamin);

        UnityWebRequest www = UnityWebRequest.Post(UrlFormRespondenData, form);


        yield return www.SendWebRequest();


        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            _error();
            yield break;
        }

        _success();
        www.Dispose();
        yield break;

    }

    public static IEnumerator CoroutineUploadFormGigiResponden()
    {
        yield break;
    }

    #endregion

    #region DRIVE FUNCTION TO UPLOAD IMAGE

    public static string CachedAccessToken = "";
    public static string CachedRefreshToken = "";
    public static string ParentFolderImageHarianResponden = "";
    public static string ParentFolderImageFormGigiResponden = "";
    public enum ImageUploadType
    {
        ImageHarian,
        ImageJenisGigi
    }

    /// <summary>
    /// fungsi untuk upload file foto ke drive
    /// </summary>
    /// <param name="_onDoneAction">method on success</param>
    /// <param name="_pathFile">location file image</param>
    /// <param name="_uploadtype">upload type nya</param>
    public static void UploadImageHarianResponden(Action<UnityGoogleDrive.Data.File> _onDoneAction, string _pathFile, ImageUploadType _uploadtype)
    {
        var content = File.ReadAllBytes(_pathFile);
        if (content == null) return;
        string _fileName = "";
        var file = new UnityGoogleDrive.Data.File() { Name = Path.GetFileName(_fileName), Content = content };

        string _useParent = (_uploadtype == ImageUploadType.ImageHarian) ? ParentFolderImageHarianResponden : ParentFolderImageFormGigiResponden;
        file.Parents = new List<string> { _useParent };

        GoogleDriveFiles.CreateRequest request;
        request = GoogleDriveFiles.Create(file);
        request.Fields = new List<string> { "id", "name", "size", "createdTime" };
        request.Send().OnDone += _onDoneAction;
    }


    #endregion
}
