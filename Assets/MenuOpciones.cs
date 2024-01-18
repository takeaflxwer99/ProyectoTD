using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
   public void SetVolume (float volume)
    { }

    public void SetQuality (int qualityIndex)
    { QualitySettings.SetQualityLevel(qualityIndex); }
}
