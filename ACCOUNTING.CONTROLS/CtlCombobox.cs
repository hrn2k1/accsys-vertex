using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Accounting.Controls
{
    public partial class CtlCombobox : ComboBox
    {
        public CtlCombobox()
        {
            InitializeComponent();
            this.DataSourceChanged += new EventHandler(CtlCombobox_DataSourceChanged);
            this.Leave += new EventHandler(CtlCombobox_Leave);
        }

        void CtlCombobox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedValue == null)
                {
                    // this.SelectedIndex = 0;
                    int i = this.FindString(this.Text);
                    this.SelectedIndex = i;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        void CtlCombobox_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection strColl = new AutoCompleteStringCollection();
                if (this.DataSource.GetType() == typeof(DataTable))
                {
                    DataTable dt = (DataTable)this.DataSource;
                    foreach (DataRow r in dt.Rows)
                    {
                        strColl.Add(r.Field<string>(this.DisplayMember));
                    }
                    this.AutoCompleteCustomSource = strColl;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
