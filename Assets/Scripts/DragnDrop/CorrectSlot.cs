using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectSlot : DragSlot
{
	protected override void Awake()
	{
		base.Awake();
		DropArea.DropConditions.Add(new IsCorrectCondition());
	}
}
