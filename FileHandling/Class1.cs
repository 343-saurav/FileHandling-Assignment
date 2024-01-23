using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;



namespace FileHandling
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            int ch = 0;
            char c;
            do
            {
                Console.WriteLine(".....MENU.....");
                Console.WriteLine("1.Create a New File");
                Console.WriteLine("2.Add Contents to the File");
                Console.WriteLine("3.Append Contents to the File");
                Console.WriteLine("4.Display Contents one by one");
                Console.WriteLine("5.Display All Contents together");
                Console.WriteLine("6.Delete");
                Console.WriteLine("Enter your choice");
                ch = int.Parse(Console.ReadLine());
                string path = "C:\\Files\\abc.txt";
                switch (ch)
                {
                    case 1:
                        {
                            FileInfo fileinfo = new FileInfo(path);
                            if (!fileinfo.Exists)
                            {
                                FileStream fs = new FileStream(path, FileMode.Create);

                                Console.WriteLine("File Created");
                                fs.Close();
                            }
                            else
                            {
                                Console.WriteLine("File exists already");
                            }

                            break;
                        }
                    case 2:
                        {
                            FileInfo file = new FileInfo(path);
                            if (file.Exists)
                            {
                                FileStream fs1 = file.Open(FileMode.Open, FileAccess.Write);
                                StreamWriter sw = new StreamWriter(fs1);
                                sw.WriteLine(" Writing content to file");
                                sw.Close();

                            }
                            else
                            {
                                Console.WriteLine("File does not exists");
                            }
                            break;

                        }
                    case 3:
                        {
                            FileInfo file = new FileInfo(path);
                            if (file.Exists)
                            {
                                using (StreamWriter sw = File.AppendText(path))
                                {
                                    sw.WriteLine("Append contents to file");
                                    sw.Close();
                                }

                            }
                            else
                            {
                                Console.WriteLine("File not exists");
                            }
                            break;
                        }
                    case 4:
                        {
                            FileInfo file = new FileInfo(path);
                            if (file.Exists)
                            {
                                using (StreamReader sr = new StreamReader(path))
                                {
                                    string line;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        Console.WriteLine(line);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("File not exists");
                            }

                            break;
                        }

                    case 5:
                        {
                            FileInfo file = new FileInfo(path);
                            if (file.Exists)
                            {
                                string textread = File.ReadAllText(path);
                                Console.WriteLine(textread);

                            }
                            else
                            {
                                Console.WriteLine("File not Exists");
                            }

                            break;
                        }
                    case 6:
                        {
                            DirectoryInfo di = new DirectoryInfo("C:\\Files\\");
                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }
                            Console.WriteLine("File Deleted!!");
                            break;

                        }
                }



                Console.WriteLine("Wish to continue...(y/n)");
                c = char.Parse(Console.ReadLine());
            } while (c == 'y');
       

    }
    }
}
