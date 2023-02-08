using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using Otus.Teaching.Concurrency.Import.DataGenerator.Dto;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Parsers
{
    /// <summary>
    /// Парсер xml-файла
    /// </summary>
    public class XmlParser : IDataParser<List<ThreadCustomer>>
    {
        public List<ThreadCustomer> Parse(string file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomersList));
            List<ThreadCustomer> customerList;
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                customerList = (xmlSerializer.Deserialize(fs) as CustomersList).Customers;
            }
            
            return customerList;
        }
    }
}