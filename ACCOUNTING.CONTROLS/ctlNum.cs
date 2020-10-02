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
    public partial class ctlNum : UserControl
    {

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler valueChanged;
      
        public ctlNum()
        {
            InitializeComponent();
           // txtNum.Text = "0";
            valueChanged += new EventHandler(txtNum_ValueChanged);    
        }


        public Color BackgroudColor
        {
            get { return txtNum.BackColor; }
            set { txtNum.BackColor = value; }
        }
        public Color TextColor
        {
            get { return txtNum.ForeColor; }
            set { txtNum.ForeColor = value; }
        }

        private void ctlNum_Resize(object sender, EventArgs e)
        {
            if (this.Width > 300)
            {
                this.Width = this.txtNum.Width = 300;
            }
            else
            {
                this.Width = this.txtNum.Width = this.Width;
            }

            if (this.Height > 20)
            {
                this.Height = this.txtNum.Height = 20;
            }
            else
            {
                this.txtNum.Height = this.Height;
            }
        }


        public new BorderStyle BorderStyle
        {
            //get{ return _numValue;}

            set { txtNum.BorderStyle = value; }
        }


        private double _numValue = 0;

        public double Value
        {
            get {
 
               
                return _numValue;
            }
            set {
                _numValue = value;
                txtNum.Text = _numValue.ToString();
                //txtNum_TextChanged(null, null);
            }    
        }
        public bool ReadOnly
        {
            get { return txtNum.ReadOnly; }
            set { txtNum.ReadOnly = value; }
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
           

            if (Char.IsLetter(e.KeyChar) && !e.KeyChar.Equals('.'))
            {
                e.Handled = true;
            }
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //txtNum.ForeColor = SystemColors.ControlText;
                _numValue = Double.Parse(txtNum.Text);

            }
            catch 
            {
                //txtNum.ForeColor = Color.Red;
                _numValue =0;
                txtNum.Text = _numValue.ToString() ;
                txtNum.SelectAll();

            }
            if (valueChanged != null)
            {
                valueChanged(sender, e);
            }
        }

        public void txtNum_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNum_KeyDown(object sender, KeyEventArgs e)
        {
            ctlNum_KeyDown(sender, e);
        }

        private void ctlNum_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode==Keys.Enter)
           Parent.SelectNextControl(this, true, true, true, true);
        }

        private void txtNum_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.Black;
            c.ForeColor = Color.White;
        }

        private void txtNum_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.White;
            c.ForeColor = Color.Black;
        }
       

        
    }
}
