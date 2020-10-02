using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Accounting.Utility;
using Accounting.DataAccess;
using System.Collections;
namespace Accounting.UI
{
    public partial class frmItemSearch : Form
    {
        public frmItemSearch()
        {
            InitializeComponent();
        }
        SqlConnection formCon = null;
        DataTable dtItems = null;
        CurrencyManager cmItem = null;
      public  string ItemList = string.Empty;

        private void frmItemSearch_Load(object sender, EventArgs e)
        {
           formCon= ConnectionHelper.getConnection();

           cboGroup.DataSource = new DAChartsOfItem().LoadGroupInDGV(formCon);
           cboGroup.DisplayMember = "GroupName";
           cboGroup.ValueMember = "ItemGroupID";

           loadItems();
        }

        private void chkGroup_CheckedChanged(object sender, EventArgs e)
        {
            cboGroup.Enabled = chkGroup.Checked;

        }

        private void loadItems()
        {
            try
            {
                int grpID = chkGroup.Checked ? (int)cboGroup.SelectedValue : 0;
                string ItemName = chkName.Checked ? txtItemName.Text.Trim() : "";
                string cols = "ItemID,ItemName,ItemCode,SizesName AS Size,ColorsName AS Color,ShadeNo AS Shade ,CountName AS Count,UnitsName AS Unit,ItemDescription AS Items,GroupName ,CurrentQty";
                dtItems = new DAChartsOfItem().GetItems(grpID, ItemName, cols, formCon);
                cmItem = (CurrencyManager)this.BindingContext[dtItems];
                ctldgvItems.DataSource = dtItems;
                ctldgvItems.setColumnsVisible(false, "ItemID", "Items", "GroupName", "Size", "Color", "Shade", "Count");
                ctldgvItems.setColumnsReadOnly(true, "ItemName", "ItemCode", "Unit", "GroupName", "Items");
                ctldgvItems.ContextMenuFields = new string[] { "GroupName","Items" };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadItems();
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            txtItemName.Enabled = chkName.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ItemList = "(0";

                int i, nR;
                nR = ctldgvItems.Rows.Count;

                for (i = 0; i < nR; i++)
                {
                    if (ctldgvItems.Rows[i].Cells[0].Value == null) continue;
                    if (Convert.ToInt32( ctldgvItems.Rows[i].Cells[0].Value) == 1)
                    {
                        ItemList += ","+ ctldgvItems.Rows[i].Cells["ItemID"].Value.ToString();
                    }
                }
                ItemList += ")";
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int i, nR;
                nR = ctldgvItems.Rows.Count;
                for (i = 0; i < nR; i++)
                {
                    ctldgvItems.Rows[i].Cells[0].Value = chkAll.Checked ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOK_Click(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmItemSearch_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                FormColorClass.ColorForm(this, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
