using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class DataSendingButton : MonoBehaviour
{
    public Button sendButton;
    
    private void Start() {
        sendButton.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        string docId = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");

        // Create sample data
        SampleData sampleData = new SampleData
        {
            message = "Testing? Do we succeed?"
        };

        // Convert to JSON using JsonUtility
        string jsonData = JsonUtility.ToJson(sampleData);
        
        // Send data to WebGL
        WebGLFirebaseHandler.saveDataToFirestore("userData", docId, jsonData);
    }
}

// Class to hold your data (Serializable)
[System.Serializable]
public class SampleData
{
    public string message;
}


