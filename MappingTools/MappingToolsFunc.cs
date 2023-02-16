using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace MappingTools
{
    class MappingToolsFunc
    {
        //convet XML To String..
        public static string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented; xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }
        public static string RemoveLastTerminator(string inputValue)
        {
            string outputValue = "";
            if (inputValue.EndsWith("\r\n"))
                outputValue = inputValue.Remove(inputValue.LastIndexOf("\r\n"), 1);
            else
                outputValue = inputValue;
            return outputValue;
        }
        public static string AddDefaultMinMax(string value)
        {
            string valueWithMinMax = "";
            if (value.IndexOf(" ") > -1)
                valueWithMinMax = value;
            else
                valueWithMinMax = value + " 0" + " S";
            return valueWithMinMax;
        }
        public static void StreamWriterForMts(string path, string inputStr)
        {
            StreamWriter sr = new StreamWriter(path, false, Encoding.Default);

            //default value
            sr.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sr.WriteLine("<!--DOCTYPE TTMAKER SYSTEM \"ttmaker60.dtd\"-->");
            sr.WriteLine("<TTMAKER Version=\"6.0\"><NEWTREE Filename=\"" + path + "\"><ROOT SimpleTypeName=\"Root\" SetUpProperties=\"DEFAULT\" SetUpComponents=\"DELETE\" OrderSubtypes=\"ASCENDING\"><Sequence partition=\"NO\"></Sequence>");
            sr.WriteLine("<CharTextWestern><Size Min=\"0\" Max=\"S\"/>");
            sr.WriteLine("<CharSize Min=\"0\" Max=\"S\"/>");
            sr.WriteLine("<Western CharSet=\"NATIVE\"/>");
            sr.WriteLine("<ValueRestrictions IgnoreCase=\"NO\" Rule=\"INCLUDE\"></ValueRestrictions>");
            sr.WriteLine("</CharTextWestern>");
            sr.WriteLine("</ROOT>");
            /*****create segment (CATEGORY)*****/
            sr.WriteLine("<CATEGORY SimpleTypeName=\"Segments\" CategoryParent=\"Root\" OrderSubtypes=\"ASCENDING\"><Sequence partition=\"NO\"></Sequence>");
            sr.WriteLine("<CharTextWestern><Size Min=\"0\" Max=\"S\"/>");
            sr.WriteLine("<CharSize Min=\"0\" Max=\"S\"/>");
            sr.WriteLine("<Western CharSet=\"NATIVE\"/>");
            sr.WriteLine("<ValueRestrictions IgnoreCase=\"NO\" Rule=\"INCLUDE\"></ValueRestrictions>");
            sr.WriteLine("</CharTextWestern>");
            sr.WriteLine("</CATEGORY>");
            /*****END*****/

            /*****create segment (GROUP)*****/

            if (inputStr.IndexOf("\r\n\r\n") > -1)
            {
                string[] segmentArray = Regex.Split(RemoveLastTerminator(inputStr), "\r\n\r\n", RegexOptions.IgnoreCase);
                foreach (string segment in segmentArray)
                {
                    sr.WriteLine(CreateSegmentsGroup(segment, "", ""));
                }
            }
            else
            {
                sr.WriteLine(CreateSegmentsGroup(RemoveLastTerminator(inputStr), "", ""));
            }
            

            /*****END*****/

            /*****create item (CATEGORY)*****/
            sr.WriteLine("<CATEGORY SimpleTypeName=\"Item\" CategoryParent=\"Root\" OrderSubtypes=\"ASCENDING\"><Sequence partition=\"NO\"></Sequence>");
            sr.WriteLine("<CharTextWestern><Size Min=\"0\" Max=\"S\"/>");
            sr.WriteLine("<CharSize Min=\"0\" Max=\"S\"/>");
            sr.WriteLine("<Western CharSet=\"NATIVE\"/>");
            sr.WriteLine("<ValueRestrictions IgnoreCase=\"NO\" Rule=\"INCLUDE\"></ValueRestrictions>");
            sr.WriteLine("</CharTextWestern>");
            sr.WriteLine("</CATEGORY>");
            /*****END*****/

            /*****create items (CATEGORY)*****/

            if (inputStr.IndexOf("\r\n\r\n") > -1)
            {
                string[] itemsArray = Regex.Split(RemoveLastTerminator( inputStr), "\r\n\r\n", RegexOptions.IgnoreCase);
                foreach (string segment in itemsArray)
                {
                    sr.WriteLine(CreateItemCategory(segment, "", ""));
                }
            }
            else
            {
                sr.WriteLine(CreateItemCategory(RemoveLastTerminator(inputStr), "", ""));
            }

            
            /*****END*****/

            sr.WriteLine("</NEWTREE>");
            sr.WriteLine("</TTMAKER>");

            sr.Flush();
            sr.Close();
        }
        public static string CreateSegmentsGroup(string itemArrayWithSegmentName, string orderSubtypes, string partitionSequence)
        {
            string segmentsGroup = "";
            string _orderSubtypes = "";
            if (orderSubtypes == "")
                _orderSubtypes = "ASCENDING";
            else
                _orderSubtypes = orderSubtypes;
            string _partitionSequence = "";
            if (partitionSequence == "")
                _partitionSequence = "NO";
            else
                _partitionSequence = partitionSequence;

            string[] itemArray = Regex.Split(itemArrayWithSegmentName, "\r\n", RegexOptions.IgnoreCase);
            segmentsGroup += "<GROUP SimpleTypeName=\"" + RemoveFirstUnderLine(itemArray[0]) + "\" CategoryOrGroupParent=\"Segments Root\" OrderSubtypes=\"" + _orderSubtypes + "\"><Sequence partition=\"" + _partitionSequence + "\">\r\n";
            for (int i = 1; i < itemArray.Length; i++)
            {
                segmentsGroup += "<SequenceComponent><RelativeTypeName>" + Regex.Split(AddDefaultMinMax(itemArray[i]), " ", RegexOptions.IgnoreCase)[0] +" "+RemoveFirstUnderLine(itemArray[0])+" Item"+ "</RelativeTypeName>\r\n";
                segmentsGroup += "<Range Min=\"1\" Max=\"1\"/>\r\n";
                segmentsGroup += "</SequenceComponent>";
                if (i < itemArray.Length - 1)
                    segmentsGroup += "\r\n";
            }
            segmentsGroup += "\r\n</Sequence>\r\n</GROUP>";
            return segmentsGroup;
        }
        public static string CreateItemCategory(string itemNamesArryWithSegmentName, string orderSubtypes, string partitionSequence)
        {
            string itemsWithCategoryName = "";
            string _orderSubtypes = "";
            if (orderSubtypes == "")
                _orderSubtypes = "ASCENDING";
            else
                _orderSubtypes = orderSubtypes;
            string _partitionSequence = "";
            if (partitionSequence == "")
                _partitionSequence = "NO";
            else
                _partitionSequence = partitionSequence;

            string[] itemsArray = Regex.Split(itemNamesArryWithSegmentName, "\r\n", RegexOptions.IgnoreCase);
            itemsWithCategoryName += "<CATEGORY SimpleTypeName=\""+ RemoveFirstUnderLine(itemsArray[0]) +"\" CategoryParent=\"Item Root\" OrderSubtypes=\""+_orderSubtypes+"\"><Sequence partition=\""+_partitionSequence+"\"></Sequence>\r\n";
            itemsWithCategoryName += "<CharTextWestern><Size Min=\"0\" Max=\"S\"/>\r\n";
            itemsWithCategoryName += "<CharSize Min=\"0\" Max=\"S\"/>\r\n";
            itemsWithCategoryName += "<Western CharSet=\"NATIVE\"/>\r\n";
            itemsWithCategoryName += "<ValueRestrictions IgnoreCase=\"NO\" Rule=\"INCLUDE\"></ValueRestrictions>\r\n";
            itemsWithCategoryName += "</CharTextWestern>\r\n";
            itemsWithCategoryName += "</CATEGORY>\r\n";

            for (int i = 1; i < itemsArray.Length; i++)
            {
                string[] itemsWithsplitRange = Regex.Split(AddDefaultMinMax(itemsArray[i]), " ", RegexOptions.IgnoreCase);
                string itemName = itemsWithsplitRange[0];
                string min = "";
                string max = "";
                if (itemsWithsplitRange[1] == "" | itemsWithsplitRange[1] == null)
                    min = "0";
                else
                    min = itemsWithsplitRange[1];
                if (itemsWithsplitRange[2] == "" | itemsWithsplitRange[2] == null)
                    max = "S";
                else
                    max = itemsWithsplitRange[2];
                itemsWithCategoryName += "<ITEM SimpleTypeName=\""+itemName+"\" CategoryOrItemParent=\""+RemoveFirstUnderLine(itemsArray[0])+" Item Root\" partition=\"NO\" OrderSubtypes=\"ASCENDING\"><CharTextWestern><Size Min=\""+min+"\" Max=\""+max+ "\"/>\r\n";
                itemsWithCategoryName += "<CharSize Min=\""+min+"\" Max=\""+max+ "\"/>\r\n";
                itemsWithCategoryName += "<Western CharSet=\"NATIVE\"/>\r\n";
                itemsWithCategoryName += "<ValueRestrictions IgnoreCase=\"NO\" Rule=\"INCLUDE\"></ValueRestrictions>\r\n";
                itemsWithCategoryName += "</CharTextWestern>\r\n";
                itemsWithCategoryName += "</ITEM>";
                if (i < itemsArray.Length - 1)
                    itemsWithCategoryName += "\r\n";
            }


             return itemsWithCategoryName;
         }
        public static string RemoveFirstUnderLine(string groupName)
        {
            string groupNameWithoutUnderLine = "";
            if (groupName.Substring(0, 1) == "_")
                groupNameWithoutUnderLine = groupName.Substring(1, groupName.Length - 1);
            else
                groupNameWithoutUnderLine = groupName;
            return groupNameWithoutUnderLine;
        }
    }
   
}
