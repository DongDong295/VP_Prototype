using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class TraitSelectionUI : MonoBehaviour
{
    public TextMeshProUGUI selectionText;
    public CharacterTraitManager characterTraitManager;
    public Button[] traitButtons;
    public float moveDistance = 100f;
    public float moveDuration = 1f;
    public float delayBeforeButtons = 0.5f;

    private void Start()
    {
        ActiveTraitListener();
        GameManager.Instance.OnGameStart += StartTraitSelection;
        GameManager.Instance.OnInWave += DisableSelection;
    }

    public void StartTraitSelection()
    {
        selectionText.transform.localScale = Vector3.zero;
        selectionText.transform.DOScale(Vector3.one, 0.5f);
        selectionText.gameObject.SetActive(true);
        selectionText.transform.DOMoveY(selectionText.transform.position.y + moveDistance, moveDuration)
            .OnComplete(ShowButtons);
    }

    public void DisableSelection()
    {
        selectionText.transform.localScale = Vector3.zero;
        selectionText.gameObject.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            traitButtons[i].gameObject.SetActive(false);
            traitButtons[i].transform.localScale = Vector3.zero;
        }
    }

    private void ShowButtons()
    {
        StartCoroutine(ActivateButtons());
    }

    private IEnumerator ActivateButtons()
    {
        yield return new WaitForSeconds(delayBeforeButtons);
        for(int i = 0; i < 3; i++)
        {
            traitButtons[i].gameObject.SetActive(true);
            traitButtons[i].transform.localScale = Vector3.zero;
            traitButtons[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = characterTraitManager.characterTraits[i].traitName;
            traitButtons[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = characterTraitManager.characterTraits[i].traitDescription;
            yield return new WaitForSeconds(0.25f);
            traitButtons[i].transform.DOScale(Vector3.one, 0.5f);
        }
    }

    private void ActiveTraitListener()
    {
        traitButtons[0].onClick.AddListener(() => characterTraitManager.characterTraits[0].ActiveTrait());
        traitButtons[1].onClick.AddListener(() => characterTraitManager.characterTraits[1].ActiveTrait());
        traitButtons[2].onClick.AddListener(() => characterTraitManager.characterTraits[2].ActiveTrait());
    }
}
