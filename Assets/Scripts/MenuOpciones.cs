using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
   
      
    public void SetVolume (float volume)
    { }

    public void SetQuality (int qualityIndex)
    { QualitySettings.SetQualityLevel(qualityIndex); }

    public void SetFullscreen(bool isFullscreen)
    { Screen.fullScreen = isFullscreen; }



}
