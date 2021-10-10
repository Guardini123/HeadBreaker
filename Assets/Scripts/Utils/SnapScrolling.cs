using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class SnapScrolling : MonoBehaviour
{
    [Range(0, 20)]
    [Header("Controlls")]
    [SerializeField] private int _panCount;
    [Range(0, 500)]
    [SerializeField] private int _panPosOffset;
    [Range(1.0f, 5.0f)]
    [SerializeField] private float _panScaleOffset;
    [Range(0f, 20f)]
    [SerializeField] private float _snapSpeed;
    [Range(1.0f, 20.0f)]
    [SerializeField] private float _scaleSpeed;
    [Range(0, 1000)]
    [SerializeField] private int _inertiaStopSpeed;
    [SerializeField] private ScrollRect _scrollRect;

    [Header("Prefab and other objects")]
    [SerializeField] private GameObject _panPrefab;
    private GameObject[] _instPans;
    private Vector2[] _instPansPos;
    private Vector3[] _instPansScale;
    private RectTransform _contentRect;
    private Vector2 _contentVector2;
    [SerializeField] private int _selectedPanId;
    private bool _isScrolling;
    private bool _wasInited = false;
    private PanInfUi[] _instPansInf;


    public UnityEvent OnPansCreated;


    /// <summary>
    /// Returns id of selected pan
    /// </summary>
    public int SelectedPanId => _selectedPanId;


    /// <summary>
    /// Return false if pans not inited yet
    /// </summary>
    public bool WasInited => _wasInited;



	private void Start()
	{
        /*InitPans();*/
	}


	private void InitPans()
    {
        _contentRect = GetComponent<RectTransform>();
        _instPans = new GameObject[_panCount];
        _instPansPos = new Vector2[_panCount];
        _instPansScale = new Vector3[_panCount];
        _instPansInf = new PanInfUi[_panCount];

        for (int i = 0; i < _panCount; i++)
        {
            _instPans[i] = Instantiate(_panPrefab, transform, false);
            _instPansInf[i] = _instPans[i].GetComponent<PanInfUi>();
            //SetSpriteOnPan(i, spritesToInstantOnPans[i]);

            if (i == 0) continue;

            var localX = _instPans[i - 1].transform.localPosition.x + _panPrefab.GetComponent<RectTransform>().sizeDelta.x + _panPosOffset;
            var localY = _instPans[i].transform.localPosition.y;
            _instPans[i].transform.localPosition = new Vector2(localX, localY);

            _instPansPos[i] = -1 * _instPans[i].transform.localPosition;
        }

        _wasInited = true;
        OnPansCreated?.Invoke();
        OnPansCreated.RemoveAllListeners();
    }


    void FixedUpdate()
    {
        if (!_wasInited)
        {
            return;
        }

        if(((_contentRect.anchoredPosition.x >= _instPansPos[0].x) && (!_isScrolling)) || 
            ((_contentRect.anchoredPosition.x <= _instPansPos[_instPansPos.Length - 1].x) && (!_isScrolling)))
        {
            _scrollRect.inertia = false;
        }

        float nearestPos = float.MaxValue;
        for(int i = 0; i < _panCount; i++)
        {
            float distance = Mathf.Abs( _contentRect.anchoredPosition.x - _instPansPos[i].x );
            if(distance < nearestPos)
            {
                nearestPos = distance;
                _selectedPanId = i;
            }
            float scale = Mathf.Clamp(1 / (distance / _panPosOffset) * _panScaleOffset, 0.7f, 1f);
            _instPansScale[i].x = Mathf.SmoothStep(_instPans[i].transform.localScale.x, scale, _scaleSpeed * Time.fixedDeltaTime);
            _instPansScale[i].y = Mathf.SmoothStep(_instPans[i].transform.localScale.y, scale, _scaleSpeed * Time.fixedDeltaTime);
            _instPansScale[i].z = 1.0f;
            _instPans[i].transform.localScale = _instPansScale[i];
        }

        float scrollVelocity = Mathf.Abs(_scrollRect.velocity.x);
        if(scrollVelocity < _inertiaStopSpeed && !_isScrolling)
        {
            _scrollRect.inertia = false;
        }

        if (_isScrolling || (scrollVelocity > _inertiaStopSpeed))
        {
            return;
        }

        _contentVector2.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _instPansPos[_selectedPanId].x, _snapSpeed * Time.deltaTime);
        _contentRect.anchoredPosition = _contentVector2;
    }

    public void Scrolling(bool scroll)
    {
        _isScrolling = scroll;
        if (scroll)
        {
            _scrollRect.inertia = true;
        }
    }


    /// <summary>
    /// Init amount of pans.
    /// </summary>
    /// <param name="count"> Pans count. </param>
    public void InitPansWithCount(int count)
    {
        _panCount = count;
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
        _instPansInf[num].SetSpriteOnImage(sprite);
        _instPansInf[num].SetTextOnPan(text);
        _instPansInf[num].SetHighScoreOnPan(highScore);
    }


    /// <summary>
    /// Invoke, if start not from first pan.
    /// </summary>
    /// <param name="curElement"> Pan id for start </param>
    public void InitSnapFromNotFirst(int curElement)
    {
        if (curElement >= 0)
        {
            _contentVector2.x = _instPansPos[curElement].x;
            _contentRect.anchoredPosition = _contentVector2;
        }
    }
}
