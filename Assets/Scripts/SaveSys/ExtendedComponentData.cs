using System;
using UnityEngine;

namespace NGS.ExtendableSaveSystem
{
    [Serializable]
    public class ExtendedComponentData : ComponentData
    {
        public void GetDataScore(string uniqueName)
        {
            if (GetInt(uniqueName) == 0)
            {
                //Debug.Log("Null Score");
                GameManager.instance.BestScore = 0;
                return;
            }
            int data = GetInt(uniqueName);
            GameManager.instance.BestScore = data;
            UIManager.instance.UpdateBestScore();
        }
    }
}
