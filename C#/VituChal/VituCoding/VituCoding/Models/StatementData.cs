using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace VituCoding.Models


{
    public class Statement
    {
        //[Name("Details")]
        public string Details { get; set; }

        //[Name("Posting Date")]
        public DateTime PostingDate { get; set; }

        //[Name("Description")]
        public string Description { get; set; }

        //[Name("Amount")]
        public string Amount { get; set; }

        //[DataMember(IsRequired = false)]
        public bool isBill { get; set; }
    }

    public class HasIngoredPropertyMap : ClassMap<Statement>
    {
        public HasIngoredPropertyMap()
        {
            AutoMap();
            Map(m => m.PostingDate).Name("Posting Date");
            Map(m => m.isBill).Ignore();

        }
    }

    public class Transactions
    {
        public List<Statement> Statements { get; set; }
    }

}
