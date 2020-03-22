using System;
using System.Collections.Generic;
using System.IO;

public class FileUtility
{
    public static void Save(Dictionary<string, int> data, int money)
    {
        //  컴퓨터 안에 있는 내 문서 위치를 가져온다
        string currPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string fileName = "data.txt";

        //  내 문서 위치랑 fileName 이랑 병합해준다
        //  내 문서 위치 : C:\\Users\\PL_4A_00\\Documents
        //  파일 이름과 합친다 : C:\\Users\\PL_4A_00\\Documents\\data.dat
        string fullPath = Path.Combine(currPath, fileName);
        
        using (StreamWriter sw = new StreamWriter(fullPath, false))
        {
            sw.WriteLine($"Money={money.ToString()}");

            foreach (KeyValuePair<string, int> v in data)
                sw.WriteLine($"{v.Key}={v.Value}");

            //sw.WriteLine(string.Format("{0}={1}", v.Key, v.Value));
        };
    }

    public static void Load()
    {
        string currPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string fileName = "data.txt";
        string fullPath = Path.Combine(currPath, fileName);

        if (!File.Exists(fullPath)) return;

        using (StreamReader sr = new StreamReader(fullPath))
        {
            //  Money=5000
            string[] split = sr.ReadLine().Split('=');
            Player.Get.money = int.Parse(split[1]);
            Player.Get.inventory.Clear();

            string line = null;
            while (!string.IsNullOrEmpty((line = sr.ReadLine())))
            {
                string[] s = line.Split('=');
                Player.Get.inventory.Add(s[0], int.Parse(s[1]));
            }

        }
    }

}
