using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private Text _reloadText;
    [SerializeField]
    private Image _crossHair;
    [SerializeField]
    private GameObject _coin;
    [SerializeField]
    private Text _gameText;

    private bool gameTextRoutineRunning = false;

    public void Start()
    {
        FadeGameTextInOut(2, 2, "Whoa, what's that crate doing here? I wonder if there is a way to destroy it...");
    }

    public void CollectedCoin()
    {
        _coin.SetActive(true);
    }

    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count;
    }

    public void ReloadOn()
    {
        _reloadText.enabled = true;
        _crossHair.enabled = false;
    }

    public void ReloadOff()
    {
        _reloadText.enabled = false;
        _crossHair.enabled = true;
    }

    public void RemoveCoin()
    {
        _coin.SetActive(false);
    }

    public void WeaponOn()
    {
        _ammoText.enabled = true;
    }

    public void FadeGameTextInOut(float time, float persist, string message)
    {
        if (gameTextRoutineRunning)
        {
            StopAllCoroutines();
        }            

        _gameText.text = message;
        StartCoroutine(FadeInFadeOut(time, persist, _gameText));
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        gameTextRoutineRunning = false;
    }

    public IEnumerator FadeInFadeOut(float t, float persist, Text i)
    {
        gameTextRoutineRunning = true;
        StartCoroutine(FadeTextToFullAlpha(t, i));
        yield return new WaitForSeconds(t + persist);
        StartCoroutine(FadeTextToZeroAlpha(t, i));
    }
}

