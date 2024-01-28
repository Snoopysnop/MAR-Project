using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<string, string> Inventory = new Dictionary<string, string>();


   public void addItem(string key, string value)
    {
        Inventory.Add(key, value);
    }

    public string GetItem(string key)
    {
        return Inventory.GetValueOrDefault(key);
    }

    public void RemoveItem(string key)
    {
        Inventory.Remove(key);
    }
    public void SetItem(string key, string value)
    {
        Inventory[key] = value;
    }
}
