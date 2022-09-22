using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityGoogleDrive;
using System.IO;

public class TesFormDrive : MonoBehaviour
{
    public string UrlLink = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScgDT0d1BA4X4ZRuxDQJM8Bkww_ktvvAsYkCt75DTCudd_dVw/formResponse";
    public string PathGambar = "";
    byte[] texturebytes = null;
    public TMP_InputField txtNama;
    public TMP_InputField txtUmur;
    public TMP_InputField txtAsalSekolah;
    public TMP_Dropdown dropDownJenisKelamin;

    public GoogleDriveSettings setting;
    private GoogleDriveFiles.CreateRequest request;
    private void Awake()
    {
        if (string.IsNullOrEmpty(setting.CachedAccessToken))
            setting.CachedAccessToken = "ya29.a0Aa4xrXPyA2z_3jwFYL4io0YLhM8Z7A77nqZQPazJjdGEImXflRCfjNgXBWkmmLyeW2vKXv7UfpAvlL0VVWVi4zalXlHrfDch7NCfsgaXqFksoS5biSlCg861muQjdlBe_7jAMGDvdHakXQqGYGfPP7QlaHiNaCgYKATASARESFQEjDvL9eczm9sQCOvcSmdVksWbVgg0163";

        if (string.IsNullOrEmpty(setting.CachedRefreshToken))
            setting.CachedRefreshToken = "1//0gX1nIcmXITFtCgYIARAAGBASNwF-L9Irk4jsZoWAHtHywTrzlfBi4-WzMDp7R7H0SknwShFY5x2lSGem7PJiNC0RYTWn59xdpu8";
    }
    public void Send()
    {
        StartCoroutine(SendData());

     
    }
    public void OpenGallery()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, -1);
                if (texture == null)
                {
                    print("Couldn't load texture from " + path);
                    return;
                }

                ImagePicked(texture, path);
            }
        });
    }

    private void ImagePicked(Texture2D _tex, string _path)
    {
        print($"Creating image from {_path}");
        PathGambar = _path;

        Texture2D imgTexture = _tex;
        texturebytes = Helper.duplicateTexture(_tex).EncodeToPNG();

        var content = File.ReadAllBytes(PathGambar);
        if (content == null) return;

        var file = new UnityGoogleDrive.Data.File() { Name = "File Gambar-2.png", Content = content };
        file.Parents = new List<string> { "1efZwRuWhztl_wva_zMuPlcscOL2_j2mR" };
        request = GoogleDriveFiles.Create(file);
        request.Fields = new List<string> { "id", "name", "size", "createdTime" };
        request.Send();

    }

    IEnumerator SendData()
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.1975545117", txtNama.text);
        form.AddField("entry.1965812888", txtUmur.text);
        form.AddField("entry.1748279103", txtAsalSekolah.text);
        form.AddField("entry.1709586220", (dropDownJenisKelamin.value == 0) ? "Laki-laki" : "Perempuan");    
        UnityWebRequest www = UnityWebRequest.Post(UrlLink, form);

        yield return www.SendWebRequest();

        if (!string.IsNullOrEmpty(www.error))
        {
            print(www.error);
            yield break;
        }

        print(www.downloadHandler.text);


        yield break;
    }
}
