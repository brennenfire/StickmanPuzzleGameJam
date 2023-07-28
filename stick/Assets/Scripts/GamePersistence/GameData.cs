using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public List<SlotData> SlotDatas;

    public GameData()
    {
        SlotDatas = new List<SlotData>();
    }
}
