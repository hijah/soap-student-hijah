using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfSoapStudent
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static List<Student> Studentlist = new List<Student>(); 
        public string AddStudent(string navn, string efternavn, string klasse, int id)
        {
            var student = new Student(navn, efternavn, klasse, id);

            Studentlist.Add(student);
            
            return student.ToString();
            
        }

        public Student FindStudent(int id)
        {
            var selected = Studentlist.FirstOrDefault(find => find.ID == id);
            return selected;
        }

        public string RemoveStudent(int id)
        {
            var selected = Studentlist.FirstOrDefault(find => find.ID == id);
            Studentlist.Remove(selected);
            return "succesfull Removal";
        }

        public string EditStudent(string navn, string efternavn, string klasse, int id)
        {
            var selected = Studentlist.FirstOrDefault(find => find.ID == id);
            Studentlist.Remove(selected);

            var student = new Student(navn, efternavn, klasse, id);

            Studentlist.Add(student);

            return student.ToString();

        }

        /// <summary>
        /// Virker ikke helt. (returnere ikke alt)
        /// </summary>
        /// <returns></returns>
        public List<Student> GetAllStudent()
        {
            return Studentlist;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)  
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

    }
}
