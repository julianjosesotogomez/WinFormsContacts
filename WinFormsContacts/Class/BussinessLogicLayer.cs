using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsContacts.Models;

namespace WinFormsContacts.Class
{


    
    public class BussinessLogicLayer
    {
        private DataAccessLayer _dataAccessLayer;

        public BussinessLogicLayer()
        {
            _dataAccessLayer = new DataAccessLayer();
        }

        public ContactModel SaveContact(ContactModel contactModel)
        {
            if (contactModel.id == 0)
            {
                _dataAccessLayer.InsertContact(contactModel);
            }
            else
            {
                _dataAccessLayer.UpdateContact(contactModel);
            }

            return contactModel;
        }

        public List<ContactModel> GetContacts(string searchText =  null)
        {
           return _dataAccessLayer.GetContacts(searchText);
        }

        public void DeleContact(int id)
        {
            _dataAccessLayer.DeleteContact(id);
        }
    }
}
