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
    public partial class Main : Form
    {
        private BussinessLogicLayer _bussinessLogicaLayer;
        public Main()
        {
            InitializeComponent();
            _bussinessLogicaLayer = new BussinessLogicLayer();
        }

        #region EVENTS
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenContactDetailsDialog();
        }
        #endregion

        #region PRIVATE METHODS
        private void OpenContactDetailsDialog()
        {
            ContactDetails contactDetails = new ContactDetails();
            contactDetails.ShowDialog();
        }
        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateContacts();
        }

        private void PopulateContacts()
        {
            List<ContactModel> contactModels = _bussinessLogicaLayer
        }
    }
}
