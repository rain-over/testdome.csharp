namespace testdome;

/*
 * 
 * A TrainComposition is built by attaching and detaching wagons from the left and the right sides, (efficiently with respect to time used)
 * For example, if we start by attaching wagon 7 from the left followed by attaching wagon 13, again from the left,
 * we get a composition of two wagons (13 and 7 from left to right). Now the first wagon that can be detached from the right is 7
 * and the first that can be detached from the left is 13
 * 
 * Implement a TrainComposition that models this problem.
 */

/*
 * Several Wagons
 * Performance test with a large number of wagons
 * 
 */

internal class TrainComposition
{
    private LinkedList<int> _trains = new LinkedList<int>();
    public void AttachWagonFromLeft(int wagonId)
    {
        _trains.AddFirst(wagonId);
    }

    public void AttachWagonFromRight(int wagonId)
    {
        _trains.AddLast(wagonId);
    }

    public int DetachWagonFromLeft()
    {
        int left = _trains.First.Value;
        _trains.RemoveFirst();
        return left;
    }

    public int DetachWagonFromRight()
    {
        int right = _trains.Last.Value;

        _trains.RemoveLast();

        return right;
    }

    public static void RunTrain()
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
        Console.WriteLine(train.DetachWagonFromRight()); // 7 
        Console.WriteLine(train.DetachWagonFromLeft()); // 13
    }
}
