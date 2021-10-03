using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPans : MonoBehaviour
{
    [SerializeField] private SelectLevelCanvasScript selectLevelCanvas;
    [SerializeField] private SnapScrolling snapScrolling;

    private List<Level> levels;

    // Start is called before the first frame update
    void Start()
    {
        levels = selectLevelCanvas.GetListOfLevels();

        snapScrolling.InitPansWithCount(levels.Count);

        snapScrolling.InitSnapFromNotFirst(selectLevelCanvas.GetCurrentLevel());

        for (int i = 0; i < levels.Count; i++)
        {
            snapScrolling.SetInfOnPan(i, levels[i].GetLevelPic());
        }
    }
}
