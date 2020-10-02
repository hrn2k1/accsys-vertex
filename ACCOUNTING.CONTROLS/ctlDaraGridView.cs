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
    public partial class ctlDaraGridView : DataGridView 
    {
        public ctlDaraGridView()
        {
            InitializeComponent();
        }

        private void defaultMenu()
        {
            _popItem[0] = new ToolStripMenuItem();
            _popItem[0].Checked = _showDateTimePicker;
            _popItem[0].CheckOnClick = true;
            _popItem[0].CheckState = _showDateTimePicker ? CheckState.Checked : CheckState.Unchecked;
            _popItem[0].Size = new System.Drawing.Size(192, 22);
            _popItem[0].Text = "Show DateTimePicker";
            _popItem[0].Click += new EventHandler(_popItem_Click);
            _popItem[0].Tag = "SDTP";
            _popMenu.Items.Add(_popItem[0]);
        }
        #region Fields
        private bool _isSortable = false;
        private int _numRowPointer = 0;
        private CurrencyManager _cmRowPointer = null;
        public event EventHandler sortableChanged;
        DateTimePicker _dtp = new DateTimePicker();
        ContextMenuStrip _popMenu = new ContextMenuStrip();
        ToolStripMenuItem[] _popItem = new ToolStripMenuItem[50];
        string[] _strMenuColName; //=new string []{null };
        private bool _showDateTimePicker = true;
        private Label _lblRecordCount = new Label();
        #endregion

        #region Properties

        public bool ShowDateTimePicker
        {
            get { return _showDateTimePicker; }
            set { _showDateTimePicker = value; }
        }
        public string[] ContextMenuFields
        {
            get { return _strMenuColName; }
            set
            {
                _strMenuColName = value;
                _popMenu_Opening(null, null);
            }
        }
        public new object DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;


                //if (_cmRowPointer.Count != 0) _cmRowPointer.Position = 0;
            }
        }

        void _cmRowPointer_PositionChanged(object sender, EventArgs e)
        {

        }


        public bool IsSortable
        {
            get { return _isSortable; }
            set
            {

                _isSortable = value;
            }
        }
        public int RowPointer
        {
            get { return _numRowPointer; }
            set
            {
                _numRowPointer = value;

                if (_cmRowPointer != null)
                    _cmRowPointer.Position = _numRowPointer;

            }
        }


        #endregion

        #region Method

        public void getMenu()
        {
            this.ContextMenuStrip = _popMenu;
            //_popMenu.Opening += new CancelEventHandler(_popMenu_Opening);

        }

        void _popMenu_Opening(object sender, CancelEventArgs e)
        {
            if (_popMenu.Items.Count != 0) _popMenu.Items.Clear();
            defaultMenu();
            if (_strMenuColName == null) return;


            int i, N;
            N = _strMenuColName.Length;
            for (i = 0; i < N; i++)
            {


                _popItem[i + 1] = new ToolStripMenuItem();
                _popItem[i + 1].Checked = this.Columns[_strMenuColName[i]].Visible;
                _popItem[i + 1].CheckOnClick = true;
                _popItem[i + 1].CheckState = (this.Columns[_strMenuColName[i]].Visible) ? CheckState.Checked : CheckState.Unchecked;
                _popItem[i + 1].Size = new System.Drawing.Size(192, 22);
                _popItem[i + 1].Text = this.Columns[_strMenuColName[i]].HeaderText;
                _popItem[i + 1].Click += new EventHandler(_popItem_Click);
                _popItem[i + 1].Tag = _strMenuColName[i];
                _popMenu.Items.Add(_popItem[i + 1]);

            }

        }

        void _popItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem itm = (ToolStripMenuItem)sender;

            if (itm.Tag.ToString() == "SDTP")
            {
                _showDateTimePicker = itm.Checked;
                _showDateTimePicker = itm.Checked;
                _dtp.Visible = _showDateTimePicker;

            }
            else
                this.Columns[itm.Tag.ToString()].Visible = itm.Checked;

        }


        public void setColumnsHeaderText(params  string[] strColsHeaderText)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsHeaderText.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[i].HeaderText = strColsHeaderText[i];
            }
        }
        public void setColumnsHeaderText(string[] strColsName, params string[] strColsHeaderText)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].HeaderText = strColsHeaderText[i];
            }
        }
        public void setColumnsHeaderText(int[] numColsIndex, params string[] strColsHeaderText)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].HeaderText = strColsHeaderText[i];
            }
        }
        public void setColumnsWidth(int numAllColsWidth)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = this.Columns.Count;

            for (i = 0; i < nC; i++)
            {
                this.Columns[i].Width = numAllColsWidth;
            }
        }
        public void setColumnsWidth(params int[] numColsWidth)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsWidth.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[i].Width = numColsWidth[i];
            }
        }
        public void setColumnsWidth(string[] strColsName, params int[] numColsWidth)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].Width = numColsWidth[i];
            }
        }
        public void setColumnsWidth(string[] strColsName, int numAllColsWidth)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].Width = numAllColsWidth;
            }
        }
        public void setColumnsWidth(int[] numColsIndex, params int[] numColsWidth)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].Width = numColsWidth[i];
            }
        }
        public void setColumnsWidth(int[] numColsIndex, int numAllColsWidth)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].Width = numAllColsWidth;
            }
        }

        public void setColumnsVisible(params bool[] blVisibility)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = blVisibility.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[i].Visible = blVisibility[i];
            }
        }
        public void setColumnsVisible(string[] strColsName, params bool[] blVisibility)
        {
            if (this.Columns.Count == 0)
                return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].Visible = blVisibility[0];
            }
        }
        public void setColumnsVisible(string[] strColsName, bool blAllVisibility)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].Visible = blAllVisibility;
            }
        }
        public void setColumnsVisible(string[] strColsName, bool blAllVisibility, bool blThisColumnsOnly)
        {
            if (blThisColumnsOnly)
            {
                int i, nC;
                nC = this.Columns.Count;
                for (i = 0; i < nC; i++)
                {
                    this.Columns[i].Visible = false;
                }
            }
            setColumnsVisible(strColsName, blAllVisibility);
        }
        public void setColumnsVisible(bool blAllVisibility, params string[] strColsName)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].Visible = blAllVisibility;
            }
        }
        public void setColumnsVisible(int[] numColsIndex, params bool[] blVisibility)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].Visible = blVisibility[i];
            }
        }
        public void setColumnsVisible(int[] numColsIndex, bool blAllVisibility)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].Visible = blAllVisibility;
            }
        }



        public void setColumnsReadOnly(params  bool[] blReadOnly)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = blReadOnly.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[i].ReadOnly = blReadOnly[i];
            }
        }
        public void setColumnsReadOnly(string[] strColsName, params  bool[] blReadOnly)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].ReadOnly = blReadOnly[i];
            }
        }
        public void setColumnsReadOnly(string[] strColsName, bool blAllReadOnly)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].ReadOnly = blAllReadOnly;
            }
        }
        public void setColumnsReadOnly(string[] strColsName, bool blAllReadOnly, bool blThisColumnsOnly)
        {
            if (blThisColumnsOnly)
            {
                int i, nC;
                nC = this.Columns.Count;
                for (i = 0; i < nC; i++)
                {
                    this.Columns[i].ReadOnly = true;
                }
            }
            setColumnsReadOnly(strColsName, blAllReadOnly);
        }
        public void setColumnsReadOnly(int[] numColsIndex, params bool[] blReadOnly)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].ReadOnly = blReadOnly[i];
            }

        }
        public void setColumnsReadOnly(int[] numColsIndex, bool blAllReadOnly)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].ReadOnly = blAllReadOnly;
            }

        }
        public void setColumnsReadOnly(bool blAllVisibility, params string[] strColsName)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].ReadOnly = blAllVisibility;
            }
        }

        public void setColumnsFormat(params string[] strColsFormat)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsFormat.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[i].DefaultCellStyle.Format = strColsFormat[i];
            }
        }
        public void setColumnsFormat(string[] strColsName, params string[] strColsFormat)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].DefaultCellStyle.Format = strColsFormat[i];
            }
        }
        public void setColumnsFormat(string[] strColsName, string strAllColsFormat)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].DefaultCellStyle.Format = strAllColsFormat;
            }
        }
        public void setColumnsFormat(int[] numColsIndex, params string[] strColsFormat)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].DefaultCellStyle.Format = strColsFormat[i];
            }
        }
        public void setColumnsFormat(int[] numColsIndex, string strAllColsFormat)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].DefaultCellStyle.Format = strAllColsFormat;
            }
        }

        public void setColumnsDisplayOrder(string[] strColsName)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[strColsName[i]].DisplayIndex = i;
            }
        }
        public void setColumnsDisplayOrder(string[] strColsName, string sortMode)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = strColsName.Length;

            for (i = 0; i < nC; i++)
            {
                if (sortMode == "Asc") this.Columns[strColsName[i]].DisplayIndex = i;
                else if (sortMode == "Desc") this.Columns[strColsName[i]].DisplayIndex = nC - i - 1;
            }
        }
        public void setColumnsDisplayOrder(int[] numColsIndex)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                this.Columns[numColsIndex[i]].DisplayIndex = i;
            }
        }
        public void setColumnsDisplayOrder(int[] numColsIndex, string sortMode)
        {
            if (this.Columns.Count == 0) return;
            int i, nC;
            nC = numColsIndex.Length;

            for (i = 0; i < nC; i++)
            {
                if (sortMode == "Asc") this.Columns[numColsIndex[i]].DisplayIndex = i;
                else if (sortMode == "Desc") this.Columns[numColsIndex[i]].DisplayIndex = nC - i - 1;
            }
        }

        public bool isColumnExist(string strColName)
        {

            try
            {

                int w;
                w = this.Columns[strColName].Width;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool isNullOrEmpty(int rowID, string ColName)
        {
            if (this.Rows[rowID].Cells[ColName].Value == null || this.Rows[rowID].Cells[ColName].Value.ToString().Trim() == "")
                return true;
            else
                return false;
        }
        #endregion


        private void this_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            _cmRowPointer = (CurrencyManager)base.BindingContext[base.DataSource];
            _cmRowPointer.PositionChanged += new EventHandler(_cmRowPointer_PositionChanged);
            getMenu();
            if (sortableChanged != null)
            {
                sortableChanged(null, null);
            }


        }

        private void ctlDaraGridView_sortableChanged(object sender, EventArgs e)
        {
            int nC;
            nC = this.Columns.Count;
            for (int i = 0; i < nC; i++)
            {
                this.Columns[i].SortMode = (_isSortable == true ? DataGridViewColumnSortMode.Automatic : DataGridViewColumnSortMode.NotSortable);
            }
        }

        private void showRecordCount()
        {
            //throw new NotImplementedException();
            Rectangle cellArea = new Rectangle();
            cellArea = base.GetCellDisplayRectangle(0, 0, true);

            _lblRecordCount.SetBounds(cellArea.X, cellArea.Y + base.Height, 300, 60);
            _lblRecordCount.Text = "HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH";
            base.Controls.Add(_lblRecordCount);

        }
        private void showDateTime()
        {
            if (_showDateTimePicker == false) return;
            if (this.CurrentCell == null) return;
            int row, col;
            int left, top, height, width;
            row = base.CurrentCell.RowIndex;
            col = base.CurrentCell.ColumnIndex;
            if (base.Columns[col].ValueType == typeof(DateTime))
            {

                _dtp.Visible = true;
                _dtp.Format = DateTimePickerFormat.Custom;
                _dtp.CustomFormat = base.Columns[col].DefaultCellStyle.Format;
                if (base.Columns[col].DefaultCellStyle.Format == "hh:mm:ss tt")
                    _dtp.ShowUpDown = true;
                else
                    _dtp.ShowUpDown = false;
                this.Controls.Add(_dtp);
                if (base.Rows[row].Cells[col].Value == DBNull.Value || base.Rows[row].Cells[col].Value == null)
                    _dtp.Value = DateTime.Now.Date;
                else
                    _dtp.Value = (DateTime)this.Rows[row].Cells[col].Value;

                // this.Rows[row].Cells[col].ReadOnly = true;
                Rectangle cellArea = new Rectangle();
                cellArea = base.GetCellDisplayRectangle(col, row, true);
                left = cellArea.Left;
                top = cellArea.Top;
                height = cellArea.Height;
                width = cellArea.Width;
                _dtp.SetBounds(left, top, width, height);


                _dtp.Enabled = !(base.Rows[row].Cells[col].ReadOnly);
            }
            else
            {

                _dtp.Visible = false;
            }
        }



        private void this_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Columns[e.ColumnIndex].ValueType == typeof(DateTime) && this.Columns[e.ColumnIndex].ReadOnly == false && _showDateTimePicker == true)
                this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _dtp.Value;

        }

        private void this_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            showDateTime();
        }

        private void this_Scroll(object sender, ScrollEventArgs e)
        {
            showDateTime();
        }

        private void this_Resize(object sender, EventArgs e)
        {
            showDateTime();
        }

        private void this_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            showDateTime();
        }

        private void this_RowHeadersWidthChanged(object sender, EventArgs e)
        {
            showDateTime();
        }


    }
}
