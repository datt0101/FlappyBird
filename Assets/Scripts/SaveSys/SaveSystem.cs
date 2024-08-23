using UnityEngine;
using System.IO;
using NGS.ExtendableSaveSystem;

public class SaveSystem : MonoBehaviour, ISavableComponent
{
    [SerializeField] private int m_uniqueID;

    [SerializeField] private int m_executionOrder;
    public int uniqueID { get => m_uniqueID; }
    public int executionOrder { get => m_executionOrder; }

    private void Reset()
    {
        m_uniqueID = GetHashCode();
    }


    public ComponentData Serialize()
    {
        ExtendedComponentData data = new ExtendedComponentData();
        data.SetInt("data", GameManager.instance.BestScore);
        return data;
    }


    public void Deserialize(ComponentData data)
    {
        ExtendedComponentData unpacked = (ExtendedComponentData) data;
        unpacked.GetDataScore("data");

    }

}