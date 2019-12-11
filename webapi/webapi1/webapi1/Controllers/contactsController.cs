using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi1.Models;

namespace webapi1.Controllers
{
    public class contactsController : ApiController
    {

        contacts[] _Contacts = new contacts[]
        {
            new contacts() { ID = 0, FirstName = "Peter", LastName = "Parker"},
            new contacts() { ID=1, FirstName = "Bruce", LastName = "Wane"},
            new contacts() { ID=2, FirstName="John", LastName = "Stewart"}
        };

        [Route("api/contacts/{name}")]
        public IEnumerable<contacts> GetContactByName(string name)
        {
            contacts[] contactArray = _Contacts.Where<contacts>(c => c.FirstName.Contains(name)).ToArray<contacts>();
            return contactArray;
        }

        // GET: api/contacts
        [Route("api/contacts/")]
        public IEnumerable<contacts> Get()
        {
            return _Contacts;
        }
        //api 2 attribute routing
        // GET: api/contacts/5
        [Route("api/contacts/{id:int:min(0)}")]
        public IHttpActionResult Get(int id)
        {
            contacts _SingleContact = _Contacts.FirstOrDefault<contacts>(c => c.ID == id);

            if(_SingleContact == null)
            {
                return NotFound();
            }

            return Ok(_SingleContact);
        }

        // POST: api/contacts
        public IEnumerable<contacts> Post([FromBody]contacts _newContact)
        {
            List<contacts> _contactList = _Contacts.ToList<contacts>();

            _newContact.ID = _contactList.Count;
            _contactList.Add(_newContact);
            _Contacts = _contactList.ToArray();
            return _Contacts;
        }

        // PUT: api/contacts/5
        public IEnumerable<contacts> Put(int id, [FromBody]contacts _changedContact)
        {
            contacts _SingleContact = _Contacts.FirstOrDefault<contacts>(c => c.ID == id);
            if(_SingleContact != null)
            {
                _SingleContact.FirstName = _changedContact.FirstName;
                _SingleContact.LastName = _changedContact.LastName;
            }


            return _Contacts;
        }

        // DELETE: api/contacts/5
        public IEnumerable<contacts> Delete(int id)
        {
            _Contacts = _Contacts.Where<contacts>(c => c.ID != id).ToArray<contacts>();
            return _Contacts;
        }
    }
}
