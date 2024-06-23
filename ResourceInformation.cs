using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//路径、坐标、宽高五元组
class SpriteInformation
{
    public string spritePath = "";
    public int x = 0;
    public int  y = 0;
    public int width = 0;
    public int height = 0;
}



//资源信息提取部分
class ResourceInformation
{
    public ArrayList getResInfoList(string Jpath)
    {
        //建立顺序表
        ArrayList ResInfoList = new ArrayList();
        try
        {
            //读取文本
            string json = File.ReadAllText(Jpath);
            //将读取文本转换为JSON对象
            JObject rss = JObject.Parse(json);
            //resources转json数组
            JArray Rja = JArray.Parse(rss["resources"].ToString());
            //遍历resources精灵图信息
            foreach (var item in Rja)
            {
                //如果有atlas却没有parent的情况，那么扔掉这种情况
                if (((JObject)item).ContainsKey("atlas") && !((JObject)item).ContainsKey("parent")) { }
                else
                {
                    //建立五元组对象
                    SpriteInformation spriteInfo = new SpriteInformation();
                    //path转JArray数组
                    JArray pathArray = JArray.Parse(item["path"].ToString());
                    //遍历path数组，得到路径
                    for (int i = 0; i < pathArray.Count; i++)
                    {
                        spriteInfo.spritePath += "\\" + pathArray[i];
                    }
                    //为五元组剩余部分赋值
                    spriteInfo.x = int.Parse(item["ax"].ToString());
                    spriteInfo.y = int.Parse(item["ay"].ToString());
                    spriteInfo.width = int.Parse(item["aw"].ToString());
                    spriteInfo.height = int.Parse(item["ah"].ToString());
                    //添加进顺序表
                    ResInfoList.Add(spriteInfo);
                }
            }
        }
        catch (ArgumentException ex)
        {
            // 这里可以进一步处理异常，比如记录日志或给用户反馈
            Console.WriteLine($"加载Resource资源文件时发生错误: {ex.Message}");
        }
        return ResInfoList;
    }
}