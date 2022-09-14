using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class RespondenData : MonoBehaviour
{
    [System.Serializable]
    public class SaveData
    {
        public List<Responden> listResponden;
    }

    [System.Serializable]
    public class Responden
    {
        public string nama;
        public string umur;
        public string sekolah;
        public string jenisKelamin;
        public List<GambarGigi> daftarGambargigi;
        public string status;
    }

    [System.Serializable]
    public class GambarGigi
    {
        public List<string> listImageGigi;
    }

    [System.Serializable]
    public class StringImageGigi
    {
        public string image;
    }

    public SaveData saveData;


    [ContextMenu("CONVERT JSON")]
    public void ConvertToJson()
    {
        string json = JsonUtility.ToJson(saveData);
        print(json);

        string _path = Application.persistentDataPath + "/savefile.json";
        print(_path);
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, json);
            print("created");
        }
    }


    [ContextMenu("LOAD DATA")]
    public void LoadFile()
    {
        string _path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(_path))
        {
            string _data = File.ReadAllText(_path);

            saveData = JsonUtility.FromJson<SaveData>(_data);
        }
    }
}
