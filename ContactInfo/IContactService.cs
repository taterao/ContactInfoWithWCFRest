using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ContactInfo
{
    [ServiceContract]
    public interface IContactService
    {

        [WebInvoke(Method = "PUT", UriTemplate = "contact")]
        [OperationContract]
        bool AddContact(Contact currentContact);

        [WebGet(UriTemplate = "contacts/{id}")]
        [OperationContract]
        Contact GetContact(string id);

        [WebInvoke(Method = "POST", UriTemplate = "contact")]
        [OperationContract]
        bool UpdateContact(Contact currentContact);

        [WebInvoke(Method = "DELETE", UriTemplate = "contact/{id}")]
        [OperationContract]
        bool RemoveContact(string id);

        [WebGet(UriTemplate = "contacts")]
        [OperationContract]
        List<Contact> GetAllContacts();
    }
}
