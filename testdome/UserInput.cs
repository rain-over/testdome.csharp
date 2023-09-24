namespace testdome;
/*
 * User interface contains two types of user input controls: 
 * TextInput, which accepts all characters and
 * NumericInput, which accepts only digits.
 * 
 * Implement the class TextInput that contains:
 * * Public method void Add(char c) - add the given character to the current value.
 * * Public method string GetValue() - returns the current value.
 * 
 * Implement the class Numericinput that:
 * * Inherist TextInput
 * * Overrides the Add method so that each non-numeric character is ignored.
 * 
 * For Example, the following code should output "10"
 * 
 * | TextInput input = new NumericInput();
 * | input.Add('1');
 * | input.Add('a');
 * | input.Add('0');
 * | Console.WriteLine(input.GetValue());
 * 
 */

public class TextInput
{
    protected string val;
    public virtual void Add(char c)
    {
        val += c;
    }
    public string GetValue()
    {
        return val;
    }
}

public class NumericInput : TextInput
{
    public override void Add(char c)
    {
        bool isNumeric = int.TryParse(c.ToString(), out int n);
        if (isNumeric) val += c;
        return;
    }
}
internal class UserInput
{
    public static void Input()
    {
        TextInput input = new NumericInput();
        input.Add('1');
        input.Add('a');
        input.Add('0');
        Console.WriteLine(input.GetValue());
    }
}
