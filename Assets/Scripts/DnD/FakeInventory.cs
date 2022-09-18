using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inisiasi DropSlot Object
public class FakeInventory : MonoBehaviour
{
	[SerializeField] private Transform inventoryItemsContainer;

	private void Start()
	{
		InitializeItems();
	}

	private void InitializeItems()
	{
		var slots = inventoryItemsContainer.GetComponentsInChildren<DragSlot>();
		foreach (var slot in slots)
		{
			var item = slot.GetComponentInChildren<DraggableComponent>();
			if (item != null)
			{
				slot.Initialize(item);
			}
		}
	}
}
