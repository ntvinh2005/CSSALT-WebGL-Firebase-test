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

        SampleData sampleData = new SampleData
        {
            message = "Testing? Do we succeed?"
        };

        string jsonData = JsonUtility.ToJson(sampleData);

        WebGLFirebaseHandler.saveDataToFirestore("userData", docId, jsonData);
    }
}

//class to hold your data (Serializable)
[System.Serializable]
public class SampleData
{
    public string message;
}


