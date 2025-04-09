namespace IEscolaDesktop.View.Forms
{
    partial class frmUsuarioHelps
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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.txtDescricao = new System.Windows.Forms.RichTextBox();
            this.txtTitulos = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Controls.Add(this.txtDescricao);
            this.tablePanel1.Controls.Add(this.txtTitulos);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 43.59998F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 212.4005F)});
            this.tablePanel1.Size = new System.Drawing.Size(345, 450);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(0)))), ((int)(((byte)(16)))));
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablePanel1.SetColumn(this.txtDescricao, 0);
            this.txtDescricao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescricao.ForeColor = System.Drawing.Color.White;
            this.txtDescricao.Location = new System.Drawing.Point(14, 56);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescricao.Name = "txtDescricao";
            this.tablePanel1.SetRow(this.txtDescricao, 1);
            this.txtDescricao.Size = new System.Drawing.Size(317, 381);
            this.txtDescricao.TabIndex = 1;
            this.txtDescricao.Text = "A ASINFORPREST\n\nÉ uma empresa especialista em desenvolvimento de softwares e outr" +
    "os serviços espericias";
            // 
            // txtTitulos
            // 
            this.txtTitulos.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulos.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtTitulos.Appearance.Options.UseFont = true;
            this.txtTitulos.Appearance.Options.UseForeColor = true;
            this.txtTitulos.Appearance.Options.UseTextOptions = true;
            this.txtTitulos.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablePanel1.SetColumn(this.txtTitulos, 0);
            this.txtTitulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitulos.Location = new System.Drawing.Point(14, 12);
            this.txtTitulos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTitulos.Name = "txtTitulos";
            this.tablePanel1.SetRow(this.txtTitulos, 0);
            this.txtTitulos.Size = new System.Drawing.Size(317, 40);
            this.txtTitulos.TabIndex = 0;
            this.txtTitulos.Text = "Termos e Condições";
            // 
            // frmUsuarioHelps
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(0)))), ((int)(((byte)(16)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tablePanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUsuarioHelps";
            this.Size = new System.Drawing.Size(345, 450);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl txtTitulos;
        private System.Windows.Forms.RichTextBox txtDescricao;
    }
}
