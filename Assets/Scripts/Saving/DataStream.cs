using System.IO;
using System;

namespace Items
{
    public class DataStream : ISavingData<Saving>
    {
        public void Save(Saving data, string path = null)
        {
            if (path == null) return;
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(data.Name);
                sw.WriteLine(data.Vector3Position.X);
                sw.WriteLine(data.Vector3Position.Y);
                sw.WriteLine(data.Vector3Position.Z);
                sw.WriteLine(data.IsEnabled);
            }
        }

        public Saving Load(string path = null)
        {
            var result = new Saving();
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    result.Name = sr.ReadLine();
                    result.Vector3Position.X = Convert.ToSingle(sr.ReadLine());
                    result.Vector3Position.Y = Convert.ToSingle(sr.ReadLine());
                    result.Vector3Position.Z = Convert.ToSingle(sr.ReadLine());
                    result.IsEnabled = Convert.ToBoolean(sr.ReadLine());
                }
            }
            return result;
        }

    }
}