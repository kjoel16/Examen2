namespace Examen2
{
    partial class TicketsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsuarioscomboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // UsuarioscomboBox
            // 
            this.UsuarioscomboBox.FormattingEnabled = true;
            this.UsuarioscomboBox.Location = new System.Drawing.Point(266, 136);
            this.UsuarioscomboBox.Name = "UsuarioscomboBox";
            this.UsuarioscomboBox.Size = new System.Drawing.Size(121, 21);
            this.UsuarioscomboBox.TabIndex = 0;
            this.UsuarioscomboBox.SelectedIndexChanged += new System.EventHandler(this.UsuarioscomboBox_SelectedIndexChanged);
            // 
            // TicketsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 266);
            this.Controls.Add(this.UsuarioscomboBox);
            this.Name = "TicketsForm";
            this.Text = "TicketsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox UsuarioscomboBox;
    }
}