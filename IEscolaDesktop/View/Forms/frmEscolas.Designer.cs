namespace IEscolaDesktop.View.Forms
{
    partial class frmEscolas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEscolas));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPesquisar = new DevExpress.XtraEditors.ButtonEdit();
            this.btnNovo = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.entidadeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEntidadeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssinaturaDirector = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssinaturaSubDirector = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeader1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeader2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeader3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEscolaCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstatuto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFazemTeste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvinciaMunicipioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvinciasMunicipios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.MenuPrinciapl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Controls.Add(this.tableLayoutPanel1);
            this.tablePanel1.Controls.Add(this.gridControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60.40005F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 435.5993F)});
            this.tablePanel1.Size = new System.Drawing.Size(1002, 624);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // tableLayoutPanel1
            // 
            this.tablePanel1.SetColumn(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtPesquisar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNovo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tablePanel1.SetRow(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(974, 41);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPesquisar.Location = new System.Drawing.Point(3, 2);
            this.txtPesquisar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Properties.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txtPesquisar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtPesquisar.Properties.NullValuePrompt = "Pesquise Aqui [Entidade]";
            this.txtPesquisar.Size = new System.Drawing.Size(925, 37);
            this.txtPesquisar.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovo.ImageOptions.SvgImage")));
            this.btnNovo.Location = new System.Drawing.Point(934, 2);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(37, 37);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            // 
            // gridControl1
            // 
            this.tablePanel1.SetColumn(this.gridControl1, 0);
            this.gridControl1.DataSource = this.entidadeBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(14, 72);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.tablePanel1.SetRow(this.gridControl1, 1);
            this.gridControl1.Size = new System.Drawing.Size(974, 539);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // entidadeBindingSource
            // 
            this.entidadeBindingSource.DataSource = typeof(IEscolaEntity.Models.Entidade);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEntidadeID,
            this.colDescricao,
            this.colAssinaturaDirector,
            this.colAssinaturaSubDirector,
            this.colHeader1,
            this.colHeader2,
            this.colHeader3,
            this.colEscolaCodigo,
            this.colEstatuto,
            this.colFazemTeste,
            this.colProvinciaMunicipioID,
            this.colProvinciasMunicipios});
            this.gridView1.DetailHeight = 284;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Pesquise Aqui";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 686;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colEntidadeID
            // 
            this.colEntidadeID.FieldName = "EntidadeID";
            this.colEntidadeID.Name = "colEntidadeID";
            this.colEntidadeID.Visible = true;
            this.colEntidadeID.VisibleIndex = 0;
            this.colEntidadeID.Width = 57;
            // 
            // colDescricao
            // 
            this.colDescricao.FieldName = "Descricao";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Visible = true;
            this.colDescricao.VisibleIndex = 2;
            this.colDescricao.Width = 116;
            // 
            // colAssinaturaDirector
            // 
            this.colAssinaturaDirector.FieldName = "AssinaturaDirector";
            this.colAssinaturaDirector.Name = "colAssinaturaDirector";
            this.colAssinaturaDirector.Visible = true;
            this.colAssinaturaDirector.VisibleIndex = 3;
            this.colAssinaturaDirector.Width = 102;
            // 
            // colAssinaturaSubDirector
            // 
            this.colAssinaturaSubDirector.FieldName = "AssinaturaSubDirector";
            this.colAssinaturaSubDirector.Name = "colAssinaturaSubDirector";
            this.colAssinaturaSubDirector.Width = 104;
            // 
            // colHeader1
            // 
            this.colHeader1.Caption = "Cabeçalho";
            this.colHeader1.FieldName = "Header1";
            this.colHeader1.Name = "colHeader1";
            this.colHeader1.Visible = true;
            this.colHeader1.VisibleIndex = 4;
            this.colHeader1.Width = 71;
            // 
            // colHeader2
            // 
            this.colHeader2.Caption = "Rodapé";
            this.colHeader2.FieldName = "Header2";
            this.colHeader2.Name = "colHeader2";
            this.colHeader2.Visible = true;
            this.colHeader2.VisibleIndex = 5;
            this.colHeader2.Width = 71;
            // 
            // colHeader3
            // 
            this.colHeader3.FieldName = "Header3";
            this.colHeader3.Name = "colHeader3";
            this.colHeader3.Width = 71;
            // 
            // colEscolaCodigo
            // 
            this.colEscolaCodigo.Caption = "NIF:";
            this.colEscolaCodigo.FieldName = "EscolaCodigo";
            this.colEscolaCodigo.Name = "colEscolaCodigo";
            this.colEscolaCodigo.Visible = true;
            this.colEscolaCodigo.VisibleIndex = 1;
            this.colEscolaCodigo.Width = 107;
            // 
            // colEstatuto
            // 
            this.colEstatuto.FieldName = "Estatuto";
            this.colEstatuto.Name = "colEstatuto";
            this.colEstatuto.Visible = true;
            this.colEstatuto.VisibleIndex = 6;
            this.colEstatuto.Width = 71;
            // 
            // colFazemTeste
            // 
            this.colFazemTeste.Caption = "Testes?";
            this.colFazemTeste.FieldName = "FazemTeste";
            this.colFazemTeste.Name = "colFazemTeste";
            this.colFazemTeste.Visible = true;
            this.colFazemTeste.VisibleIndex = 7;
            this.colFazemTeste.Width = 62;
            // 
            // colProvinciaMunicipioID
            // 
            this.colProvinciaMunicipioID.Caption = "Província";
            this.colProvinciaMunicipioID.FieldName = "ProvinciasMunicipios.Descricao";
            this.colProvinciaMunicipioID.Name = "colProvinciaMunicipioID";
            this.colProvinciaMunicipioID.Visible = true;
            this.colProvinciaMunicipioID.VisibleIndex = 8;
            this.colProvinciaMunicipioID.Width = 114;
            // 
            // colProvinciasMunicipios
            // 
            this.colProvinciasMunicipios.FieldName = "ProvinciasMunicipios";
            this.colProvinciasMunicipios.Name = "colProvinciasMunicipios";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
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
            this.MenuPrinciapl.Size = new System.Drawing.Size(252, 168);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(251, 38);
            this.btnAtualizar.Text = "Editar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(248, 6);
            // 
            // btnApagar
            // 
            this.btnApagar.Image = ((System.Drawing.Image)(resources.GetObject("btnApagar.Image")));
            this.btnApagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(251, 38);
            this.btnApagar.Text = "Apagar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(248, 6);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorios.Image")));
            this.btnRelatorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(251, 38);
            this.btnRelatorios.Text = "Relatórios";
            // 
            // btnReportdatabase
            // 
            this.btnReportdatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnReportdatabase.Image")));
            this.btnReportdatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReportdatabase.Name = "btnReportdatabase";
            this.btnReportdatabase.Size = new System.Drawing.Size(251, 38);
            this.btnReportdatabase.Text = "Relatórios (Base de Dados)";
            // 
            // frmEscolas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmEscolas";
            this.Size = new System.Drawing.Size(1002, 624);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entidadeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.MenuPrinciapl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.ButtonEdit txtPesquisar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ContextMenuStrip MenuPrinciapl;
        private System.Windows.Forms.ToolStripMenuItem btnAtualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnApagar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnRelatorios;
        private System.Windows.Forms.ToolStripMenuItem btnReportdatabase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnNovo;
        private System.Windows.Forms.BindingSource entidadeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEntidadeID;
        private DevExpress.XtraGrid.Columns.GridColumn colDescricao;
        private DevExpress.XtraGrid.Columns.GridColumn colAssinaturaDirector;
        private DevExpress.XtraGrid.Columns.GridColumn colAssinaturaSubDirector;
        private DevExpress.XtraGrid.Columns.GridColumn colHeader1;
        private DevExpress.XtraGrid.Columns.GridColumn colHeader2;
        private DevExpress.XtraGrid.Columns.GridColumn colHeader3;
        private DevExpress.XtraGrid.Columns.GridColumn colEscolaCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colEstatuto;
        private DevExpress.XtraGrid.Columns.GridColumn colFazemTeste;
        private DevExpress.XtraGrid.Columns.GridColumn colProvinciaMunicipioID;
        private DevExpress.XtraGrid.Columns.GridColumn colProvinciasMunicipios;
    }
}
