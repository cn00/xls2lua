using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using GameManager.functions;
using System.Drawing.Design;
using System.Xml;
using System.IO;

namespace GameManager.config
{

    public class RecordClick
    {
        //  打开的doc文档
        private XmlDocument doc = new XmlDocument();    
        //  梗节点
        private XmlElement root;        
        //  表结构节点
        private XmlElement tableNode; 
        //  服务器节点
        private XmlElement serverNode;
        //  客户端节点
        private XmlElement clientNode;
        //  公共节点
        private XmlElement publicNode;

        public RecordClick()
        {
            root = doc.CreateElement("Root");
        }

        //XML存储路径
        private const string RECORD_CLICK_XML = "./RecordClick.xml";


        //写XML
        //                                  键名      第几层节点       是否创建子节点
        public void writeRecordClick(string tagName,  int nCreatNode , bool isChildNode)
        {
            if (doc != null)
            {
                XmlElement element = doc.CreateElement(tagName);

                element.SetAttribute(tagName, nCreatNode.ToString() );

                switch( nCreatNode )
                {
                    case 0:
                        tableNode = doc.CreateElement(tagName);
                        tableNode.AppendChild(element);
                        ClearXML(false);
                        break;
                    case 1:
                        if (isChildNode)
                        {
                            serverNode = doc.CreateElement(tagName);
                        }
                        serverNode.AppendChild(element);
                        tableNode.AppendChild(serverNode);
                        break;
                    case 2:
                        if (isChildNode)
                        {
                            clientNode = doc.CreateElement(tagName);
                        }
                        clientNode.AppendChild(element);
                        tableNode.AppendChild(clientNode);
                        break;
                    case 3:
                        if (isChildNode)
                        {
                            publicNode = doc.CreateElement(tagName);
                        }
                        publicNode.AppendChild(element);
                        tableNode.AppendChild(publicNode);
                        break;
                }

                root.AppendChild(tableNode);
                doc.AppendChild(root);

            }else
            {
                return ;
            }
            try
            {
                //保存上面的修改　　  
                doc.Save(RECORD_CLICK_XML);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //读取XML
        //                          需要改变的键值   其父节点名字        是否遍历其父节点
        public bool readRecordClick(string tagName, string strNodeParent = "", bool isErgodic = false)  
        {  
            try  
             {

				 if (!System.IO.File.Exists(RECORD_CLICK_XML))
                 {
                     //表示文件不存在
                     return false;
                 }

				 FileInfo fi = new FileInfo(RECORD_CLICK_XML);
                //  表示该表为空
                 if (fi.Length <= 3)
                 {
                     return false;
                 }


                 doc.Load(RECORD_CLICK_XML);///
                 XmlNode nodeRoot = doc.SelectSingleNode("Root");
                 XmlNode nodeTable = nodeRoot.SelectSingleNode("表结构");
                 XmlNodeList nodeList = nodeTable.ChildNodes;
                 foreach (XmlNode xl in nodeList)
                 {
                     XmlElement element = (XmlElement)xl;
                     if (!isErgodic)
                     {
                         if (element.Name == tagName)
                         {
                             return true;
                         }
                     }
                     else
                     {
                         if (strNodeParent == element.Name)
                         {
                             foreach (XmlNode xn in xl.ChildNodes)
                             {
                                 XmlElement element1 = (XmlElement)xn;
                                 if (element1.Name == tagName)
                                 {
                                     return true;
                                 }
                             }
                         }

                     }
                 }

             }  
              catch (Exception e)  
              {  
                  throw e;  
              }
              return false;
            }  


        public void ClearXML(bool isSave = true)
        {
			if (!System.IO.File.Exists(RECORD_CLICK_XML))
            {
                //表示文件不存在
                return ;
            }
			FileInfo fi = new FileInfo(RECORD_CLICK_XML);
            //  表示该表为空
            if (fi.Length <= 3)
            {
                return ;
            }
            doc.RemoveAll();
            //清空文件里面所有的内容
			FileStream fs = new FileStream(RECORD_CLICK_XML, System.IO.FileMode.Create);
            fs.Close();
        }


    }
}
