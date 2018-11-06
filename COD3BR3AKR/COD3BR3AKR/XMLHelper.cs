using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace COD3BR3AKR
{
    public class XMLHelper
    {

        /// <summary>
        /// 读取节点中某一个属性的值。如果attribute为空，则返回整个节点的InnerText，否则返回具体attribute的值
        /// </summary>
        /// <param name="path">xml文件路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">节点中的属性</param>
        /// <returns>如果attribute为空，则返回整个节点的InnerText，否则返回具体attribute的值</returns>
        /// 使用实例: XMLHelper.Read(path, "PersonF/person[@Name='Person2']", "");
        ///  XMLHelper.Read(path, "PersonF/person[@Name='Person2']", "Name");
        public static string Read(string path, string node, string attribute)
        {
            if (File.Exists(path) == false)
            {
                return string.Empty;
            }
            string value = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return value;
        }


        /// <summary>
        /// 向节点中增加节点元素，属性
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">要操作的节点</param>
        /// <param name="element">要增加的节点元素，可空可不空。非空时插入新的元素，否则插入该元素的属性</param>
        /// <param name="attribute">要增加的节点属性，可空可不空。非空时插入元素值，否则插入元素值</param>
        /// <param name="value">要增加的节点值</param>
        /// 使用实例：XMLHelper.Insert(path, "PersonF/person[@Name='Person2']","Num", "ID", "88");
        /// XMLHelper.Insert(path, "PersonF/person[@Name='Person2']","Num", "", "88");
        /// XMLHelper.Insert(path, "PersonF/person[@Name='Person2']", "", "ID", "88");
        public static bool Insert(string path, string node, string element, string attribute, string value)
        {
            if (File.Exists(path) == false)
            {
                return false;
            }
            try
            {
                Console.WriteLine("This is Insert");
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                //如果element，则增加该属性 
                if (string.IsNullOrEmpty(element))
                {
                    //如果attribute不为空，增加该属性
                    if (!string.IsNullOrEmpty(attribute))
                    {

                        XmlElement xe = (XmlElement)xn;
                        // <person Name="Person2" ID="88"> XMLHelper.Insert(path, "PersonF/person[@Name='Person2']","Num", "ID", "88");
                        xe.SetAttribute(attribute, value);
                    }
                }
                else //如果element不为空，则preson下增加节点   
                {
                    XmlElement xe = doc.CreateElement(element);
                    if (string.IsNullOrEmpty(attribute))
                        // <person><Num>88</Num></person>  XMLHelper.Insert(path, "PersonF/person[@Name='Person2']","Num", "", "88");
                        xe.InnerText = value;
                    else
                        // <person> <Num ID="88" /></person>  XMLHelper.Insert(path, "PersonF/person[@Name='Person2']", "", "ID", "88");
                        xe.SetAttribute(attribute, value);
                    xn.AppendChild(xe);
                }
                doc.Save(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 修改节点值
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">要修改的节点</param>
        /// <param name="attribute">属性名，非空时修改节点的属性值，否则修改节点值</param>
        /// <param name="value">属性值</param>
        /// 实例 XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "", "888");
        /// XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "Num", "999"); 
        public static bool Update(string path, string node, string attribute, string value)
        {
            if (File.Exists(path) == false)
            {
                return false;
            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (string.IsNullOrEmpty(attribute))
                    xe.InnerText = value;//原<ID>2</ID> 改变:<ID>888</ID>  XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "", "888");
                else
                    xe.SetAttribute(attribute, value); //原<ID Num="3">888</ID> 改变<ID Num="999">888</ID>    XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "Num", "999"); 
                doc.Save(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">要删除的节点</param>
        /// <param name="attribute">属性，为空则删除整个节点，不为空则删除节点中的属性</param>
        /// 实例：XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "");
        /// XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "Num");
        public static bool Delete(string path, string node, string attribute)
        {
            if (File.Exists(path) == false)
            {
                return false;
            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if (string.IsNullOrEmpty(attribute))
                    xn.ParentNode.RemoveChild(xn);// <ID Num="999">888</ID>的整个节点将被移除  XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "");
                else
                    xe.RemoveAttribute(attribute);//<ID Num="999">888</ID> 变为<ID>888</ID> XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "Num");
                doc.Save(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static void CreateXMLFile(string filePath, string rootNode)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode root = doc.CreateElement(rootNode);
            doc.AppendChild(root);
            doc.Save(filePath);
        }

        public static void XMLMTest()
        {
            string path = "Person.xml";
            //XMLHelper.Read(path, "PersonF/person[@Name='Person2']", "Name");

            XMLHelper.Insert(path, "PersonF", "Num", "ID", "88");
            //XMLHelper.Insert(path, "PersonF", "Num", "", "88");
            //XMLHelper.Insert(path, "PersonF", "", "ID", "88");

            //XMLHelper.Update(path, "PersonF/person[@Name='Person3']", "Num", "888");
            //XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "Num", "999");
            //XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "", "888");

            //XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "Num");

            //XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "");

        }
    }
}
