using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD_cw2
{
    [XmlRoot("Student")]
    class Student
    {
        [XmlElement(elementName: "fname")]
        public string fname { get; set; }
        [XmlElement(elementName: "lname")]
        public string lname { get; set; }
        
        [XmlElement(elementName: "name")]
        public string studiesName { get; set; }
        [XmlElement(elementName: "mode")]
        public string studiesMode { get; set; }
        [XmlElement(elementName: "indexNumber")]
        public int indexNumber { get; set; }
        [XmlElement(elementName: "birthdate")]
        public string birthdate { get; set; }
        [XmlElement(elementName: "email")]
        public string email { get; set; }
        [XmlElement(elementName: "motherName")]
        public string mothersName { get; set; }
        [XmlElement(elementName: "fatherName")]
        public string fathersName { get; set; }
    }
}
