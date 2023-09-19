namespace testdome;

public class QuadraticEquation
{

    /*
     * Implement the function FindRoots to find the roots of the quadratic equation: ax² + bx + c = 0.
     * The function should return a tuple containing roots in any order. 
     * If the equation has only one solution, the function should return that solution as both elements of tuple. 
     * The equation will always have at least one solution.
     * 
     * The roots of the quadratic equation can be found with the following forumal: see assets/Quadratic.png
     * 
     * For example, FindRoots(2, 10, 8) should return (-1, -4) or (-4,-1)
     * as the roots of the equation 2x² + 10x + 8 = 0 are -1 and -4.
     */
    public static Tuple<double, double> FindRoots(double a, double b, double c)
    {
        double item1 = (-b + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);
        double item2 = (-b - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))) / (2 * a);

        return new Tuple<double, double>(item1, item2);
    }

    public static void Print()
    {
        Tuple<double, double> roots = QuadraticEquation.FindRoots(2, 10, 8);
        Console.WriteLine("Roots: " + roots.Item1 + ", " + roots.Item2);
    }
}
