
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CANoe_function_dll
{
    public class CAPL_extension
    {
        //Method used for Addition
        public static int Add(int a, int b)
        {
            return a + b;
        }

        //Method used for Subtraction
        public static int Sub(int a, int b)
        {
            return a - b;
        }

        public static int SetActDir(string s)
        {
            string path;

            path = s;

            try
            {
                //Set the current directory.
                Directory.SetCurrentDirectory(path);
            }
            catch (DirectoryNotFoundException a)
            {
                return -1;
            }
            return 0;
        }

        public static int AddComment(string TextToAdd)
        {

            try
            {
                string tempfile = Path.GetTempFileName();
                string ActualDir = Directory.GetCurrentDirectory();
                string[] filePaths = Directory.GetFiles(@ActualDir, "*.log");
                for (int j = 0; j < filePaths.Length; j++)
                {
                    using (var writer = new FileStream(tempfile, FileMode.Create))
                    using (var reader = new FileStream(filePaths[j], FileMode.Open))
                    {

                        var stringBytes = Encoding.UTF8.GetBytes(TextToAdd + Environment.NewLine);
                        writer.Write(stringBytes, 0, stringBytes.Length);

                        reader.CopyTo(writer);
                    }
                    File.Copy(tempfile, filePaths[j], true);
                    File.Delete(tempfile);
                }
            }
            catch (Exception a)
            {
                return -1;
            }
            return 0;
        }

        public static int CreateDirectory(string s)
        {
            string path;
            int state;

            path = s;
            state = 0;


            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    state = 1; // 1 means directory exists

                }

                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    state = 2; // 2 means tried to create
                }
            }
            catch (Exception a)
            {
                return -1;
            }

            if (state == 1)
            {
                return 1;
            }

            else
            {
                return 0;
            }
        }
    }
}
