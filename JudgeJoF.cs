using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//建立判断类
class JudgeJoF
{
	//判断完成后路径定义
	public string Jpath = null;
	public string Apath = null;
	//类型定义
	public string typejson1 = "12313";
    public string typejson2 = "12310";
    public string typeatlas = "13780";
	//创建btr读取文件类型实例
	public BinaryTypeReader btr = new BinaryTypeReader();
	//创建asp图集分割类型实例
	public AtlasSpliter asp=new AtlasSpliter();
	//判断第二个路径是否为json文件
	public void ReJudgeJ(string filepath)
    {
		try
		{
			if (File.Exists(filepath))
			{
                if (btr.BinaryTypeRead(filepath) == typejson1 || btr.BinaryTypeRead(filepath) == typejson2)
                {
                    Console.WriteLine("已检测到为json文件");
                    this.Jpath = filepath;
                }
                else if (btr.BinaryTypeRead(filepath) == typeatlas)
                {
                    Console.WriteLine("已检测到为整图文件，请再将json拖入窗体，并按回车键");
                    this.Apath = filepath;
                    ReJudgeJ(Console.ReadLine().Trim('"'));
                }
                else
                {
                    Console.WriteLine("文件类型不符！请检查！");
                    Console.WriteLine("请将文件拖入窗体，并按回车键");
                    ReJudgeJ(Console.ReadLine().Trim('"'));
                }
            }
			else
			{
				Console.WriteLine("未检测到文件或文件夹！请检查！");
                Console.WriteLine("请将文件拖入窗体，并按回车键");
                ReJudgeJ(Console.ReadLine().Trim('"'));
            }
		}
		catch
		{
			Console.WriteLine("ERROR");

		}
	}
	//判断第二个路径是否为整图
	public void ReJudgeA(string filepath)
	{
		try
		{
			if (File.Exists(filepath))
			{
                if (btr.BinaryTypeRead(filepath) == typejson1 || btr.BinaryTypeRead(filepath) == typejson2)
                {
                    Console.WriteLine("已检测到为json文件，请再将整图拖入窗体，并按回车键");
                    this.Jpath = filepath;
                    ReJudgeA(Console.ReadLine().Trim('"'));
                }
                else if (btr.BinaryTypeRead(filepath) == typeatlas)
                {
                    Console.WriteLine("已检测到为整图文件");
                    this.Apath = filepath;
                }
                else
                {
                    Console.WriteLine("文件类型不符！请检查！");
                    Console.WriteLine("请将文件拖入窗体，并按回车键");
                    ReJudgeA(Console.ReadLine().Trim('"'));
                }
            }
			else
			{
				Console.WriteLine("未检测到文件或文件夹！请检查！");
                Console.WriteLine("请将文件拖入窗体，并按回车键");
                ReJudgeA(Console.ReadLine().Trim('"'));
            }
		}
		catch
		{
			Console.WriteLine("ERROR");

		}
	}
	//判断是json还是整图路径
	public void Judge(string filepath)
	{

		try
		{
			if (File.Exists(filepath))
			{
				if (btr.BinaryTypeRead(filepath) == typejson1 || btr.BinaryTypeRead(filepath) == typejson2)
				{
                    Console.WriteLine("已检测到为json文件，请再将整图拖入窗体，并按回车键");
                    this.Jpath = filepath;
                    ReJudgeA(Console.ReadLine().Trim('"'));
					//图集分割
					asp.AtlasSplit(Jpath, Apath);
                }
				else if(btr.BinaryTypeRead(filepath) == typeatlas)
				{
                    Console.WriteLine("已检测到为整图文件，请再将json拖入窗体，并按回车键");
                    this.Apath = filepath;
                    ReJudgeJ(Console.ReadLine().Trim('"'));
                    //图集分割
                    asp.AtlasSplit(Jpath, Apath);
                }
				else
				{
                    Console.WriteLine("文件类型不符！请检查！");
                    Console.WriteLine("请将文件拖入窗体，并按回车键");
                    Judge(Console.ReadLine().Trim('"'));
                }
            }
			else
			{
				Console.WriteLine("未检测到文件！请检查！");
                Console.WriteLine("请将文件拖入窗体，并按回车键");
                Judge(Console.ReadLine().Trim('"'));
            }
		}
		catch
		{
			Console.WriteLine("ERROR");
		}

	}
}