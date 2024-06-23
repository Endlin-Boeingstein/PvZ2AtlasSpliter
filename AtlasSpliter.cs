using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//图集分割类
class AtlasSpliter
{
    //创建资源信息对象
    ResourceInformation resourceInformation=new ResourceInformation();
    //创建位图信息对象
    BitmapInformation bitmapInformation=new BitmapInformation();
    //图集分割部分
    public void AtlasSplit(string Jpath,string Apath)
    {
        try
        {
            //获取整图文件夹路径
            string activeDir = Path.GetDirectoryName(Apath);
            //获取资源信息
            ArrayList ResInfoList = resourceInformation.getResInfoList(Jpath);
            //遍历以创建文件夹
            for (int i = 0; i < ResInfoList.Count; i++)
            {
                //获取文件夹路径
                string dirpath = activeDir + (((SpriteInformation)ResInfoList[i]).spritePath).Substring(0, (((SpriteInformation)ResInfoList[i]).spritePath).LastIndexOf("\\"));
                //创建新文件夹以存放位图
                System.IO.Directory.CreateDirectory(dirpath);
            }
            //获取位图信息
            ArrayList BitmapInfoList = bitmapInformation.getBitmapInfoList(Apath, ResInfoList);
            for (int i = 0; i < ResInfoList.Count; i++)
            {
                //输出图集()
                //第二种选择//((Image)BitmapInfoList[i]).Save(activeDir + ((SpriteInformation)ResInfoList[i]).spritePath + ".png");
                ((Bitmap)BitmapInfoList[i]).Save(activeDir + ((SpriteInformation)ResInfoList[i]).spritePath + ".png");
            }
        }
        catch
        {
            Console.WriteLine("AtlasSplite ERROR");
            //提示按任意键继续
            Console.WriteLine("Press any key to continue...");
            //输入任意键退出
            Console.ReadLine();
        }
    }
}