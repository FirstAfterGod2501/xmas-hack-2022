using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            engine.ExecuteFile("../../../../../Python/main.py");
            Console.WriteLine("Hello, World!");
        }
    }
}