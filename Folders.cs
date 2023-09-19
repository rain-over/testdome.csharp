using System.Xml.Linq;
namespace testdome;

public static class Folders
{
    public static void Print()
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        foreach (string name in Folders.FolderNames(xml, 'u'))
            Console.WriteLine(name);
    }
    static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        XDocument xdoc = XDocument.Parse(xml);
        // Console.WriteLine("out: " + xdoc.Descendants().ToString());
        List<string> list = new List<string>();
        return xdoc.Descendants().Where(x => x.Attribute("name").Value.StartsWith(startingLetter)).Select(x => x.Attribute("name").Value.ToString()).ToList();
    }
}