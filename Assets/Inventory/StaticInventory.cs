﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticInventory : MonoBehaviour {

    public void DeleteItemWithName(string name)
    {
        int index = 0;
        if (Inventory.FindItemWithName(name, ref index))
        {
            Transform slot = Inventory.InventoryPanel.GetChild(index).GetChild(0);
            Inventory._inventory[index] = null;
            GameObject.Destroy(slot.gameObject);
        }
        else
            Debug.Log("Предмета с таким именем нет");
    }
}

public static class Inventory
{
    public static Item[] _inventory = new Item[14];
    public static int currentSlot = 0;
    public static Transform InventoryPanel;
    public static Transform NoficationsContent;
    public static Transform NotificationItemPenel_Prefab;

    public static bool FindItemWithName(string name)
    {
        for (int i = 0; i <= 14; i++)
        {
            try
            {
                // Если i-ый элемент не существует то...
                if (Inventory._inventory[i].name == name)
                {
                    return true;
                }
            }
            catch { }
        }
        return false;
    }

    public static bool FindItemWithName(string name, ref int index)
    {
        for (int i = 0; i <= 14; i++)
        {
            try
            {
                // Если i-ый элемент не существует то...
                if (Inventory._inventory[i].name == name)
                {
                    index = i;
                    return true;
                }
            }
            catch { }
        }
        return false;
    }

    public static bool FindStackItemWithCount_AtLeast(string name, int num)
    {
        int i = 0; //Индекс стакающегося предмета с именем name
        if (FindItemWithName(name, ref i)) //Проверяем, есть ли у нас вообще такой предмет в инвентаре
        {
            if (_inventory[i].count >= num) //Проверяем больше ли его кол-во
                return true;
            else
                return false;
        }
        else
            return false;
    }

    public static void DeleteSomeOfStackableItem(string name, int num)
    {
        int i = 0;
        if(FindItemWithName(name, ref i))
        {
            if (_inventory[i].count >= num)
            {
                _inventory[i].count -= num;
                InventoryPanel.GetChild(i).GetComponent<Text>().text = _inventory[i].count.ToString();
            }
        }
    }

    public static void DeleteItemWithName(string name)
    {
        int index = 0;
        if (FindItemWithName(name, ref index))
        {
            Transform slot = Inventory.InventoryPanel.GetChild(index).GetChild(0);
            Inventory._inventory[index] = null;
            GameObject.Destroy(slot.gameObject);
        }
        else
            Debug.Log("Предмета с таким именем нет");
    }


}