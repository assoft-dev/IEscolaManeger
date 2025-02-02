namespace IEscolaDesktop.View.Forms
{
    partial class frmBiblioteca_Livros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiblioteca_Livros));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnXLS = new DevExpress.XtraEditors.SimpleButton();
            this.btnPDF = new DevExpress.XtraEditors.SimpleButton();
            this.txtPesquisar = new DevExpress.XtraEditors.ButtonEdit();
            this.btnNovo = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.livrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLivrosID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubTitulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComentarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdicao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLancamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsValidade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodBar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPratileira = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPratileiraPosicao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRating = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFavoritar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalLancamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEditorasID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutoresID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoriasID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImagemFrente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImagemVerso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisponibilidade = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.livrosBindingSource)).BeginInit();
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
            this.tablePanel1.Size = new System.Drawing.Size(794, 602);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // tableLayoutPanel1
            // 
            this.tablePanel1.SetColumn(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Controls.Add(this.btnXLS, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPDF, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPesquisar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNovo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tablePanel1.SetRow(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(766, 41);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnXLS
            // 
            this.btnXLS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXLS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXLS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXLS.ImageOptions.SvgImage")));
            this.btnXLS.Location = new System.Drawing.Point(726, 2);
            this.btnXLS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXLS.Name = "btnXLS";
            this.btnXLS.Size = new System.Drawing.Size(37, 37);
            this.btnXLS.TabIndex = 3;
            this.btnXLS.Text = "XLS";
            // 
            // btnPDF
            // 
            this.btnPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPDF.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPDF.ImageOptions.SvgImage")));
            this.btnPDF.Location = new System.Drawing.Point(683, 2);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(37, 37);
            this.btnPDF.TabIndex = 2;
            this.btnPDF.Text = "PDF";
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
            this.txtPesquisar.Properties.NullValuePrompt = "Pesquise Aqui [Livros]";
            this.txtPesquisar.Size = new System.Drawing.Size(631, 37);
            this.txtPesquisar.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovo.ImageOptions.SvgImage")));
            this.btnNovo.Location = new System.Drawing.Point(640, 2);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(37, 37);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click_1);
            // 
            // gridControl1
            // 
            this.tablePanel1.SetColumn(this.gridControl1, 0);
            this.gridControl1.DataSource = this.livrosBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(14, 72);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.tablePanel1.SetRow(this.gridControl1, 1);
            this.gridControl1.Size = new System.Drawing.Size(766, 517);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // livrosBindingSource
            // 
            this.livrosBindingSource.DataSource = typeof(IEscolaEntity.Models.Biblioteca.Livros);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLivrosID,
            this.colTitulo,
            this.colSubTitulo,
            this.colISBN,
            this.colDescricao,
            this.colComentarios,
            this.colEdicao,
            this.colLancamento,
            this.colIsValidade,
            this.colCodBar,
            this.colPratileira,
            this.colPratileiraPosicao,
            this.colRating,
            this.colFavoritar,
            this.colAno,
            this.colLocalLancamento,
            this.colEditorasID,
            this.colAutoresID,
            this.colCategoriasID,
            this.colImagemFrente,
            this.colImagemVerso,
            this.colDisponibilidade});
            this.gridView1.DetailHeight = 225;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "Pesquise Aqui";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableDetailToolTip = true;
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 686;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colLivrosID
            // 
            this.colLivrosID.FieldName = "LivrosID";
            this.colLivrosID.Name = "colLivrosID";
            this.colLivrosID.Visible = true;
            this.colLivrosID.VisibleIndex = 0;
            this.colLivrosID.Width = 64;
            // 
            // colTitulo
            // 
            this.colTitulo.FieldName = "Titulo";
            this.colTitulo.Name = "colTitulo";
            this.colTitulo.Visible = true;
            this.colTitulo.VisibleIndex = 1;
            this.colTitulo.Width = 64;
            // 
            // colSubTitulo
            // 
            this.colSubTitulo.FieldName = "SubTitulo";
            this.colSubTitulo.Name = "colSubTitulo";
            this.colSubTitulo.Visible = true;
            this.colSubTitulo.VisibleIndex = 2;
            this.colSubTitulo.Width = 64;
            // 
            // colISBN
            // 
            this.colISBN.FieldName = "ISBN";
            this.colISBN.Name = "colISBN";
            this.colISBN.Visible = true;
            this.colISBN.VisibleIndex = 3;
            this.colISBN.Width = 64;
            // 
            // colDescricao
            // 
            this.colDescricao.FieldName = "Descricao";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Visible = true;
            this.colDescricao.VisibleIndex = 4;
            this.colDescricao.Width = 64;
            // 
            // colComentarios
            // 
            this.colComentarios.FieldName = "Comentarios";
            this.colComentarios.Name = "colComentarios";
            this.colComentarios.Visible = true;
            this.colComentarios.VisibleIndex = 5;
            this.colComentarios.Width = 64;
            // 
            // colEdicao
            // 
            this.colEdicao.FieldName = "Edicao";
            this.colEdicao.Name = "colEdicao";
            this.colEdicao.Visible = true;
            this.colEdicao.VisibleIndex = 6;
            this.colEdicao.Width = 64;
            // 
            // colLancamento
            // 
            this.colLancamento.FieldName = "Lancamento";
            this.colLancamento.Name = "colLancamento";
            this.colLancamento.Visible = true;
            this.colLancamento.VisibleIndex = 7;
            this.colLancamento.Width = 64;
            // 
            // colIsValidade
            // 
            this.colIsValidade.FieldName = "IsValidade";
            this.colIsValidade.Name = "colIsValidade";
            this.colIsValidade.Visible = true;
            this.colIsValidade.VisibleIndex = 8;
            this.colIsValidade.Width = 64;
            // 
            // colCodBar
            // 
            this.colCodBar.FieldName = "CodBar";
            this.colCodBar.Name = "colCodBar";
            this.colCodBar.Visible = true;
            this.colCodBar.VisibleIndex = 9;
            this.colCodBar.Width = 64;
            // 
            // colPratileira
            // 
            this.colPratileira.FieldName = "Pratileira";
            this.colPratileira.Name = "colPratileira";
            this.colPratileira.Visible = true;
            this.colPratileira.VisibleIndex = 10;
            this.colPratileira.Width = 64;
            // 
            // colPratileiraPosicao
            // 
            this.colPratileiraPosicao.FieldName = "PratileiraPosicao";
            this.colPratileiraPosicao.Name = "colPratileiraPosicao";
            this.colPratileiraPosicao.Visible = true;
            this.colPratileiraPosicao.VisibleIndex = 11;
            this.colPratileiraPosicao.Width = 64;
            // 
            // colRating
            // 
            this.colRating.FieldName = "Rating";
            this.colRating.Name = "colRating";
            this.colRating.Visible = true;
            this.colRating.VisibleIndex = 12;
            this.colRating.Width = 64;
            // 
            // colFavoritar
            // 
            this.colFavoritar.FieldName = "Favoritar";
            this.colFavoritar.Name = "colFavoritar";
            this.colFavoritar.Visible = true;
            this.colFavoritar.VisibleIndex = 13;
            this.colFavoritar.Width = 64;
            // 
            // colAno
            // 
            this.colAno.FieldName = "Ano";
            this.colAno.Name = "colAno";
            this.colAno.Visible = true;
            this.colAno.VisibleIndex = 14;
            this.colAno.Width = 64;
            // 
            // colLocalLancamento
            // 
            this.colLocalLancamento.FieldName = "LocalLancamento";
            this.colLocalLancamento.Name = "colLocalLancamento";
            this.colLocalLancamento.Visible = true;
            this.colLocalLancamento.VisibleIndex = 15;
            this.colLocalLancamento.Width = 64;
            // 
            // colEditorasID
            // 
            this.colEditorasID.FieldName = "EditorasID";
            this.colEditorasID.Name = "colEditorasID";
            this.colEditorasID.Visible = true;
            this.colEditorasID.VisibleIndex = 16;
            this.colEditorasID.Width = 64;
            // 
            // colAutoresID
            // 
            this.colAutoresID.FieldName = "AutoresID";
            this.colAutoresID.Name = "colAutoresID";
            this.colAutoresID.Visible = true;
            this.colAutoresID.VisibleIndex = 17;
            this.colAutoresID.Width = 64;
            // 
            // colCategoriasID
            // 
            this.colCategoriasID.FieldName = "CategoriasID";
            this.colCategoriasID.Name = "colCategoriasID";
            this.colCategoriasID.Visible = true;
            this.colCategoriasID.VisibleIndex = 18;
            this.colCategoriasID.Width = 64;
            // 
            // colImagemFrente
            // 
            this.colImagemFrente.FieldName = "ImagemFrente";
            this.colImagemFrente.Name = "colImagemFrente";
            this.colImagemFrente.Visible = true;
            this.colImagemFrente.VisibleIndex = 19;
            this.colImagemFrente.Width = 64;
            // 
            // colImagemVerso
            // 
            this.colImagemVerso.FieldName = "ImagemVerso";
            this.colImagemVerso.Name = "colImagemVerso";
            this.colImagemVerso.Visible = true;
            this.colImagemVerso.VisibleIndex = 20;
            this.colImagemVerso.Width = 64;
            // 
            // colDisponibilidade
            // 
            this.colDisponibilidade.FieldName = "Disponibilidade";
            this.colDisponibilidade.Name = "colDisponibilidade";
            this.colDisponibilidade.Visible = true;
            this.colDisponibilidade.VisibleIndex = 21;
            this.colDisponibilidade.Width = 64;
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
            this.MenuPrinciapl.Size = new System.Drawing.Size(230, 168);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizar.Image")));
            this.btnAtualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(229, 38);
            this.btnAtualizar.Text = "Editar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(226, 6);
            // 
            // btnApagar
            // 
            this.btnApagar.Image = ((System.Drawing.Image)(resources.GetObject("btnApagar.Image")));
            this.btnApagar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(229, 38);
            this.btnApagar.Text = "Apagar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorios.Image")));
            this.btnRelatorios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(229, 38);
            this.btnRelatorios.Text = "Relatórios";
            // 
            // btnReportdatabase
            // 
            this.btnReportdatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnReportdatabase.Image")));
            this.btnReportdatabase.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReportdatabase.Name = "btnReportdatabase";
            this.btnReportdatabase.Size = new System.Drawing.Size(229, 38);
            this.btnReportdatabase.Text = "Relatórios (Base de Dados)";
            // 
            // frmBiblioteca_Livros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmBiblioteca_Livros";
            this.Size = new System.Drawing.Size(794, 602);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livrosBindingSource)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton btnXLS;
        private DevExpress.XtraEditors.SimpleButton btnPDF;
        private System.Windows.Forms.BindingSource livrosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLivrosID;
        private DevExpress.XtraGrid.Columns.GridColumn colTitulo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubTitulo;
        private DevExpress.XtraGrid.Columns.GridColumn colISBN;
        private DevExpress.XtraGrid.Columns.GridColumn colDescricao;
        private DevExpress.XtraGrid.Columns.GridColumn colComentarios;
        private DevExpress.XtraGrid.Columns.GridColumn colEdicao;
        private DevExpress.XtraGrid.Columns.GridColumn colLancamento;
        private DevExpress.XtraGrid.Columns.GridColumn colIsValidade;
        private DevExpress.XtraGrid.Columns.GridColumn colCodBar;
        private DevExpress.XtraGrid.Columns.GridColumn colPratileira;
        private DevExpress.XtraGrid.Columns.GridColumn colPratileiraPosicao;
        private DevExpress.XtraGrid.Columns.GridColumn colRating;
        private DevExpress.XtraGrid.Columns.GridColumn colFavoritar;
        private DevExpress.XtraGrid.Columns.GridColumn colAno;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalLancamento;
        private DevExpress.XtraGrid.Columns.GridColumn colEditorasID;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoresID;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoriasID;
        private DevExpress.XtraGrid.Columns.GridColumn colImagemFrente;
        private DevExpress.XtraGrid.Columns.GridColumn colImagemVerso;
        private DevExpress.XtraGrid.Columns.GridColumn colDisponibilidade;
    }
}
