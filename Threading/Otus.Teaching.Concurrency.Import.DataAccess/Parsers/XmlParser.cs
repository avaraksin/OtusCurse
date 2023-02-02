﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Otus.Teaching.Concurrency.Import.Core.Parsers;
using Otus.Teaching.Concurrency.Import.DataGenerator.Dto;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataAccess.Parsers
{
    public class XmlParser
        : IDataParser<List<Customer>>
    {
        public List<Customer> Parse(string file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomersList));
            List<Customer> customerList;
            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                customerList = (xmlSerializer.Deserialize(fs) as CustomersList).Customers;
            }

            return customerList;
        }
    }
}