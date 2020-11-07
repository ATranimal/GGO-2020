using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiClicker : MonoBehaviour
{
    private float _timeStampOpen;
    private float _timeStampClose;
    public float delayBetweenClicks = 1f;

    bool isClickable;

    SpriteRenderer spriteRenderer;
    Color activeColor;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;

        _timeStampOpen = Time.time;
        _timeStampClose = Time.time + 0.2f;

    }

    private void Update()
    {
        if (_timeStampOpen >= Time.time)
        {
            spriteRenderer.color = Color.white;
        } else if (_timeStampOpen <= Time.time && _timeStampClose >= Time.time)
        {
            spriteRenderer.color = Color.red;
            isClickable = true;
        }
        else if (_timeStampOpen <= Time.time && _timeStampClose <= Time.time)
        {
            _timeStampOpen += delayBetweenClicks;
            _timeStampClose += delayBetweenClicks;
            isClickable = false;
        }
    }

    private void OnMouseDown()
    {
        if (isClickable)
            AddMochi(1);
        else if (!isClickable) {
            if (MochiDisplay.mochiCounter > 0) {
                AddMochi(-1);
            }
        }
    }

    void AddMochi(int mochiChange)
    {
        MochiDisplay.mochiCounter += mochiChange;
        Debug.Log(MochiDisplay.mochiCounter);
    }
}
