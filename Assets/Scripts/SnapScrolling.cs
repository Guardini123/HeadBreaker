using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    [Range(0, 20)]
    [Header("Controlls")]
    [SerializeField] private int panCount;
    [Range(0, 500)]
    [SerializeField] private int panPosOffset;
    [Range(1.0f, 5.0f)]
    [SerializeField] private float panScaleOffset;
    [Range(0f, 20f)]
    [SerializeField] private float snapSpeed;
    [Range(1.0f, 20.0f)]
    [SerializeField] private float scaleSpeed;
    [Range(0, 1000)]
    [SerializeField] private int inertiaStopSpeed;
    [SerializeField] private ScrollRect scrollRect;
    //[Header("Sprites count need to be same with Pan Count")]
    //[SerializeField] private Sprite[] spritesToInstantOnPans;

    [Header("Prefab and other objects")]
    [SerializeField] private GameObject panPrefab;
    private GameObject[] instPans;
    private Vector2[] instPansPos;
    private Vector3[] instPansScale;
    private RectTransform contentRect;
    private Vector2 contentVector2;
    [SerializeField] private int selectedPanId;
    private bool isScrolling;
    private bool wasInited = false;
    private PanInf[] instPansInf;


    // Start is called before the first frame update
    void Start()
    {
        //InitPans();
    }

    private void InitPans()
    {
        contentRect = GetComponent<RectTransform>();
        instPans = new GameObject[panCount];
        instPansPos = new Vector2[panCount];
        instPansScale = new Vector3[panCount];
        instPansInf = new PanInf[panCount];

        for (int i = 0; i < panCount; i++)
        {
            instPans[i] = Instantiate(panPrefab, transform, false);
            instPansInf[i] = instPans[i].GetComponent<PanInf>();
            //SetSpriteOnPan(i, spritesToInstantOnPans[i]);

            if (i == 0) continue;

            var localX = instPans[i - 1].transform.localPosition.x + panPrefab.GetComponent<RectTransform>().sizeDelta.x + panPosOffset;
            var localY = instPans[i].transform.localPosition.y;
            instPans[i].transform.localPosition = new Vector2(localX, localY);

            instPansPos[i] = -1 * instPans[i].transform.localPosition;
        }

        wasInited = true;
    }


    /// <summary>
    /// Invoke, if start not from first pan.
    /// </summary>
    /// <param name="curElement"> Pan id for start. 0 - if not matter, 1 - if start from first, 2 - from second, etc... </param>
    public void InitSnapFromNotFirst(int curElement = 0)
    {
        if(curElement > 0)
        {
            contentVector2.x = instPansPos[curElement - 1].x;
            contentRect.anchoredPosition = contentVector2;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!wasInited)
        {
            return;
        }

        if(((contentRect.anchoredPosition.x >= instPansPos[0].x) && (!isScrolling)) || 
            ((contentRect.anchoredPosition.x <= instPansPos[instPansPos.Length - 1].x) && (!isScrolling)))
        {
            scrollRect.inertia = false;
        }

        float nearestPos = float.MaxValue;
        for(int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs( contentRect.anchoredPosition.x - instPansPos[i].x );
            if(distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanId = i;
            }
            float scale = Mathf.Clamp(1 / (distance / panPosOffset) * panScaleOffset, 0.7f, 1f);
            instPansScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale, scaleSpeed * Time.fixedDeltaTime);
            instPansScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale, scaleSpeed * Time.fixedDeltaTime);
            instPansScale[i].z = 1.0f;
            instPans[i].transform.localScale = instPansScale[i];
        }

        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if(scrollVelocity < inertiaStopSpeed && !isScrolling)
        {
            scrollRect.inertia = false;
        }

        if (isScrolling || (scrollVelocity > inertiaStopSpeed))
        {
            return;
        }

        contentVector2.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, instPansPos[selectedPanId].x, snapSpeed * Time.deltaTime);
        contentRect.anchoredPosition = contentVector2;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll)
        {
            scrollRect.inertia = true;
        }
    }


    /// <summary>
    /// Init amount of pans.
    /// </summary>
    /// <param name="count"> Pans count. </param>
    public void InitPansWithCount(int count)
    {
        panCount = count;
        InitPans();
    }


    /// <summary>
    /// Set some info on pan by its numer. Might sprite been setup!
    /// </summary>
    /// <param name="num"> Pan's numer. </param>
    /// <param name="sprite"> Sprite, need to be set on this pan. </param>
    /// <param name="text"> Text, need to be set on this pan. </param>
    /// <param name="highScore"> Highscore, need to be set on this pan. </param>
    public void SetInfOnPan(int num, Sprite sprite, string text = " ", string highScore = " ")
    {
        instPansInf[num].SetSpriteOnImage(sprite);
        instPansInf[num].SetTextOnPan(text);
        instPansInf[num].SetHighScoreOnPan(highScore);
    }


    /// <summary>
    /// Returns id of selected pan;
    /// </summary>
    /// <returns> Selected pan id. </returns>
    public int GetCurrentId()
    {
        return selectedPanId;
    }
}
