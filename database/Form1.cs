using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            PERSON newPerson = new PERSON();
            newPerson.name = "Henry";
            newPerson.date = DateTime.Parse("07.07.2002");

            DatabaseDataContext dt = new DatabaseDataContext();
            dt.PERSONs.InsertOnSubmit(newPerson);
            dt.SubmitChanges();

            foreach (PERSON p in dt.PERSONs)
            {
                MessageBox.Show(p.name);
            }
        }
    }
}
