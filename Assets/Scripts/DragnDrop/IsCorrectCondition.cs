using System;

public class IsCorrectCondition : DropCondition
{
	public override bool Check(DraggableComponent draggable)
	{
        if (draggable.GetComponent<Correct>() != null)
        {
            Console.WriteLine("Benar");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("SALAH");
            Console.ReadKey();
        }
        return draggable.GetComponent<Correct>() != null;
    }
}
