using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//二进制类型读取类
class BinaryTypeReader
{
    //二进制类型读取部分
    public string BinaryTypeRead(string filepath)
    {
        
        //创建路径文件夹实例
        DirectoryInfo TheFolder = new DirectoryInfo(filepath);
        //创建文件数组
        //FileInfo[] files = TheFolder.GetFiles();
        //为文件数组排序
        //Array.Sort(files, new FileNameSort());
        //流式读取文件类型
        FileStream stream = new FileStream(TheFolder.FullName, FileMode.Open, FileAccess.Read);
        BinaryReader reader = new BinaryReader(stream);
        string fileclass = "";
        try
        {
            for (int i = 0; i < 2; i++)
            {
                fileclass += reader.ReadByte().ToString();
            }
        }
        catch (Exception)
        {
            throw;
        }
        stream.Close();
        return fileclass;
    }
}