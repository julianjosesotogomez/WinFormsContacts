using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsContacts.Class;
using WinFormsContacts.Models;

namespace WinFormsContacts
{
    public partial class ContactDetails : Form
    {
        public BussinessLogicLayer _bussinessLogicLayer;

        public ContactDetails()
        {
            InitializeComponent();
            _bussinessLogicLayer = new BussinessLogicLayer();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveContact();
        }

        private void SaveContact()
        {
            ContactModel contactModel = new ContactModel();
            contactModel.FirstName = txtFirstName.Text;
            contactModel.LastName = txtLastName.Text;
            contactModel.Phone = txtPhone.Text;
            contactModel.Address = txtAddress.Text;

            _bussinessLogicLayer.SaveContact(contactModel);

        }
    }
}
