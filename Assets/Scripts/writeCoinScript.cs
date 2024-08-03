using System;
using TMPro;
using UnityEngine;

public class writeCoinScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        writecointx();
    }

    public void writecointx()
    {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();
    }
}