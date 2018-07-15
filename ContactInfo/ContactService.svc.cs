using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ContactInfo
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ContactService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ContactService.svc or ContactService.svc.cs at the Solution Explorer and start debugging.
    public class ContactService : IContactService
    {
        private List<Contact> _store;
        internal List<Contact> Store
        {
            get
            {
                this._store = this._store ?? new List<Contact>();
                return this._store;
            }
        }

        #region ContactInfo Members


        public bool AddContact(Contact currentContact)
        {
            try
            {
                if (this.Store.Any(item => item.Id == currentContact.Id))
                    return false;
                this.Store.Add(currentContact);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public Contact GetContact(string id)
        {
            try
            { 
                return this.Store.FirstOrDefault(item => item.Id.ToString().Equals(id));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public bool UpdateContact(Contact currentContact)
        {

            try
            { 
                if (!this.Store.Any(item => item.Id == currentContact.Id))
                {
                    var oldContact = this.Store.FirstOrDefault(item => item.Id.ToString().Equals(currentContact.Id));
                    this.Store.Remove(oldContact);
                    this.Store.Add(currentContact);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public bool RemoveContact(string id)
        {
            try { 
                var currentContacts = this.Store.Where(item => item.Id.ToString().Equals(id));

                if (currentContacts.Count() <= 0)
                    return false;

                foreach (Contact currentContact in currentContacts)
                    this.Store.Remove(currentContact);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public List<Contact> GetAllContacts()
        {
            try
            {
                return this.Store;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        #endregion
    }
}
