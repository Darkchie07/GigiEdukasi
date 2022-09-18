using System;

public class IsCorrectCondition : DropCondition
{
	public override bool Check(DraggableComponent draggable)
	{
        return draggable.GetComponent<Correct>() != null;
    }
}
