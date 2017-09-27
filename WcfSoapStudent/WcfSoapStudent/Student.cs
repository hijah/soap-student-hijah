using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfSoapStudent
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Navn { get; set; }
        [DataMember]
        public string Efternavn { get; set; }
        [DataMember]
        public string Klasse { get; set; }
        [DataMember]
        public int ID { get; set; }

        
        public Student(string navn, string efternavn, string klasse, int id)
        {
            Navn = navn;
            Efternavn = efternavn;
            Klasse = klasse;
            ID = id;
        }

        public Student()
        {
            
        }
        
        
        public override string ToString()
        {
            return $"Navn: {Navn}, Efternavn: {Efternavn}, Klasse: {Klasse}";
        }
    }
}