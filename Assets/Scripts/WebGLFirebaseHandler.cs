using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class WebGLFirebaseHandler : MonoBehaviour
{
    // Declare the JavaScript function for WebGL with DllImport
    [DllImport("__Internal")]
    public static extern void saveDataToFirestore(string collectionName, string docId, string dataJson);

    public void SaveDataToFirestore(string collectionName, string docId, Dictionary<string, object> data)
    {
        // Convert the data Dictionary to a List of KeyValuePair<string, object>
        var serializedData = new List<KeyValuePair<string, object>>(data);

        // Convert the List to JSON using JsonUtility
        string jsonData = JsonUtility.ToJson(new Serialization(serializedData));
        
        // Call the JavaScript function
        saveDataToFirestore(collectionName, docId, jsonData);
    }
}

// Utility class for serializing a List of KeyValuePair to JSON
[System.Serializable]
public class Serialization
{
    public List<KeyValuePair<string, object>> data;

    public Serialization(List<KeyValuePair<string, object>> dict)
    {
        data = dict;
    }
}

