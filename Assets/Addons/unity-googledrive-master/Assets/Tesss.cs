using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using TMPro;
public class Tesss : MonoBehaviour
{
    public string _pathFile;
    public string _fileName;
    public TextMeshProUGUI txtcomplete;

    private void Start()
    {
        OpenGallery();
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
                _pathFile = path;
                TesData();
            }
        });
    }

    [ContextMenu("UPLOAD FILE")]
    public void TesData()
    {
        StartCoroutine(UploadFile());
    }

    IEnumerator UploadFile()
    {
        var drive = new GoogleDrive();
        drive.ClientID = "1013018033444-t6lqdn5aefb9tkosquo32gdi70cmvrbq.apps.googleusercontent.com";
        drive.ClientSecret = "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";

        //drive.AccessToken = "ya29.a0Aa4xrXM1eX1ck_lf52bDBdA8G-1cs9ToUQg5j8ybPRu7b-vg3O54sv0S9YWTaaRuZJTnJF4aboL7ByL7HPsxwzVhSmQ1B7fSR0oMOQ_GfptAiGQt_b8jxIYfJPTrXBsQycpLA4rShgI2L2FkfxmVkF4GZejuaCgYKATASARISFQEjDvL9PvNjV1sEtMr5fJB8VzcuMg0163";

        // Request authorization.
        var authorization = drive.Authorize();
        yield return StartCoroutine(authorization);

        if (authorization.Current is Exception)
        {
            Debug.LogWarning(authorization.Current as Exception);
            yield break;
        }
        // Authorization succeeded.
        Debug.Log("User Account: " + drive.UserAccount);
        print($"Access Token : {drive.AccessToken}");
        print($"Refresh Token : {drive.RefreshToken}");

        // Upload a text file.
        //var bytes = File.ReadAllBytes(_pathFile);
        Dictionary<string, object>[] a = new Dictionary<string, object>[]
        {
            new Dictionary<string, object>()
            {
                {"id","1efZwRuWhztl_wva_zMuPlcscOL2_j2mR" }
            }
        };
        var file = new GoogleDrive.File(new Dictionary<string, object>
        {
            { "title", "text_file.txt" },
            { "mimeType", "text/plain" },
            { "description", "This is a text file." },
            {"parents", a }
        });
        //yield return StartCoroutine(drive.UploadFile(_fileName, "image/png", bytes));
        var bytes = File.ReadAllBytes(_pathFile);
        yield return StartCoroutine(drive.UploadFile(_fileName, "image/png", file, bytes));
        txtcomplete.text = "COMPLETE";
    }
}
