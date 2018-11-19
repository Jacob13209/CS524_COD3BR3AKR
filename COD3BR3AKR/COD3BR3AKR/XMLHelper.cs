using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// From: http://www.cnblogs.com/linlf03/archive/2011/12/15/2288903.html
/// </summary>
namespace COD3BR3AKR
{
    public class XMLHelper
    {

        /// <summary>
        /// Read the attribute value of a node. 
        /// If the attribute is empty, return the entire InnerText of that node，elsewise only return the value for that attribute
        /// </summary>
        /// <param name="path">xml file path</param>
        /// <param name="node">XML Node</param>
        /// <param name="attribute">Attribute of the node</param>
        /// <returns>The entire InnerText of that node，elsewise only return the value for that attribute</returns>
        /// Example: XMLHelper.Read(path, "PersonF/person[@Name='Person2']", "");
        ///          XMLHelper.Read(path, "PersonF/person[@Name='Person2']", "Name");
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
        /// Add new element and attribute to the node
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="node">Node to be modified</param>
        /// <param name="element">Element to be added, can be empty or null empty. As new element if it is null empty, otherwise as attribute</param>
        /// <param name="attribute">Attribute to be added, can be empty or null empty. As new attribute if it is null empty, otherwise as element</param>
        /// <param name="value">Value to be added</param>
        /// Example：XMLHelper.Insert(path, "PersonF/person[@Name='Person2']","Num", "ID", "88");
        ///          XMLHelper.Insert(path, "PersonF/person[@Name='Person2']","Num", "", "88");
        ///          XMLHelper.Insert(path, "PersonF/person[@Name='Person2']", "", "ID", "88");
        public static bool Insert(string path, string node, string element, string attribute, string value)
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

                if (string.IsNullOrEmpty(element))
                {
                    //attribute is null empty，add as new attribute
                    if (!string.IsNullOrEmpty(attribute))
                    {

                        XmlElement xe = (XmlElement)xn;
                        // <person Name="Person2" ID="88"> XMLHelper.Insert(path, "PersonF/person[@Name='Person2']","Num", "ID", "88");
                        xe.SetAttribute(attribute, value);
                    }
                }
                else //element is null empty，add new child element   
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
        /// Modify the value of a node
        /// </summary>
        /// <param name="path">XML file path</param>
        /// <param name="node">Node to be modified/param>
        /// <param name="attribute">attribute name，update the attribute value if null empty, otherwise update the node value</param>
        /// <param name="value">attribute value</param>
        /// Example: XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "", "888");
        ///          XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "Num", "999"); 
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
                    xe.InnerText = value;//Orginal:<ID>2</ID> To be updated:<ID>888</ID>  XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "", "888");
                else
                    xe.SetAttribute(attribute, value); //Orginal: <ID Num="3">888</ID> To be updated:<ID Num="999">888</ID>    XMLHelper.Update(path, "PersonF/person[@Name='Person3']/ID", "Num", "999"); 
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
        /// Delete node
        /// </summary>
        /// <param name="path">XML Path</param>
        /// <param name="node">Node to be deleted</param>
        /// <param name="attribute">Attribute name，delete entire node on empty, otherwise delete the attribute</param>
        /// Example：XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "");
        ///          XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "Num");
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
                {
                    xn.ParentNode.RemoveChild(xn);//<ID Num="999">888</ID> delete entire node       -->  XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "");
                }                    
                else
                {
                    xe.RemoveAttribute(attribute);//<ID Num="999">888</ID> update to:<ID>888</ID>   -->  XMLHelper.Delete(path, "PersonF/person[@Name='Person3']/ID", "Num");
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

    }
}
