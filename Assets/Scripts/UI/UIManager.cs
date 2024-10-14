using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject BuffSelectionScreen;
    [SerializeField] TextMeshProUGUI characterUltPoint;

    private void Awake()
    {

    }

    void Start()
    {

    }
    void Update()
    {
        characterUltPoint.text = Mathf.Round(Character.ultPoint).ToString();
    }
}

