using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pecunia.Entities
{
    [Serializable]
    public enum TypeOfTranscation
    {
        Credit,
        Debit
    }
    public class TransactionEntities
    {
        public long AccountNo { get; set; }
        public string CustomerID { get; set; }
        public TypeOfTranscation Type { get; set; }
        public double Amount { get; set; }
        public string TransactionID { get; set; }
        public DateTime DateOfTransaction { get; set; }
        public string Mode { get; set; }
        public string ChequeNo { get; set; }
    }
}
