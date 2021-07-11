using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitialize : MonoBehaviour
{
    #region
    private string gameId = "4164809";
    #endregion

    void Start()
    {
        Advertisement.Initialize(gameId, false);
    }
}
