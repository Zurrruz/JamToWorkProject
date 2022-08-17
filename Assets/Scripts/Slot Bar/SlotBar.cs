using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotBar : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _slots;
    [SerializeField]
    private List<bool> _freeSlots;
    [SerializeField]
    private Transform _hand;
    public List<GameObject> _itemsInTheInventory = new List<GameObject>();

    public void AddItemInSlot(GameObject item, Sprite icon)
    {
        _itemsInTheInventory.Add(item);

        for (int i = 0; i < _slots.Count; i++)
        {
            if(!_freeSlots[i])
            {
                _slots[i].GetComponent<Image>().sprite = icon;
                _freeSlots[i] = true;
                break;
            }
        }
    }   

    public void DeleteItemInSlots(GameObject item)
    {
        _itemsInTheInventory.Remove(item);

        for (int i = 0; i < _freeSlots.Count; i++)
        {
            if(_freeSlots[i] == false)
            {
                _freeSlots[i - 1] = false;
                break;
            }
        }

        for (int i = 0; i < _slots.Count; i++)
        {
            _slots[i].GetComponent<Image>().sprite = default;
        }

        for (int i = 0; i < _itemsInTheInventory.Count; i++)
        {
            _slots[i].GetComponent<Image>().sprite = _itemsInTheInventory[i].GetComponent<ItemSpecification>().IconItem();
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            ItemDisplay(0);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            ItemDisplay(1);
        }
    }

    private void ItemDisplay(int n)
    {
        if (_itemsInTheInventory.Count - 1 >= n)
        {         
            for (int i = 0; i < _itemsInTheInventory.Count; i++)
            {
                _itemsInTheInventory[i].SetActive(false);
            }

            _itemsInTheInventory[n].SetActive(true);
            PickUpObject._currentOgject = _itemsInTheInventory[n];
            PickUpObject._theHandIsBusy = true;
        }
    }
}
