using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace CoPF
{
    class DataIO
    {
        public void WriteData(List<string> namePrefixes)
        {
            try
            {
                FileStream filestream = File.Create(@"prefconfig.cpf");
                BinaryWriter writer = new BinaryWriter(filestream);
                writer.Write(namePrefixes.Count);
                foreach (string prefix in namePrefixes)
                {
                    writer.Write(prefix);
                }

                writer.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public List<string> ReadData()
        {
            List<string> namePrefixes = new List<string>();
            FileStream fileStream = new FileStream(@"prefconfig.cpf", FileMode.OpenOrCreate);
            BinaryReader reader = new BinaryReader(fileStream);

            try
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    namePrefixes.Add(reader.ReadString());
                }
                reader.Close();
                return namePrefixes;
            }
            catch (Exception)
            {
                reader.Close();
                return new List<string>();
            }

        }
    }
}
