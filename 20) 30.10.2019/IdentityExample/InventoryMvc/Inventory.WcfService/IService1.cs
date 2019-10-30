using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Inventory.WcfService
{
    [ServiceContract]
    public interface IPersonsService
    {
        [OperationContract]
        List<PersonDataContract> GetPersons();
    }

    
    [DataContract]
    public class PersonDataContract
    {
        [DataMember]
        public System.Guid PersonID { get; set; }

        [DataMember]
        public string PersonName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public Nullable<int> Age { get; set; }

        [DataMember]
        public Nullable<System.DateTime> DateOfJoining { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public Nullable<bool> IsRegistered { get; set; }

        [DataMember]
        public string State { get; set; }
    }
}
