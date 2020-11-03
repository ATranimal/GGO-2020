using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiClicker : MonoBehaviour
{
    private float _timeStampOpen;
    private float _timeStampClose;
    public float delayBetweenClicks = 1f;

    SpriteRenderer spriteRenderer;
    Color activeColor;

    // temp mochi counter
    int mochiCounter;

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
        }
        else if (_timeStampOpen <= Time.time && _timeStampClose <= Time.time)
        {
            _timeStampOpen += delayBetweenClicks;
            _timeStampClose += delayBetweenClicks;
        }
    }
}
