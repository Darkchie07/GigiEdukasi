using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Threading.Tasks;

public class PageFotoScript : MonoBehaviour
{
    [SerializeField] private GameObject _objCameraTengah;
    [SerializeField] private GameObject _scrollViewImage;
    [SerializeField] private Transform _contentParentImage;
    [SerializeField] private Image _prefabImg;
    [SerializeField] private List<GameObject> _listObjImageCreated;
    public GameObject ImageShow;

    public RespondenData.GambarGigi targetGigi;
    #region MONOBEHAVIOUR FUNCTION

    private void OnEnable()
    {
        GetListImage();
    }

    #endregion

    void GetListImage()
    {
        //get the data image
        targetGigi = RespondenData.Instance.dataGambarGigi.listGambarGigi[PemantauanSikatGigiManager.Instance.selectedIndexHari];

        if (targetGigi.listImageGigi.Count == 0) // datanya kosong
        {
            _objCameraTengah.SetActive(true);
            _scrollViewImage.SetActive(false);
            ClearDataImage();
        }
        else
        {
            _objCameraTengah.SetActive(false);
            _scrollViewImage.SetActive(true);
            ClearDataImage();

            //create the image
            foreach (var a in targetGigi.listImageGigi)
            {
                Texture2D tex = Helper.Base64ToTexture(a);
                CreateImage(tex);
            }

        }
    }

    void ClearDataImage()
    {
        foreach (var a in _listObjImageCreated)
            Destroy(a);
        _listObjImageCreated.Clear();
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
        _scrollViewImage.SetActive(true);
        _objCameraTengah.SetActive(false);
        print($"Creating image from {_path}");
        CreateImage(_tex, true);
    }


    private void CreateImage(Texture2D _tex, bool save = false)
    {
        GameObject newImg = Instantiate(_prefabImg.gameObject, _contentParentImage);
        newImg.SetActive(true);

        Image _theImage = newImg.GetComponent<Image>();

        _theImage.preserveAspect = true;
        _theImage.SetNativeSize();

        //create sprite
        Sprite spriteFoto = Helper.TextureToSprite(_tex);
        _theImage.sprite = spriteFoto;

        //craete function Click the image
        newImg.GetComponent<Button>().onClick.AddListener(() =>
        {
            ImageShow.GetComponent<Image>().sprite = spriteFoto;
            ImageShow.GetComponent<Image>().preserveAspect = true;
            ImageShow.transform.parent.gameObject.SetActive(true);
            OrientationToAuto();
        });

        //tampung ke list
        _listObjImageCreated.Add(newImg);

        //scroll to bottom       
        StartCoroutine(scrollToBottom());

        if (save)
        {
            string _imageSaved = Helper.TextureToBase64(_tex);
            RespondenData.Instance.dataGambarGigi.SaveGambarGigi(targetGigi, _imageSaved);
        }
    }

    IEnumerator scrollToBottom()
    {
        yield return null;
        _scrollViewImage.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
    }

    public void OrientationToAuto() => StartCoroutine(ChangeOrienTation(false));


    public void OrientationToPortrait() => StartCoroutine(ChangeOrienTation(true));


    IEnumerator ChangeOrienTation(bool portrait)
    {
        yield return null;
        if (portrait)
            Screen.orientation = ScreenOrientation.Portrait;
        else
            Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
