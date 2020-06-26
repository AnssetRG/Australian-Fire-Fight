using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonFileReader : MonoBehaviour {
    public static string LoadJsonAsResource(string path) {
        string jsonFilePath = path.Replace(".json", "");
        TextAsset loadedJsonFile = Resources.Load<TextAsset>(jsonFilePath);
        return loadedJsonFile.text;
    }
}
