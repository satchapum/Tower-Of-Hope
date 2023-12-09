using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndCredit : MonoBehaviour
{
    [SerializeField] TMP_Text textInstance;

    [SerializeField] float speedPxPerSec;

    public float creditDurationSec;
    public Rect startRect;
    public Rect endRect;
    bool isEnded;

    void Awake()
    {
        float textHeightPx = LayoutUtility.GetPreferredHeight(this.textInstance.rectTransform);
        Debug.Log(textHeightPx);
        this.creditDurationSec = ((textHeightPx + Screen.height) / this.speedPxPerSec) * Time.deltaTime;
        Debug.Log(creditDurationSec);
    }

    void ResetCreditPosition()
    {
        float textHeightPx = LayoutUtility.GetPreferredHeight(this.textInstance.rectTransform);
        Debug.Log(textHeightPx);
        this.textInstance.rectTransform.offsetMin = new Vector2(0, -textHeightPx);
        this.textInstance.rectTransform.offsetMax = new Vector2(0, -Screen.height);
    }

    void Start()
    {
        RestartCredit();
    }

    void FixedUpdate()
    {
        if (!this.isEnded)
        {
            this.textInstance.rectTransform.Translate(new Vector2(0, this.speedPxPerSec));
        }
    }

    IEnumerator MoveCredit()
    {
        this.isEnded = false;
        yield return new WaitForSeconds(this.creditDurationSec);
        this.isEnded = true;
    }

    public void RestartCredit()
    {
        this.isEnded = false;
        ResetCreditPosition();
        StartCoroutine(MoveCredit());
    }
}