using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    const int GENERAL_SIZE = 9;

    public ItemSlot[] GeneralSlots = new ItemSlot[GENERAL_SIZE];

    [SerializeField] Item debugItem;
    public static Inventory Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        for (int i = 0; i < 9; i++)
        {
            GeneralSlots[i] = new ItemSlot();
        }
    }

    void CheckItems()
    {
        for (int i = GENERAL_SIZE - 1; i > 0; i--)
        {
            //GeneralSlots[i].Item.
        }
    }

    public void AddItem(Item item)
    {
        var firstAvailableSlot = GeneralSlots.FirstOrDefault(t => t.isEmpty);
        firstAvailableSlot.SetItem(item);
    }

    [ContextMenu(nameof(AddDebugItem))]
    void AddDebugItem()
    {
        AddItem(debugItem);
    }

    [ContextMenu(nameof(MoveItemsRight))]
    void MoveItemsRight()
    {
        var lastItemSlot = GeneralSlots.Last().Item;
        for (int i = GENERAL_SIZE - 1; i > 0; i--)
        {
            GeneralSlots[i].SetItem(GeneralSlots[i - 1].Item);
        }

        GeneralSlots.First().SetItem(lastItemSlot);
    }

    public void Bind(List<SlotData> slotDatas)
    {
        for (int i = 0; i < GeneralSlots.Length; i++)
        {
            var slot = GeneralSlots[i];
            var slotData = slotDatas.FirstOrDefault(t => t.SlotName == "General" + i);
            if (slotData == null)
            {
                slotData = new SlotData() { SlotName = "General" + i };
                slotDatas.Add(slotData);
            }

            slot.Bind(slotData);
        }
    }
}
