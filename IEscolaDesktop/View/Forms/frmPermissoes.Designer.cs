namespace IEscolaDesktop.View.Forms
{
    partial class frmPermissoes
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissoes));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPesquisar = new DevExpress.XtraEditors.ButtonEdit();
            this.btnNovo = new DevExpress.XtraEditors.SimpleButton();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.permissoesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rowPermissoeID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowList = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCreate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUpdate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDelete = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowClasses = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowEstudantes = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowGrupo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowLogs = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPeriodos = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPermissions = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTurmas = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowUsuarios = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.MenuPrinciapl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAtualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApagar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRelatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportdatabase = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissoesBindingSource)).BeginInit();
            this.MenuPrinciapl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Controls.Add(this.tableLayoutPanel1);
            this.tablePanel1.Controls.Add(this.vGridControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 59.59999F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60.40005F)});
            this.tablePanel1.Size = new System.Drawing.Size(671, 556);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // tableLayoutPanel1
            // 
            this.tablePanel1.SetColumn(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtPesquisar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNovo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tablePanel1.SetRow(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(639, 54);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPesquisar.Enabled = false;
            this.txtPesquisar.Location = new System.Drawing.Point(3, 3);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Properties.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txtPesquisar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtPesquisar.Properties.NullValuePrompt = "Pesquise Aqui [Usuarios]";
            this.txtPesquisar.Size = new System.Drawing.Size(521, 48);
            this.txtPesquisar.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovo.ImageOptions.SvgImage")));
            this.btnNovo.Location = new System.Drawing.Point(530, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(106, 48);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            // 
            // vGridControl1
            // 
            this.vGridControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.vGridControl1.CaptionHeight = 20;
            this.tablePanel1.SetColumn(this.vGridControl1, 0);
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGridControl1.DataSource = this.permissoesBindingSource;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl1.Location = new System.Drawing.Point(16, 75);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.OptionsBehavior.Editable = false;
            this.tablePanel1.SetRow(this.vGridControl1, 1);
            this.vGridControl1.RowHeaderWidth = 148;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowPermissoeID,
            this.rowList,
            this.rowCreate,
            this.rowUpdate,
            this.rowDelete,
            this.rowClasses,
            this.rowEstudantes,
            this.rowGrupo,
            this.rowLogs,
            this.rowPeriodos,
            this.rowPermissions,
            this.rowTurmas,
            this.rowUsuarios});
            this.vGridControl1.Size = new System.Drawing.Size(639, 465);
            this.vGridControl1.TabIndex = 3;
            // 
            // permissoesBindingSource
            // 
            this.permissoesBindingSource.DataSource = typeof(IEscolaEntity.Models.Permissoes);
            // 
            // rowPermissoeID
            // 
            this.rowPermissoeID.Name = "rowPermissoeID";
            this.rowPermissoeID.Properties.Caption = "Código";
            this.rowPermissoeID.Properties.FieldName = "PermissoeID";
            // 
            // rowList
            // 
            this.rowList.Name = "rowList";
            this.rowList.Properties.Caption = "List";
            this.rowList.Properties.FieldName = "List";
            // 
            // rowCreate
            // 
            this.rowCreate.Name = "rowCreate";
            this.rowCreate.Properties.Caption = "Create";
            this.rowCreate.Properties.FieldName = "Create";
            // 
            // rowUpdate
            // 
            this.rowUpdate.Name = "rowUpdate";
            this.rowUpdate.Properties.Caption = "Update";
            this.rowUpdate.Properties.FieldName = "Update";
            // 
            // rowDelete
            // 
            this.rowDelete.Name = "rowDelete";
            this.rowDelete.Properties.Caption = "Delete";
            this.rowDelete.Properties.FieldName = "Delete";
            // 
            // rowClasses
            // 
            this.rowClasses.Name = "rowClasses";
            this.rowClasses.Properties.Caption = "Classes";
            this.rowClasses.Properties.FieldName = "Classes";
            // 
            // rowEstudantes
            // 
            this.rowEstudantes.Name = "rowEstudantes";
            this.rowEstudantes.Properties.Caption = "Estudantes";
            this.rowEstudantes.Properties.FieldName = "Estudantes";
            // 
            // rowGrupo
            // 
            this.rowGrupo.Name = "rowGrupo";
            this.rowGrupo.Properties.Caption = "Grupos";
            this.rowGrupo.Properties.FieldName = "Grupos";
            // 
            // rowLogs
            // 
            this.rowLogs.Name = "rowLogs";
            this.rowLogs.Properties.Caption = "Logs";
            this.rowLogs.Properties.FieldName = "Logs";
            // 
            // rowPeriodos
            // 
            this.rowPeriodos.Name = "rowPeriodos";
            this.rowPeriodos.Properties.Caption = "Periodos";
            this.rowPeriodos.Properties.FieldName = "Periodos";
            // 
            // rowPermissions
            // 
            this.rowPermissions.Name = "rowPermissions";
            this.rowPermissions.Properties.Caption = "Permissions";
            this.rowPermissions.Properties.FieldName = "Permissions";
            // 
            // rowTurmas
            // 
            this.rowTurmas.Name = "rowTurmas";
            this.rowTurmas.Properties.Caption = "Turmas";
            this.rowTurmas.Properties.FieldName = "Turmas";
            // 
            // rowUsuarios
            // 
            this.rowUsuarios.Name = "rowUsuarios";
            this.rowUsuarios.Properties.Caption = "Usuarios";
            this.rowUsuarios.Properties.FieldName = "Usuarios";
            // 
            // MenuPrinciapl
            // 
            this.MenuPrinciapl.BackColor = System.Drawing.SystemColors.Control;
            this.MenuPrinciapl.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPrinciapl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAtualizar,
            this.toolStripSeparator3,
            this.btnApagar,
            this.toolStripSeparator2,
            this.btnRelatorios,
            this.btnReportdatabase});
            this.MenuPrinciapl.Name = "contextMenuStrip1";
            this.MenuPrinciapl.Size = new System.Drawing.Size(275, 168);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(274, 38);
            this.btnAtualizar.Text = "Editar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(271, 6);
            // 
            // btnApagar
            // 
            this.btnApagar.Image = ((System.Drawing.Image)(resources.GetObject("btnApagar.Image")));
            this.btnApagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(274, 38);
            this.btnApagar.Text = "Apagar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(271, 6);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorios.Image")));
            this.btnRelatorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(274, 38);
            this.btnRelatorios.Text = "Relatórios";
            // 
            // btnReportdatabase
            // 
            this.btnReportdatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnReportdatabase.Image")));
            this.btnReportdatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReportdatabase.Name = "btnReportdatabase";
            this.btnReportdatabase.Size = new System.Drawing.Size(274, 38);
            this.btnReportdatabase.Text = "Relatórios (Base de Dados)";
            // 
            // frmPermissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmPermissoes";
            this.Size = new System.Drawing.Size(671, 556);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissoesBindingSource)).EndInit();
            this.MenuPrinciapl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem btnAtualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnApagar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnRelatorios;
        private System.Windows.Forms.ToolStripMenuItem btnReportdatabase;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private System.Windows.Forms.BindingSource permissoesBindingSource;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPermissoeID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowList;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCreate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUpdate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDelete;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowClasses;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowEstudantes;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowGrupo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowLogs;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPeriodos;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPermissions;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTurmas;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowUsuarios;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ButtonEdit txtPesquisar;
        private DevExpress.XtraEditors.SimpleButton btnNovo;
    }
}
