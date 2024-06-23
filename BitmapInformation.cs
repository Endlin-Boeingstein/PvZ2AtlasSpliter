using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//获取位图信息类
class BitmapInformation
{
    //获取位图信息部分
   public ArrayList getBitmapInfoList(string Apath,ArrayList ResInfoList)
    {
        //建立顺序表
        ArrayList BitmapInfoList = new ArrayList();
        try
        {
            //定义坐标和尺寸
            int srcImageX = 0;
            int srcImageY = 0;
            int srcImageWidth = 0;
            int srcImageHeight = 0;
            //获取整图
            //第二种选择//Image image = Bitmap.FromFile(Apath);
            Bitmap image = new Bitmap(Apath);
            for (int i = 0; i < ResInfoList.Count; i++)
            {
                //获取对应五元组
                SpriteInformation spriteInformation = (SpriteInformation)ResInfoList[i];
                //获取对应的坐标与尺寸
                srcImageX = spriteInformation.x;
                srcImageY = spriteInformation.y;
                srcImageWidth = spriteInformation.width;
                srcImageHeight = spriteInformation.height;
                // 定义切割区域
                Rectangle cropArea = new Rectangle(srcImageX, srcImageY, srcImageWidth, srcImageHeight);
                //创建一个新的Bitmap用于存放切割后的图片
                //第二种选择//Image croppedBitmap = new Bitmap(cropArea.Width, cropArea.Height);
                Bitmap croppedBitmap = new Bitmap(cropArea.Width, cropArea.Height);
                //创建切割对象
                Graphics BitmapGraphics = Graphics.FromImage(croppedBitmap);
                //绘制切割后图像
                BitmapGraphics.DrawImage(image, new Rectangle(0, 0, cropArea.Width, cropArea.Height), cropArea, GraphicsUnit.Pixel);
                //添加进顺序表
                BitmapInfoList.Add(croppedBitmap);
            }
        }
        catch (ArgumentException ex)
        {
            // 这里可以进一步处理异常，比如记录日志或给用户反馈
            Console.WriteLine($"加载图片时发生错误: {ex.Message}");
        }
        return BitmapInfoList;
    }
}