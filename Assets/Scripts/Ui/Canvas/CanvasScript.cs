using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class. If you want to make your own - plz, make it from this one. 
/// </summary>
public class CanvasScript : MonoBehaviour
{
    protected GameObject[] childObjects;

    protected CanvasScript canvasWhatCalledThis;

    [SerializeField] protected bool schouldEnableWithStart;

    protected virtual void Start()
    {
        childObjects = CollectAlChildren();

        if (schouldEnableWithStart)
        {
            CanvasOn();
        }
        else
        {
            CanvasOff();
        }

        canvasWhatCalledThis = null;
    }

    private GameObject[] CollectAlChildren()
    {
        var childs = new GameObject[gameObject.transform.childCount];
        for(int i = 0; i < childs.Length; i++)
        {
            childs[i] = gameObject.transform.GetChild(i).gameObject;
        }
        return childs;
    }

    protected void ChangeActiveOfChildren(bool active)
    {
        foreach (var child in childObjects)
        {
            child.SetActive(active);
        }
    }

    /// <summary>
    /// Enable canvas.
    /// </summary>
    /// <param name="canvasSwitchOn"> Previous canvas. </param>
    /// <returns> This canvas. </returns>
    public virtual CanvasScript CanvasOn(CanvasScript canvasSwitchOn = null)
    {
        canvasWhatCalledThis = canvasSwitchOn;
        ChangeActiveOfChildren(true);
        return this;
    }

    /// <summary>
    /// Turn off canvas.
    /// </summary>
    public virtual void CanvasOff()
    {
        ChangeActiveOfChildren(false);
    }

    /// <summary>
    /// Turn off canvas and open previous
    /// </summary>
    public virtual void CanvasClose()
    {
        if (canvasWhatCalledThis != null)
        {
            canvasWhatCalledThis.CanvasOn();
            CanvasManager.canvasManager.UpdateActiveCanvas(canvasWhatCalledThis);
        }
        CanvasOff();
    }
}