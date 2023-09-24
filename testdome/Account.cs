namespace testdome;

/*
 * Each account on a website has a set of access flags that represent a user access.
 * 
 * Update and extend the enum so that is contains three new access flags:
 * 1. A Writer access flag that is made up of the Submit and Modify flags.
 * 2. An Editor access flag that is made up of the Delete, Publish and Comment flags.
 * 3. An Owner access that is made up of the Write and Editor flags.
 * 
 * For example, the code below should print "False" as the Writer flag does not contain the Delete flag.
 * 
 * | Console.WriteLine(Access.Write.HasFlag(Access.Delete))
 * 
 */

/*
 * https://www.youtube.com/watch?v=Pp7T-O3dIrs
 */
internal class Account
{
    [Flags]
    public enum Access
    {
        None = 0,
        Delete = 1,
        Publish = 2,
        Submit = 4,
        Comment = 8,
        Modify = 16,
        Writer = Access.Submit | Access.Modify,
        Editor = Access.Delete | Access.Publish | Access.Comment,
        Owner = Access.Writer | Access.Editor,
    }

    public static void CheckAccount()
    {
        Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }
}
