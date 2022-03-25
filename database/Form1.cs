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
        DatabaseDataContext dt = new DatabaseDataContext();

        public Form1()
        {
            InitializeComponent();

            LoadToListBox();
        }


        private void LoadToListBox()
        {
           listBox.Items.Clear();
            foreach (PERSON p in dt.PERSONs)
            {
                listBox.Items.Add(p);
            }
        }


        private void buttonApply_Click(object sender, EventArgs e)
        {
            DateTime date;
            if(textBoxName.Text != "" && DateTime.TryParse(textBoxDate.Text, out date))
            {
                PERSON p = new PERSON();
                p.name = textBoxName.Text;
                p.date = date;

                dt.PERSONs.InsertOnSubmit(p);
                dt.SubmitChanges();

                LoadToListBox();

                textBoxName.Text = "";
                textBoxDate.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid date format.", "Date error");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count != 0)
            {
                var ps = new List<PERSON>();
                foreach (PERSON p in listBox.SelectedItems)
                {
                    ps.Add(p);
                }
                foreach (PERSON p in ps)
                {
                    dt.PERSONs.DeleteOnSubmit(p);
                }

                dt.SubmitChanges();
                LoadToListBox();
            }
        }
    }

    partial class PERSON
    {
        public override string ToString()
        {
            return name + ", birthday: " + date.ToShortDateString();
        }
    }
}
