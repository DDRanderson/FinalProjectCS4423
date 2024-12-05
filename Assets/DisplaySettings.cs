using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour
{

    [SerializeField] Toggle vsyncToggle;

    void Start()
    {
        if (vsyncToggle != null)
        {
            // Load saved VSync preference or default to enabled
            bool isVSyncEnabled = PlayerPrefs.GetInt("VSync", 1) == 1;
            vsyncToggle.isOn = isVSyncEnabled;
            QualitySettings.vSyncCount = isVSyncEnabled ? 1 : 0;

            vsyncToggle.onValueChanged.AddListener(OnVSyncToggleChanged);
        }
    }

    private void OnVSyncToggleChanged(bool isEnabled)
    {
        QualitySettings.vSyncCount = isEnabled ? 1 : 0;
        PlayerPrefs.SetInt("VSync", isEnabled ? 1 : 0);
    }

}
