using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
internal class Program
    {
        static void Main(string[] args)
        {
        Directory.CreateDirectory("demo");

        Directory.CreateDirectory("demo/demo1");
        Directory.CreateDirectory("demo/demo2");

        File.WriteAllText("demo/demo1/file1.txt", "This is the content of file1.txt");
        FileInfo file2 = new FileInfo("demo/demo2/file2.txt");
        using (StreamWriter sw = file2.CreateText())
        {
            sw.WriteLine("This is the content of file2.txt");
        }
        File.AppendAllText("demo/demo1/file1.txt", "\nThis is the appended content of file1.txt");
        //file2.AppendText("demo/demo2/file1.txt", "\nThis is the appended content of file2.txt");


        //File.Copy("demo/demo1/file1.txt", "demo/demo2/file2_copy.txt");


        Console.WriteLine("Files:");
        foreach (string file in Directory.GetFiles("demo/demo1"))
        {
            Console.WriteLine(file + " created at " + File.GetCreationTime(file));
        }
        foreach (string file in Directory.GetFiles("demo/demo2"))
        {
            Console.WriteLine(file + " created at " + File.GetCreationTime(file));
        }
        Console.WriteLine("\nDirectories:");
        foreach (string dir in Directory.GetDirectories("demo"))
        {
            Console.WriteLine(dir + " created at " + Directory.GetCreationTime(dir));
        }


        foreach (string file in Directory.GetFiles("demo/demo1"))
        {
            File.Delete(file);
        }

        foreach (string dir in Directory.GetDirectories("demo"))
        {
           Directory.Delete(dir);
        }

    }
}

