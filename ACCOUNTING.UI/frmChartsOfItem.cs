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
using Accounting.Entity;

namespace Accounting.UI
{
    public partial class frmChartsOfItem : Form
    {
        SqlConnection conn = null;
        ChartsOfItem objItem = new ChartsOfItem();
        public frmChartsOfItem()
        {
            InitializeComponent();
        }
        int H = 30;
       

       

        private void rdGroup_CheckedChanged(object sender, EventArgs e)
        {


            bool state = rdGroup.Checked;
            flpName.Visible = state;
            flpParentGroup.Visible = state;

            
                flpGroupCode.Visible = false;
                flpDepth.Visible = false;
                flpItemName.Visible = false;
                flpMinQty.Visible = false;
                flpItemGroup.Visible = false;
                flpUnit.Visible = false;
                flpCatagory.Visible = false;
                flpStatus.Visible = false;
                flpItemCode.Visible = false;
                flpOpenQty.Visible = false;
                flpHSCode.Visible = false;
                flpOpenValue.Visible = false;
                //flpShade.Visible = false;
                //flpSize.Visible = false;
                //flpCount.Visible = false;
                //flpColor.Visible = false;
                flpDescription.Visible = false;
                flpPurpose.Visible = false;
                flpUnitPrise.Visible = false;
                picItem.Visible = false;
                lblBrowsed.Visible = false;
                FLPCurrentItem.Visible = false;
                if (state == true)
                {
                    //dgvGroupOrItem.Height = dgvGroupOrItem.Height + 304;
                    LoadGroupDGV();
                }
                else
                {
                   // dgvGroupOrItem.Height = dgvGroupOrItem.Height - 285;
                }
                dgvGroupOrItem.Height = flpMain.Bottom - dgvGroupOrItem.Top - H; 

            
        }

