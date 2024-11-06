using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class WebGLFirebaseHandler : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void saveDataToFirestore(string collectionName, string docId, string dataJson);

    public void SaveDataToFirestore(string collectionName, string docId, Dictionary<string, object> data)
    {
        var serializedData = new List<KeyValuePair<string, object>>(data);

        string jsonData = JsonUtility.ToJson(new Serialization(serializedData));
        
        saveDataToFirestore(collectionName, docId, jsonData);
    }
}

//utility class for serializing a List of KeyValuePair to JSON
[System.Serializable]
public class Serialization
{
    public List<KeyValuePair<string, object>> data;

    public Serialization(List<KeyValuePair<string, object>> dict)
    {
        data = dict;
    }
}

