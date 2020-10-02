namespace Accounting.Controls
{
    partial class ctlDaraGridView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlDaraGridView
            // 
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.this_Scroll);
            this.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.this_CellLeave);
            this.RowHeadersWidthChanged += new System.EventHandler(this.this_RowHeadersWidthChanged);
            this.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.this_CellEnter);
            this.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.this_DataBindingComplete);
            this.Resize += new System.EventHandler(this.this_Resize);
            this.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.this_ColumnWidthChanged);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
