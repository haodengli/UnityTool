using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

//using UJNet;
//using UJNet.Data;
using Object = UnityEngine.Object;

public class Util
{

//	//不同平台下StreamingAssets的路径是不同的，这里需要注意一下。 
//	public static readonly string PathURL = 
//	#if UNITY_ANDROID 
//	"jar:file://" + Application.dataPath + "!/assets/"; 
//	#elif UNITY_IPHONE 
//	Application.dataPath + "/Raw/"; 
//	#elif UNITY_STANDALONE_WIN || UNITY_EDITOR 
//	"file://" + Application.dataPath + "/StreamingAssets/"; 
//	#else 
//	string.Empty; 
//	#endif

	/// <summary>
	/// 数字格式化，小于10 的 数字前面加0
	/// <param name="num">Number.</param>
	private static string NumFormatting (int num)
	{
		if (num > 9) {
			return num.ToString ();
		} else {
			return (0).ToString () + num.ToString ();
		}
	}

	/// <summary>
	/// 传一个秒数，返回 hh:mm:ss 格式
	/// </summary>
	public static string GetStringByTime (int sec)
	{
		int hours = 0;
		int minutes = 0;
		int seconds = 0;
		
		hours = sec / 3600;
		minutes = (sec - hours * 3600) / 60;
		seconds = sec - hours * 3600 - minutes * 60;
		
		string strTiem = NumFormatting (hours) + ":" + NumFormatting (minutes) + ":" + NumFormatting (seconds);  
		return strTiem;
	}

	/// <summary>
	/// val 是否在int数组中
	/// </summary>
	public static bool IsIntExistArray (int val, int[] arr)
	{
		if (arr == null) {
			return false;
		}
		
		if (0 == arr.Length) {
			return false;
		}
		
		for (int i  =0; i<arr.Length; i++) {
			if (arr [i] == val) {
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// val 是否在int List 中
	/// </summary>
	public static bool IsIntExistIntList (int val, List<int> arr)
	{
		if (arr == null) {
			return false;
		}
		
		if (0 == arr.Count) {
			return false;
		}
		
		for (int i  =0; i<arr.Count; i++) {
			if (arr [i] == val) {
				return true;
			}
		}
		return false;
	}

	public static bool IsTExistTList<T> (T val, List<T> arr) where T : Component
	{
		if (val == null)
			return false;
		if (arr.Count == 0)
			return false;
		for (int i  =0; i<arr.Count; i++) {
			if (arr [i] == val) {
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// string list 转 int list
	/// </summary>
	public static List<int> ConventStringList2IntList (List<string> strList)
	{
		if (strList == null) {
			return null;
		}
		List<int> list = new List<int> ();
		for (int i = 0; i < strList.Count; i++) {
			string s = strList [i];
			int num = System.Convert.ToInt32 (s);
			list.Add (num);
		}
		return list;
	}

	/// <summary>
	/// 字符串转int list
	/// </summary>
	public static List<int>  ConventString2IntBySplitSign (string splitStr, char sign)
	{
		string[] args = splitStr.Split (new char[]{sign});
		List<string> strList = new List<string> (args);
		List<int> intList = ConventStringList2IntList (strList);
		return intList;
	}

	/// <summary>
	/// 解析文本文档转为map
	/// </summary>
	public static Dictionary<string,string> GetDicFromText(string path)
	{
		TextAsset asset = Resources.Load<TextAsset>(path);
		string[] lines = asset.text.Split(new char[]{ '\r', '\n' });
		Dictionary<string, string> dic = String2Map(lines);
		return dic;
	}

	/// <summary>
	/// 字符串转map
	/// </summary>
	public static Dictionary<string, string> String2Map(string[] lines)
	{
		Dictionary<string, string> map = new Dictionary<string, string> ();
		for (int i = 0; i < lines.Length; i++)
		{
			string[] kv = lines[i].Split(new char[]{'='} );
			if (kv.Length >= 2)
			{
				map[kv[0].Trim()] = kv[1].Trim();
			}
		}
		return map;
	}

	/// <summary>
	/// 计算一个点的list的距离  包含一个其他点
	/// </summary>
	public static float Vector3ListDistance(List<Vector3> vList,Vector3 currentPos)
	{
		float dis = 0;
		int count = vList.Count;
		
		for(int i = 0 ; i < count ; i++ )
		{
			if( i == 0)
			{
				dis += Vector3.Distance(currentPos,vList[i]);
			}else{
				dis += Vector3.Distance(vList[i -1] , vList[i]);
			}
		}
		
		return dis;
	}

}