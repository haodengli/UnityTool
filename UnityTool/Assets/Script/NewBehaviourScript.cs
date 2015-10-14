using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Text;

public class NewBehaviourScript : MonoBehaviour
{
	public List<Transform> test;
	// Use this for initialization
	void Start ()
	{
//		Debug.Log(Application.streamingAssetsPath);
		Debug.Log (Application.dataPath);
//		Environment.SetEnvironmentVariable
		XmlTest ();
	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawIcon (transform.position, "1.png", true);
		Gizmos.DrawCube (transform.position, new Vector3 (3, 3, 3));
	}
	// Update is called once per frame
	void Update ()
	{
	
	}

	void XmlTest ()
	{
		XElement root = new XElement ("root");
		for (int i = 0; i < 3; i ++) {
			XElement item = new XElement ("item");
			item.Add (new XAttribute ("1item" + i.ToString (), i));
			item.Add (new XAttribute ("2item" + i.ToString (), i));
			item.Add (new XAttribute ("3item" + i.ToString (), i));
		}
		using (FileStream fs = new FileStream( Application.dataPath + "/test.xml",FileMode.Create)) {
			XmlWriterSettings setting = new XmlWriterSettings ();
			setting.Indent = true;
			setting.IndentChars = "\t";
			setting.NewLineChars = "\n";
			setting.Encoding = Encoding.UTF8;
			using (XmlWriter xw = XmlWriter.Create(fs, setting)) {
				root.WriteTo (xw);
			}
		}

//		using(FileStream fs = new FileStream( FILE_DIR + "/" + "ServerConfig/terrainEditorConfig.xml", FileMode.Create ) )
		//		{
		//			XmlWriterSettings setting = new XmlWriterSettings();
		//			setting.Indent = true;
		//			setting.IndentChars = "\t";
		//			setting.NewLineChars = "\n";
		//			setting.Encoding = Encoding.UTF8;
		//			using (XmlWriter xw = XmlWriter.Create(fs, setting))
		//			{
		//				root.WriteTo(xw);
		//			}
		//		}
		//	}
	}

//	/// <summary>
//	/// 生成服务器数据
//	/// </summary>
//	public void SaveSrvData()
//	{
//		TerrainEditorDataArray terrainData = EditorDataLoader.TerrainData.GetData();
//		XElement root = new XElement("root");
//		for( int iIndex = 0; iIndex < terrainData.DataList.Count; ++iIndex )
//		{
//			TerrainEditorData terrData = terrainData.DataList[iIndex];
//			if( null == terrData )
//			{
//				continue;
//			}
//			
//			XElement terrainEditorE = new XElement( "terrainEditor" );
//			root.Add( terrainEditorE );
//			terrainEditorE.Add( new XAttribute( "id", terrData.ID.ToString() ) );
//			terrainEditorE.Add( new XAttribute( "resourceName", terrData.MapName ) );
//			//
//			XElement heroBornEditorE = new XElement( "terrainHeroBorn" );
//			terrainEditorE.Add( heroBornEditorE );
//			heroBornEditorE.Add( new XAttribute( "formationId", terrData.HeroBornData.FormationID.ToString() ) );
//			heroBornEditorE.Add( new XAttribute( "posX", terrData.HeroBornData.Pos.fX.ToString() ) );
//			heroBornEditorE.Add( new XAttribute( "posY", terrData.HeroBornData.Pos.fY.ToString() ) );
//			heroBornEditorE.Add( new XAttribute( "posZ", terrData.HeroBornData.Pos.fZ.ToString() ) );
//			heroBornEditorE.Add( new XAttribute( "rotX", terrData.HeroBornData.Rot.fX.ToString() ) );
//			heroBornEditorE.Add( new XAttribute( "rotY", terrData.HeroBornData.Rot.fY.ToString() ) );
//			heroBornEditorE.Add( new XAttribute( "rotZ", terrData.HeroBornData.Rot.fZ.ToString() ) );
//			//
//			for( int iMonsterGroupIndex = 0; iMonsterGroupIndex < terrData.GroupMonsterbornDataList.Count; ++iMonsterGroupIndex )
//			{
//				TerrainGroupMonsterBornData monsterGroupData = terrData.GroupMonsterbornDataList[iMonsterGroupIndex];
//				if( null == monsterGroupData )
//				{
//					continue;
//				}
//				
//				XElement monsterGroupEditorE = new XElement( "groupMonsterborn" );
//				monsterGroupEditorE.Add( new XAttribute( "groupId" ,monsterGroupData.GroupId) );
//				terrainEditorE.Add( monsterGroupEditorE );
//				for( int iMonsterIndex = 0; iMonsterIndex < monsterGroupData.MonsterbornDataList.Count; ++iMonsterIndex )
//				{
//					TerrainMonsterBornData monsterData = monsterGroupData.MonsterbornDataList[iMonsterIndex];
//					if( null == monsterData )
//					{
//						continue;
//					}
//					
//					XElement monsterEditorE = new XElement( "terrainMonsterBornData" );
//					monsterGroupEditorE.Add( monsterEditorE );
//					monsterEditorE.Add( new XAttribute( "monsterId", monsterData.MonsterID.ToString() ) );
//					monsterEditorE.Add( new XAttribute( "uniqueId", monsterData.UniqueId.ToString() ) );
//					monsterEditorE.Add( new XAttribute( "posX", monsterData.Pos.fX.ToString() ) );
//					monsterEditorE.Add( new XAttribute( "posY", monsterData.Pos.fY.ToString() ) );
//					monsterEditorE.Add( new XAttribute( "posZ", monsterData.Pos.fZ.ToString() ) );
//					monsterEditorE.Add( new XAttribute( "rotX", monsterData.Rot.fX.ToString() ) );
//					monsterEditorE.Add( new XAttribute( "rotY", monsterData.Rot.fY.ToString() ) );
//					monsterEditorE.Add( new XAttribute( "rotZ", monsterData.Rot.fZ.ToString() ) );
//					monsterEditorE.Add( new XAttribute( "npc", monsterData.Npc ) );
//				}
//			}
//			//
//			for( int iTriggerIndex = 0; iTriggerIndex < terrData.TriggerDataList.Count; ++iTriggerIndex )
//			{
//				TerrainTriggerData triggerData = terrData.TriggerDataList[iTriggerIndex];
//				if( null == triggerData )
//				{
//					continue;
//				}
//				
//				XElement triggerEditorE;
//				if(triggerData.Type == ETriggerType.General)
//					triggerEditorE = new XElement( "terrainCommonData" );
//				else 
//					triggerEditorE = new XElement( "terrainTriggerData" );
//				terrainEditorE.Add( triggerEditorE );
//				triggerEditorE.Add( new XAttribute( "triggerId", triggerData.TriggerId ) );
//				triggerEditorE.Add( new XAttribute( "triggerType",(int)triggerData.Type ) );
//				if( triggerData.Type != ETriggerType.General )
//				{
//					triggerEditorE.Add( new XAttribute( "posX", triggerData.Pos.fX.ToString() ) );
//					triggerEditorE.Add( new XAttribute( "posY", triggerData.Pos.fY.ToString() ) );
//					triggerEditorE.Add( new XAttribute( "posZ", triggerData.Pos.fZ.ToString() ) );
//					triggerEditorE.Add( new XAttribute( "rotX", triggerData.Rot.fX.ToString() ) );
//					triggerEditorE.Add( new XAttribute( "rotY", triggerData.Rot.fY.ToString() ) );
//					triggerEditorE.Add( new XAttribute( "rotZ", triggerData.Rot.fZ.ToString() ) );
//					triggerEditorE.Add( new XAttribute( "scaleX", triggerData.Scale.fX.ToString() ) );
//					triggerEditorE.Add( new XAttribute( "scaleY", triggerData.Scale.fY.ToString() ) );
//					triggerEditorE.Add( new XAttribute( "scaleZ", triggerData.Scale.fZ.ToString() ) );
//					
//					triggerEditorE.Add( new XAttribute( "areaType", (int)triggerData.AreaType ) );
//					
//					Debug.LogError(" --->>> "+(int)triggerData.AreaType+""+(int)triggerData.Type );
//					
//					triggerEditorE.Add( new XAttribute( "hp", triggerData.Hp ) );
//					triggerEditorE.Add( new XAttribute( "canAttacked", triggerData.CanAttacked ) );
//					triggerEditorE.Add( new XAttribute( "execDestory", triggerData.ExecDestory ) );
//					triggerEditorE.Add( new XAttribute( "eventType", (int)triggerData.EventType ) );
//				}else 
//				{
//					
//					triggerEditorE.Add(new XAttribute( "tickLimitId", triggerData.TickLimitId));
//				}
//				
//				
//				
//				if(triggerData.Type == ETriggerType.General )
//				{
//					triggerEditorE.Add(new XAttribute( "tickTimes", triggerData.TickTime));
//					if( null != triggerData.TickFunIdList )  {
//						for( int i = 0;i < triggerData.TickFunIdList.Count;i ++){
//							XElement tickFunIdList = new XElement( "tickFunIdList" );
//							tickFunIdList.Add(new XAttribute("funId",triggerData.TickFunIdList[i].FunId));
//							tickFunIdList.Add(new XAttribute("funIndex",triggerData.TickFunIdList[i].FunIndex));
//							tickFunIdList.Add(new XAttribute("wait",triggerData.TickFunIdList[i].Wait));
//							triggerEditorE.Add(tickFunIdList);
//						}
//					}
//				}
//				
//				
//				
//				if(triggerData.EventType==ETriggerEventType.Aura){
//					if( null != triggerData.AuraData){
//						
//						XElement auraEventData = new XElement( "auraEventData" );
//						
//						
//						auraEventData.Add(new XAttribute( "tickTime", triggerData.AuraData.TickTime));
//						auraEventData.Add(new XAttribute( "continueTick", triggerData.AuraData.ContinueTick));
//						auraEventData.Add(new XAttribute( "tickTargetId", triggerData.AuraData.TickTargetId));
//						auraEventData.Add(new XAttribute( "tickLimitId", triggerData.AuraData.TickLimitId));
//						auraEventData.Add(new XAttribute( "tickFuncId", triggerData.AuraData.TickFuncId));
//						auraEventData.Add(new XAttribute( "leaveAuraFuncId", triggerData.AuraData.LeaveAuraFuncId));
//						triggerEditorE.Add(auraEventData);
//					}
//					
//				}
//				if(triggerData.EventType==ETriggerEventType.Buff){
//					if(null != triggerData.BuffData ) {
//						
//						XElement buffEventData = new XElement( "buffEventData" );
//						
//						buffEventData.Add(new XAttribute( "buffId", triggerData.BuffData.BuffId));
//						
//						triggerEditorE.Add(buffEventData);
//					}
//				}
//				if(triggerData.EventType==ETriggerEventType.DropItem){
//					
//					if( null != triggerData.DropItemData){
//						
//						XElement dropItemEventData = new XElement( "dropItemEventData" );
//						
//						
//						
//						dropItemEventData.Add(new XAttribute( "dropId", triggerData.DropItemData.DropId));
//						
//						triggerEditorE.Add(dropItemEventData);
//					}
//				}
//				if(triggerData.EventType==ETriggerEventType.Plot){
//					
//					if ( null != triggerData.PlotData){
//						XElement plotEventData = new XElement( "plotEventData" );
//						plotEventData.Add(new XAttribute( "plotId", triggerData.PlotData.PlotId));
//						
//						//					XElement generalEventData = new XElement( "generalEventData" );
//						//					generalEventData.Add(new XAttribute( "tickTimes", triggerData.PlotData.TickTimes));
//						//					generalEventData.Add(new XAttribute( "tickLimitId", triggerData.GeneralData.TickLimitId));
//						//					for( int i = 0;i < triggerData.GeneralData.TickFunIdList.Count;i ++){
//						//						XElement tickFunIdList = new XElement( "tickFunIdList" );
//						//						tickFunIdList.Add(new XAttribute("funId",triggerData.GeneralData.TickFunIdList[i].FunId));
//						//						tickFunIdList.Add(new XAttribute("funIndex",triggerData.GeneralData.TickFunIdList[i].FunIndex));
//						//						tickFunIdList.Add(new XAttribute("wait",triggerData.GeneralData.TickFunIdList[i].Wait));
//						//						plotEventData.Add(tickFunIdList);
//						//					}
//						
//						
//						triggerEditorE.Add(plotEventData);
//					}
//				}
//				if(triggerData.EventType==ETriggerEventType.ToggleObj){
//					if( null != triggerData.ToggleObjData){
//						
//						XElement toggleObjEventData = new XElement( "toggleObjEventData" );
//						
//						
//						
//						toggleObjEventData.Add(new XAttribute( "active", triggerData.ToggleObjData.Active));
//						
//						triggerEditorE.Add(toggleObjEventData);
//					}
//				}
//				
//				if(triggerData.EventType == ETriggerEventType.General && triggerData.Type != ETriggerType.General)
//				{
//					XElement generalEventData = new XElement( "generalEventData" );
//					generalEventData.Add(new XAttribute( "tickTimes", triggerData.TickTime));
//					
//					for( int i = 0;i < triggerData.TickFunIdList.Count;i ++){
//						XElement tickFunIdList = new XElement( "tickFunIdList" );
//						tickFunIdList.Add(new XAttribute("funId",triggerData.TickFunIdList[i].FunId));
//						tickFunIdList.Add(new XAttribute("funIndex",triggerData.TickFunIdList[i].FunIndex));
//						tickFunIdList.Add(new XAttribute("wait",triggerData.TickFunIdList[i].Wait));
//						generalEventData.Add(tickFunIdList);
//					}
//					
//					
//					triggerEditorE.Add(generalEventData);
//				}
//				
//			}
//		}
//		
//		using(FileStream fs = new FileStream( FILE_DIR + "/" + "ServerConfig/terrainEditorConfig.xml", FileMode.Create ) )
//		{
//			XmlWriterSettings setting = new XmlWriterSettings();
//			setting.Indent = true;
//			setting.IndentChars = "\t";
//			setting.NewLineChars = "\n";
//			setting.Encoding = Encoding.UTF8;
//			using (XmlWriter xw = XmlWriter.Create(fs, setting))
//			{
//				root.WriteTo(xw);
//			}
//		}
//	}
//
//

	/*

	//读配置文件
	XmlDocument doc = new XmlDocument();
	doc.Load("blog.xml");
	XmlNode url = doc.SelectSingleNode("博客/广告地址");
	texturl.Text = url.InnerText;
	
	XmlNode Name = doc.SelectSingleNode("博客/用户名1");
	name = Name.InnerText;
	
	XmlNode Password = doc.SelectSingleNode("博客/密码1");
	password = Password.InnerText;
	
	XmlNode dbid = doc.SelectSingleNode("博客/DBID");
	DBID = int.Parse(dbid.InnerText);
	
	//写配置文件
	XmlDocument doc = new XmlDocument();
	doc.Load("blog.xml");
	XmlNode xiugai = doc.SelectSingleNode("博客");
	xiugai["DBID"].InnerText = DBID.ToString();   //修改值
	doc.Save("blog.xml");
	//该代码片段来自于: http://www.sharejs.com/codes/csharp/2131

	 */


}
