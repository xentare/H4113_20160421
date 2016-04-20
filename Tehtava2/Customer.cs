using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Tehtava2
{
    [Serializable]
    [XmlType("Asiakas")]
   // [XmlRoot("Asiakas")]
    public class Customer
    {
        //Nimi;Yhteyshenkilö;Katuosoite;Postinumero;Postitoimipaikka;Myynti
        public string Nimi { get; set; }
        public string Yhteyshenkilö { get; set; }
        public string Katuosoite { get; set; }
        public string Postinumero { get; set; }
        public string Postitoimipaikka { get; set; }
        public string Myynti { get; set; }
        [XmlIgnore]
        public bool XMLTiedostoon { get; set; }
    }

    [Serializable]
    [XmlRoot("Asiakkaat")]
    public class CustomerList 
    {
        [XmlElement("Asiakas")]
        public List<Customer> Customers { get; set; }

        public List<Customer> ReadFile(string filepath)
        {
            var lines = File.ReadAllLines(filepath);

            var data = from l in lines.Skip(1)
                       let split = l.Split(';')
                       select new Customer
                       {
                           Nimi = split[0],
                           Yhteyshenkilö = split[1],
                           Katuosoite = split[2],
                           Postinumero = split[3],
                           Postitoimipaikka = split[4],
                           Myynti = split[5],
                           XMLTiedostoon = false
                       };
            Customers = data.ToList();
            return Customers;
        }

    }

}
