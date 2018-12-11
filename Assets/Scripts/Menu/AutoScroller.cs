using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoScroller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Range(10, 1000)]
    public float ScrollSpeed = 10;

    [Range(0, 10)]
    public int CreditsStartWaitTime = 3;
    [Range(0, 10)]
    public int CreditsEndWaitTime = 3;

    public MainMenuController controller;

    Image bg;
    Color bgColor;

    Scrollbar scrb;
    ColorBlock handleColors;
    ColorBlock clearBlock;

    public bool isScrolling = false;

    RectTransform content;

    ScrollRect scrRect;

    Vector2 startPos;

    // Use this for initialization
    void Start()
    {
        scrRect = transform.parent.GetComponent<ScrollRect>();

        RectTransform viewPort = transform.parent.Find("Viewport").GetComponent<RectTransform>();
        content = viewPort.Find("Content").GetComponent<RectTransform>();

        bg = GetComponent<Image>();
        bgColor = bg.color;
        scrb = GetComponent<Scrollbar>();
        handleColors = scrb.colors;

        bg.color = Color.clear;

        clearBlock = new ColorBlock
        {
            normalColor = Color.clear,
            disabledColor = Color.clear,
            highlightedColor = Color.clear,
            pressedColor = Color.clear
        };

        scrb.colors = clearBlock;

        startPos = content.localPosition;
    }

    void Update()
    {
        if (isScrolling)
        {
            if (scrRect.verticalNormalizedPosition <= 0)
            {
                isScrolling = false;
                //Debug.Log("Credits Stop");
                StartCoroutine(WaitAndExit());

            } else {
                content.localPosition = new Vector2(content.localPosition.x, content.localPosition.y + ScrollSpeed * Time.deltaTime);
            }
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("I was entered");
        scrb.colors = handleColors;
        bg.color = bgColor;
        isScrolling = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("I was exited");
        scrb.colors = clearBlock;
        bg.color = Color.clear;
        isScrolling = true;
    }

    public void StartAutoScroll()
    {
        //Debug.Log("Start coroutine now");
        StartCoroutine(WaitForStart());
    }

    public IEnumerator WaitForStart()
    {
        //Debug.Log("Waiting for "+ CreditsStartWaitTime + " seconds");
        yield return new WaitForSeconds(CreditsStartWaitTime);
        isScrolling = true;
    }

    public IEnumerator WaitAndExit()
    {
        yield return new WaitForSeconds(CreditsEndWaitTime);
        controller.HideCredits();
        content.localPosition = startPos;
    }
}
