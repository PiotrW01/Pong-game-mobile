using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SettingsButtons : MonoBehaviour, ISelectHandler
{
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(eventData.selectedObject.name);
        
    }
}