        private void rdItem_Click(object sender, EventArgs e)
        {
            if (rdItem.Checked)
                flpName.Visible = false;
            flpParentGroup.Visible = false;
            flpGroupCode.Visible = true;
            flpDepth.Visible = true;
            flpItemName.Visible = true;
            flpMinQty.Visible = true;
            flpItemGroup.Visible = true;
            flpUnit.Visible = true;
            flpCatagory.Visible = true;
            flpStatus.Visible = true;
            flpItemCode.Visible = true;
            flpOpenQty.Visible = true;
            flpHSCode.Visible = true;
            flpOpenValue.Visible = true;
            //flpShade.Visible = true;
            //flpSize.Visible = true;
            //flpCount.Visible = true;
            //flpColor.Visible = true;
            flpDescription.Visible = true;
            flpPurpose.Visible = true;
            flpUnitPrise.Visible = true;
            lblBrowsed.Visible = true;
            picItem.Visible = true;
            FLPCurrentItem.Visible = true;
            //dgvGroupOrItem.Height = dgvGroupOrItem.Height + 6;
            //LoadItemDGV();
            btnSearch_Click(sender, null);
            dgvGroupOrItem.Height = flpMain.Bottom - dgvGroupOrItem.Top - H; 
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChartsOfItem_Load(object sender, EventArgs e)
        {
           
                conn = ConnectionHelper.getConnection();
                //lblStar.Visible = false;
                LoadItemGroup();
                LoadUnit();
                LoadSizes();
                LoadColor();
                LoadCount();
                LoadShades();
                LoadSearchByGroup();
                TreeLoad();
                txtGroupName.Focus();
                cmbCatagory.SelectedIndex = 0;
                cmbStatus.SelectedIndex = 0;
                txtGroupName.Focus();
            

                bool state = rdGroup.Checked;
                flpName.Visible = state;
                flpParentGroup.Visible = state;


                flpGroupCode.Visible = false;
                flpDepth.Visible = false;
                flpItemName.Visible = false;
                flpMinQty.Visible = false;
                flpItemGroup.Visible = false;
                flpUnit.Visible = false;
                flpCatagory.Visible = false;
                flpStatus.Visible = false;
                flpItemCode.Visible = false;
                flpOpenQty.Visible = false;
                flpHSCode.Visible = false;
                flpOpenValue.Visible = false;
                //flpShade.Visible = false;
                //flpSize.Visible = false;
                //flpCount.Visible = false;
                //flpColor.Visible = false;
                flpDescription.Visible = false;
                flpPurpose.Visible = false;
                flpUnitPrise.Visible = false;
                lblBrowsed.Visible = false;
                picItem.Visible = false;
                FLPCurrentItem.Visible = false;
                if (state == true)
                {
                    // dgvGroupOrItem.Height = dgvGroupOrItem.Height + 304;
                    LoadGroupDGV();

                    //LoadItemDGV();
                }
                else
                {
                    // dgvGroupOrItem.Height = dgvGroupOrItem.Height - 304;
                    LoadItemDGV();
                }
                dgvGroupOrItem.Height = flpMain.Bottom - dgvGroupOrItem.Top - H;
            }
        
        
        public void LoadItemGroup()
        {
            try
            {
                DAChartsOfItem daobj = new DAChartsOfItem();
                DataTable dt = daobj.LoadItemGroup(conn);
                dt.Rows.Add(new object[] {0,"Primary Group" });
                cmbGroup.DataSource =dt;
                cmbItemGroup.DataSource = daobj.LoadItemGroup(conn);
                cmbGroup.DisplayMember = "GroupName";
                cmbGroup.ValueMember = "ItemGroupID";
                cmbItemGroup.DisplayMember = "GroupName";
                cmbItemGroup.ValueMember = "ItemGroupID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadSizes()
        {
            try
            {
                DAChartsOfItem daobj = new DAChartsOfItem();
                DataTable dt = new DataTable();
                dt = daobj.LoadSize(conn);
                dt.Rows.Add(new object[] { 0, "N/A" });
                cmbSize.DataSource = dt;
                cmbSize.DisplayMember = "SizesName";
                cmbSize.ValueMember = "SizesID";
                cmbSize.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        public void LoadUnit()
        {
            try
            {
                DAChartsOfItem daobj = new DAChartsOfItem();
                cmbUnit.DataSource = daobj.LoadUnits(conn);
                cmbUnit.DisplayMember = "UnitsName";
                cmbUnit.ValueMember = "UnitsID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }



        public void LoadColor()
        {
            try
            {
                DAChartsOfItem daobj = new DAChartsOfItem();
                DataTable dt = new DataTable();
                dt = daobj.LoadColors(conn);
                dt.Rows.Add(new object[] { 0, "N/A" });
                cmbColor.DataSource = dt;
                cmbColor.DisplayMember = "ColorsName";
                cmbColor.ValueMember = "ColorsID";
                cmbColor.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }


        public void LoadCount()
        {
            try
            {
                DAChartsOfItem daobj = new DAChartsOfItem();
                DataTable dt = new DataTable();
                dt = daobj.LoadCounts(conn);
                dt.Rows.Add(new object[] { 0, "N/A" });
                cmbCount.DataSource = dt; 
                cmbCount.DisplayMember = "CountName";
                cmbCount.ValueMember = "CountID";
                cmbCount.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }



        public void LoadShades()
        {
            try
            {
                DAChartsOfItem daobj = new DAChartsOfItem();
                DataTable dt = new DataTable();
                dt = daobj.LoadShade(conn);
                dt.Rows.Add(new object[] { 0, "N/A" });
                cmbShade.DataSource = dt;
                cmbShade.DisplayMember = "ShadeNo";
                cmbShade.ValueMember = "ShadeID";
                cmbShade.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }



        public void LoadGroupDGV()
        {
            try
            {
                DAChartsOfItem daobj = new DAChartsOfItem();
                dgvGroupOrItem.Columns.Clear();
                dgvGroupOrItem.DataSource = daobj.LoadGroupInDGV(conn);
                dgvGroupOrItem.Columns["ItemGroupID"].Visible = false;
                dgvGroupOrItem.Columns["GroupCode"].Visible = false;
                dgvGroupOrItem.Columns["GroupDepth"].Visible = false;
                dgvGroupOrItem.Columns["ParentGroupID"].Visible = false;
                dgvGroupOrItem.Columns["CompanyID"].Visible = false;
                dgvGroupOrItem.Columns["UserID"].Visible = false;


                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }


        public void LoadItemDGV()
        {
            try
            {
                DAChartsOfItem daobj = new DAChartsOfItem();
                dgvGroupOrItem.DataSource = daobj.LoadItemInDGV(conn);
                //dgvGroupOrItem.Columns["ItemID"].Visible = false;
                dgvGroupOrItem.Columns["ItemDescription"].Visible = false;
                dgvGroupOrItem.Columns["ItemGroupID"].Visible = false;
                //dgvGroupOrItem.Columns["Picture"].Visible = false;
                //dgvGroupOrItem.Columns["ItemID"].Visible = false;
                //dgvGroupOrItem.Columns["ItemID"].Visible = false;
                //dgvGroupOrItem.Columns["ItemID"].Visible = false;
                dgvGroupOrItem.Columns["CountID"].Visible = false;
                dgvGroupOrItem.Columns["ParentGroupID"].Visible = false;
                dgvGroupOrItem.Columns["ShadeID"].Visible = false;
                dgvGroupOrItem.Columns["ColorID"].Visible = false;
                dgvGroupOrItem.Columns["UnitID"].Visible = false;




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        public ItemGroup CreateGroup(ItemGroup objItemGroup)
        {
            //ItemGroup objItemGroup = new ItemGroup();
            objItemGroup.ItemGroupID =int.Parse( txtGroupID.Text);
            objItemGroup.GroupName = txtGroupName.Text;
            objItemGroup.ParentGroupID = (int)cmbGroup.SelectedValue;
            objItemGroup.GroupCode = txtGroupCode.Text;
            objItemGroup.GroupDepth=int.Parse(txtDepth.Text);
            return objItemGroup;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdGroup.Checked == true)
                {

                    if (txtGroupName.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Select An Item");
                        return;
                    }
                    ItemGroup groupobj = new ItemGroup();
                    DAChartsOfItem groupDA = new DAChartsOfItem();
                    CreateGroup(groupobj);
                    groupDA.SaveOrUpdateItemGroup(groupobj, conn);
                    MessageBox.Show("Data Saved successfully");
                    RefreshGroup();
                    LoadGroupDGV();
                    LoadSearchByGroup();

                }


                else
                {
                    ChartsOfItem objItem = new ChartsOfItem();
                    DAChartsOfItem ItemDA = new DAChartsOfItem();
                    CreateObjectItem(objItem);
                    if (txtItemName.Text.Trim() == "")
                    {
                        MessageBox.Show("Select a valid item", "MessageCounter");
                        label5.ForeColor = Color.Red;
                        return;
                    }
                    //if (txtItemCode.Text.Trim() == "")
                    //{
                    //    MessageBox.Show("Select a valid item code", "MessageCounter");
                    //    label6.ForeColor = Color.Red;
                    //    return;
                    //}
                    //if (txtHSCode.Text.Trim() == "")
                    //{
                    //    MessageBox.Show("Select a valid item's H.S.Code", "MessageCounter");
                    //    label7.ForeColor = Color.Red;
                    //    return;
                    //}
                    ItemDA.SaveOrUpdateItem(objItem, conn);
                    MessageBox.Show("Save the item successfully");
                    RefreshItem();
                   // LoadItemDGV();
                    btnSearch_Click(sender, null);

                }
                LoadItemGroup();
                LoadUnit();
                LoadSizes();
                LoadColor();
                LoadCount();
                LoadShades();
                TreeLoad();
                cmbStatus.SelectedIndex = 0;
                cmbCatagory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void dgvGroupOrItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int ab = e.RowIndex;
                if (rdGroup.Checked == true)
                {
                    txtGroupID.Text = dgvGroupOrItem.Rows[ab].Cells["ItemGroupID"].Value.ToString();
                    txtGroupName.Text = dgvGroupOrItem.Rows[ab].Cells["GroupName"].Value.ToString();
                    cmbGroup.SelectedValue = dgvGroupOrItem.Rows[ab].Cells["ParentGroupID"].Value.ToString();
                    txtGroupCode.Text = dgvGroupOrItem.Rows[ab].Cells["GroupCode"].Value.ToString();
                    txtDepth.Text = dgvGroupOrItem.Rows[ab].Cells["GroupDepth"].Value.ToString();
                }
                else
                {
                    //int ItemID = 0;
                    txtItemID.Text = dgvGroupOrItem.Rows[ab].Cells["ItemID"].Value.ToString();
                    txtItemName.Text = dgvGroupOrItem.Rows[ab].Cells["ItemName"].Value.ToString();
                    cmbItemGroup.SelectedValue = dgvGroupOrItem.Rows[ab].Cells["ItemGroupID"].Value.ToString();
                    cmbCatagory.Text = dgvGroupOrItem.Rows[ab].Cells["ItemCategory"].Value.ToString();
                    txtItemCode.Text = dgvGroupOrItem.Rows[ab].Cells["ItemCode"].Value.ToString();
                    txtHSCode.Text = dgvGroupOrItem.Rows[ab].Cells["HSCode"].Value.ToString();
                    txtItemDes.Text = dgvGroupOrItem.Rows[ab].Cells["ItemDescription"].Value.ToString();
                    txtPurpose.Text = dgvGroupOrItem.Rows[ab].Cells["ItemPurpose"].Value.ToString();

                    cmbSize.SelectedValue = dgvGroupOrItem.Rows[ab].Cells["SizeID"].Value == DBNull.Value || dgvGroupOrItem.Rows[ab].Cells["SizeID"].Value == null ?" 0 ": dgvGroupOrItem.Rows[ab].Cells["SizeID"].Value.ToString();
                    cmbColor.SelectedValue = dgvGroupOrItem.Rows[ab].Cells["ColorID"].Value == DBNull.Value || dgvGroupOrItem.Rows[ab].Cells["ColorID"].Value == null ? "0" : dgvGroupOrItem.Rows[ab].Cells["ColorID"].Value.ToString();
                    cmbShade.SelectedValue = dgvGroupOrItem.Rows[ab].Cells["ShadeID"].Value == DBNull.Value || dgvGroupOrItem.Rows[ab].Cells["ShadeID"].Value == null ? "0" : dgvGroupOrItem.Rows[ab].Cells["ShadeID"].Value.ToString();
                    cmbCount.SelectedValue = dgvGroupOrItem.Rows[ab].Cells["CountID"].Value == DBNull.Value ? "0" : dgvGroupOrItem.Rows[ab].Cells["CountID"].Value.ToString();
                    cmbUnit.SelectedValue = dgvGroupOrItem.Rows[ab].Cells["UnitID"].Value.ToString();
                    txtOpeningQty.Text = dgvGroupOrItem.Rows[ab].Cells["OpeningQty"].Value.ToString();
                    txtOpeningValue.Text = dgvGroupOrItem.Rows[ab].Cells["OpeningValue"].Value.ToString();
                    cmbStatus.Text = dgvGroupOrItem.Rows[ab].Cells["ItemStatus"].Value.ToString();
                    txtMinQty.Text = dgvGroupOrItem.Rows[ab].Cells["MinQty"].Value.ToString();
                    txtUnitPrice.Text = dgvGroupOrItem.Rows[ab].Cells["UnitPrice"].Value.ToString();

                    picItem.BackgroundImage = GlobalFunctions.toImage(new DAChartsOfItem().GetImage(conn, int.Parse(txtItemID.Text)));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
  

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGroupOrItem.CurrentRow == null)
                {
                    MessageBox.Show("No row is selected");
                    return;
                }
                if (MessageBox.Show("Are you sure you want to delete it", "MessageCounter", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                int ad = dgvGroupOrItem.CurrentRow.Index;
                if (rdGroup.Checked == true)
                {
                    int adc = (int)dgvGroupOrItem.Rows[ad].Cells["ItemGroupID"].Value;
                    DAChartsOfItem objgroup = new DAChartsOfItem();
                    objgroup.DeleteGroup(adc, conn);
                    LoadGroupDGV();
                }
                else
                {
                    int ac = (int)dgvGroupOrItem.Rows[ad].Cells["ItemID"].Value;
                    DAChartsOfItem objDa = new DAChartsOfItem();
                    objDa.DeleteItem(ac, conn);
                    LoadItemDGV();

                }

                LoadItemGroup();
                LoadUnit();
                LoadSizes();
                LoadColor();
                LoadCount();
                LoadShades();
                TreeLoad();
                MessageBox.Show("Data is deleted successfully");
                btnNew_Click(sender,null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        

        private void lblBrowsed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string strFileName = "";
                OpenFileDialog objOpenFile = new OpenFileDialog();
                objOpenFile.Filter = "jpeg Files|*.jpeg;*.jpg";
                if (objOpenFile.ShowDialog() == DialogResult.OK)
                {
                    strFileName = objOpenFile.FileName;
                    picItem.BackgroundImage = Image.FromFile(strFileName);
                }
            }
                catch( Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        public ChartsOfItem CreateObjectItem(ChartsOfItem objItem)
        {
            try
            {
                objItem.ItemID = int.Parse(txtItemID.Text);
                objItem.ItemName = txtItemName.Text;
                objItem.ItemPurpose = txtPurpose.Text;
                objItem.ItemCode = txtItemCode.Text;
                objItem.HSCode = txtHSCode.Text;
                objItem.GroupID = (int)cmbItemGroup.SelectedValue;
                objItem.UnitID = (int)cmbUnit.SelectedValue;
                objItem.ItemCatagory = cmbCatagory.Text;
                objItem.ItemStatus = cmbStatus.Text;
                if (txtOpeningQty.Text == "")
                {
                    objItem.OpeningQty = 0;
                }
                else
                {
                    objItem.OpeningQty = int.Parse(txtOpeningQty.Text);
                }
                if (txtUnitPrice.Text == "")
                {
                    objItem.UnitPrice = 0;
                }
                else
                {
                    objItem.UnitPrice = double.Parse(txtUnitPrice.Text);
                }
                if (txtOpeningValue.Text == "")
                {
                    objItem.OpeningValue = 0;
                }
                else
                {
                    objItem.OpeningValue = double.Parse(txtOpeningValue.Text);
                }

                objItem.SizeID = (int)cmbSize.SelectedValue;
                objItem.ShadeID = (int)cmbShade.SelectedValue;
                objItem.CountID = (int)cmbCount.SelectedValue;
                objItem.ColorID = (int)cmbColor.SelectedValue;
                objItem.ItemDescription = txtItemDes.Text;

                if (txtMinQty.Text == "")
                {
                    objItem.MinQty = 0;
                }
                else
                {
                    objItem.MinQty = int.Parse(txtMinQty.Text);

                }

                if (picItem.BackgroundImage != null)
                {
                    objItem.Picture = GlobalFunctions.toBinary(picItem.BackgroundImage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objItem;

        }

        private void txtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void cmbGroup_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

       
        

        

        private void txtGroupName_Enter_1(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtGroupName_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
           
        }

        private void rdGroup_Enter(object sender, EventArgs e)
        {
            Control cn = (Control)sender;
            cn.ForeColor = Color.Red;
        }

        private void rdGroup_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
        }
        public void LoadSearchByGroup()
        {
            try
            {
                DAChartsOfItem daobj = new DAChartsOfItem();
                DataTable dt = daobj.LoadItemGroup(conn);
                dt.Rows.Add(new object[] { 0, "Primary Group" });
                cmbSearchBy.DataSource = dt;
                //cmbItemGroup.DataSource = daobj.LoadItemGroup(conn);
                cmbSearchBy.DisplayMember = "GroupName";
                cmbSearchBy.ValueMember = "ItemGroupID";
                //cmbItemGroup.DisplayMember = "GroupName";
                //cmbItemGroup.ValueMember = "ItemGroupID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int ss=(int)cmbSearchBy.SelectedValue;
            DAChartsOfItem DASearobj = new DAChartsOfItem();
            if (dgvGroupOrItem.Columns.Count > 0) dgvGroupOrItem.Columns.Clear();
            dgvGroupOrItem.DataSource = DASearobj.SearchByGroup(ss, conn);
            dgvGroupOrItem.Columns["ItemID"].Visible = false;
            dgvGroupOrItem.Columns["ItemGroupID"].Visible = false;
            dgvGroupOrItem.Columns["SizeID"].Visible = false;
            dgvGroupOrItem.Columns["ColorID"].Visible = false;
            dgvGroupOrItem.Columns["ShadeID"].Visible = false;
            dgvGroupOrItem.Columns["CountID"].Visible = false;
            dgvGroupOrItem.Columns["UnitID"].Visible = false;
            dgvGroupOrItem.Columns["ItemCategory"].Visible = false;
            dgvGroupOrItem.Columns["ItemCode"].Visible = false;
            dgvGroupOrItem.Columns["HSCode"].Visible = false;
            dgvGroupOrItem.Columns["ItemStatus"].Visible = false;
            dgvGroupOrItem.Columns["ItemPurpose"].Visible = false;
            dgvGroupOrItem.Columns["MinQty"].Visible = false;
            dgvGroupOrItem.Columns["OpeningQty"].Visible = false;
            dgvGroupOrItem.Columns["UnitPrice"].Visible = false;
            dgvGroupOrItem.Columns["OpeningValue"].Visible = false;
           
        }
        private void RefreshGroup()
        {
            txtGroupID.Text = "0";
            txtGroupName.Text = "";
            LoadItemGroup();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (rdGroup.Checked == true)
                RefreshGroup();
            else
                RefreshItem();
        }

        private void RefreshItem()
        {
            txtItemID.Text = "0";
            txtItemName.Text = "";
            txtItemCode.Text = "";
            txtUnitPrice.Text = "";
            txtMinQty.Text = "";
            txtItemDes.Text = "";
            txtHSCode.Text = "";
            txtOpeningQty.Text = "";
            txtOpeningValue.Text = "";
            txtPurpose.Text = "";
            txtCurrentItem.Text = "";
            picItem.BackgroundImage = null;
            LoadItemGroup();
            LoadUnit();
            LoadSizes();
            LoadColor();
            LoadCount();
            LoadShades();
        }

        private void TreeLoad()
        {
            try
            {
                tvItems.Nodes.Clear();
                DataTable dt = new DataTable();
                dt = new DAChartsOfItem().GetPrimeryGroup(conn);
                int RC = dt.Rows.Count;
                if (RC == 0) return;

                foreach (DataRow dr in dt.Rows)
                {
                    TreeNode tn = tvItems.Nodes.Add(dr.Field<int>("ItemGroupID").ToString(), dr.Field<string>("GroupName"));
                }

                foreach (TreeNode node in tvItems.Nodes)
                {
                    if (node == null) return;
                    addItem(node);
                    addChild(node);
                }
                //foreach (TreeNode node in tvItems.Nodes)
                //{
                //    if (node == null) return;
                //    addItem(node);
                //}

                tvItems.ExpandAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void addChild(TreeNode n)
        {
            try
            {
                DataTable dtG = new DataTable();
                dtG = new DAChartsOfItem().GetChildGroup(int.Parse(n.Name), conn);
                if (dtG.Rows.Count == 0) return;

                foreach (DataRow dr in dtG.Rows)
                {
                    TreeNode NN = n.Nodes.Add((dr.Field<int>("ItemGroupID")).ToString(), dr.Field<string>("GroupName"));
                    addItem(NN);
                    
                    addChild(NN);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void addItem(TreeNode nd)
        {
            DataTable dt = new DataTable();
            dt = new DAChartsOfItem().GetChildItem(int.Parse(nd.Name), conn);
            if (dt.Rows.Count == 0) return;
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode ND=nd.Nodes.Add(dr.Field<int>("ItemID").ToString(),dr.Field<string>("ItemDescription"));
                ND.ForeColor = Color.Red;
            }
        }

        private void cmbSearchBy_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
            createDescription();
        }

        private void txtHSCode_TextChanged(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void frmChartsOfItem_Paint(object sender, PaintEventArgs e)
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

        private void LoadCurrentItem()
        {
            try
            {
                int ab = Convert.ToInt32(txtItemID.Text);
                DAChartsOfItem objChartsOfItem = new DAChartsOfItem();
             txtCurrentItem.Text=objChartsOfItem.GetCurrentItem(ab, conn).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error to load current items"+ex);
            }
        }

        private void txtItemID_TextChanged(object sender, EventArgs e)
        {

            LoadCurrentItem();
        }




        private void createDescription()
        {
            try
            {
                string Item = txtItemName.Text.Trim() +"[ ";
                string size,color,count,shade;
                size=cmbSize.GetItemText(cmbSize.SelectedItem);
                if (size != "N/A")
                    Item += "Size="+ size+", ";
                color = cmbColor.GetItemText(cmbColor.SelectedItem);

                
                if (color != "N/A")
                    Item += "Color=" + color +", ";
                count = cmbCount.GetItemText(cmbCount.SelectedItem);
                if (count != "N/A")
                    Item += "Count=" + count +", ";

                shade = cmbShade.GetItemText(cmbShade.SelectedItem);
                if (shade != "N/A")
                    Item += "Shade=" + shade;

                if (Item.EndsWith(", "))
                    Item = Item.Substring(0, Item.Length - 2);
                Item += " ]";
                if (Item.EndsWith("[  ]"))
                    Item = Item.Substring(0, Item.Length - 4);
                txtItemDes.Text = Item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbColor_SelectedValueChanged(object sender, EventArgs e)
        {
            createDescription();
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
       
        

        
        }

       
           

       
    
}
