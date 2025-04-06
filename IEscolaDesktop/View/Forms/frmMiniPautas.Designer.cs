namespace IEscolaDesktop.View.Forms
{
    partial class frmMiniPautas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMiniPautas));
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
            this.miniPautasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPautasID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstudantesID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPautas_TrimestresID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNPP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNPT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDivid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAC1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNPT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNPP1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDivid2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAC2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNPP2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNPT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDivid3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMFD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOBS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTurmasID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Perfil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.miniPautasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
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
            this.tablePanel1.Size = new System.Drawing.Size(903, 558);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 41);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnXLS
            // 
            this.btnXLS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXLS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnXLS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXLS.ImageOptions.SvgImage")));
            this.btnXLS.Location = new System.Drawing.Point(835, 2);
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
            this.btnPDF.Location = new System.Drawing.Point(792, 2);
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
            this.txtPesquisar.Properties.NullValuePrompt = "Pesquise Aqui [Estudante, professor]";
            this.txtPesquisar.Size = new System.Drawing.Size(740, 37);
            this.txtPesquisar.TabIndex = 0;
            // 
            // btnNovo
            // 
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNovo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNovo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovo.ImageOptions.SvgImage")));
            this.btnNovo.Location = new System.Drawing.Point(749, 2);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(37, 37);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "Novo";
            // 
            // gridControl1
            // 
            this.tablePanel1.SetColumn(this.gridControl1, 0);
            this.gridControl1.DataSource = this.miniPautasBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(14, 72);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemPictureEdit1});
            this.tablePanel1.SetRow(this.gridControl1, 1);
            this.gridControl1.Size = new System.Drawing.Size(875, 473);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // miniPautasBindingSource
            // 
            this.miniPautasBindingSource.DataSource = typeof(IEscolaEntity.Models.MiniPautas);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPautasID,
            this.colEstudantesID,
            this.colPautas_TrimestresID,
            this.colMAC,
            this.colNPP,
            this.colNPT,
            this.colMT,
            this.colDivid1,
            this.colMAC1,
            this.colNPT1,
            this.colNPP1,
            this.colDivid2,
            this.colMT1,
            this.colMAC2,
            this.colNPP2,
            this.colMT2,
            this.colNPT2,
            this.colDivid3,
            this.colMFD,
            this.colOBS,
            this.colTurmasID,
            this.Perfil});
            this.gridView1.DetailHeight = 225;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupPanelText = "Pesquise Aqui";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.EnableDetailToolTip = true;
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 686;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTurmasID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colEstudantesID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colPautasID
            // 
            this.colPautasID.Caption = "Código";
            this.colPautasID.FieldName = "PautasID";
            this.colPautasID.Name = "colPautasID";
            // 
            // colEstudantesID
            // 
            this.colEstudantesID.Caption = "Estudante";
            this.colEstudantesID.FieldName = "Estudantes.Inscricoes.FullName";
            this.colEstudantesID.Name = "colEstudantesID";
            this.colEstudantesID.Visible = true;
            this.colEstudantesID.VisibleIndex = 1;
            this.colEstudantesID.Width = 122;
            // 
            // colPautas_TrimestresID
            // 
            this.colPautas_TrimestresID.Caption = "Trimestre";
            this.colPautas_TrimestresID.FieldName = "Pautas_Trimestres.Descricao";
            this.colPautas_TrimestresID.Name = "colPautas_TrimestresID";
            // 
            // colMAC
            // 
            this.colMAC.FieldName = "MAC";
            this.colMAC.Name = "colMAC";
            this.colMAC.Visible = true;
            this.colMAC.VisibleIndex = 2;
            this.colMAC.Width = 36;
            // 
            // colNPP
            // 
            this.colNPP.FieldName = "NPP";
            this.colNPP.Name = "colNPP";
            this.colNPP.Visible = true;
            this.colNPP.VisibleIndex = 3;
            this.colNPP.Width = 37;
            // 
            // colNPT
            // 
            this.colNPT.FieldName = "NPT";
            this.colNPT.Name = "colNPT";
            this.colNPT.Visible = true;
            this.colNPT.VisibleIndex = 4;
            this.colNPT.Width = 35;
            // 
            // colMT
            // 
            this.colMT.FieldName = "MT";
            this.colMT.Name = "colMT";
            this.colMT.Visible = true;
            this.colMT.VisibleIndex = 5;
            this.colMT.Width = 33;
            // 
            // colDivid1
            // 
            this.colDivid1.Caption = "|";
            this.colDivid1.FieldName = "Divid1";
            this.colDivid1.Name = "colDivid1";
            this.colDivid1.Visible = true;
            this.colDivid1.VisibleIndex = 6;
            this.colDivid1.Width = 20;
            // 
            // colMAC1
            // 
            this.colMAC1.FieldName = "MAC1";
            this.colMAC1.Name = "colMAC1";
            this.colMAC1.Visible = true;
            this.colMAC1.VisibleIndex = 7;
            this.colMAC1.Width = 43;
            // 
            // colNPT1
            // 
            this.colNPT1.FieldName = "NPT1";
            this.colNPT1.Name = "colNPT1";
            this.colNPT1.Visible = true;
            this.colNPT1.VisibleIndex = 8;
            this.colNPT1.Width = 37;
            // 
            // colNPP1
            // 
            this.colNPP1.FieldName = "NPP1";
            this.colNPP1.Name = "colNPP1";
            this.colNPP1.Visible = true;
            this.colNPP1.VisibleIndex = 9;
            this.colNPP1.Width = 42;
            // 
            // colDivid2
            // 
            this.colDivid2.Caption = "|";
            this.colDivid2.FieldName = "Divid2";
            this.colDivid2.Name = "colDivid2";
            this.colDivid2.Visible = true;
            this.colDivid2.VisibleIndex = 11;
            this.colDivid2.Width = 22;
            // 
            // colMT1
            // 
            this.colMT1.FieldName = "MT1";
            this.colMT1.Name = "colMT1";
            this.colMT1.Visible = true;
            this.colMT1.VisibleIndex = 10;
            this.colMT1.Width = 34;
            // 
            // colMAC2
            // 
            this.colMAC2.FieldName = "MAC2";
            this.colMAC2.Name = "colMAC2";
            this.colMAC2.Visible = true;
            this.colMAC2.VisibleIndex = 12;
            this.colMAC2.Width = 44;
            // 
            // colNPP2
            // 
            this.colNPP2.FieldName = "NPP2";
            this.colNPP2.Name = "colNPP2";
            this.colNPP2.Visible = true;
            this.colNPP2.VisibleIndex = 13;
            this.colNPP2.Width = 40;
            // 
            // colMT2
            // 
            this.colMT2.FieldName = "MT2";
            this.colMT2.Name = "colMT2";
            this.colMT2.Visible = true;
            this.colMT2.VisibleIndex = 15;
            this.colMT2.Width = 37;
            // 
            // colNPT2
            // 
            this.colNPT2.FieldName = "NPT2";
            this.colNPT2.Name = "colNPT2";
            this.colNPT2.Visible = true;
            this.colNPT2.VisibleIndex = 14;
            this.colNPT2.Width = 51;
            // 
            // colDivid3
            // 
            this.colDivid3.Caption = "|";
            this.colDivid3.FieldName = "Divid3";
            this.colDivid3.Name = "colDivid3";
            this.colDivid3.Visible = true;
            this.colDivid3.VisibleIndex = 16;
            this.colDivid3.Width = 20;
            // 
            // colMFD
            // 
            this.colMFD.FieldName = "MFD";
            this.colMFD.Name = "colMFD";
            this.colMFD.Visible = true;
            this.colMFD.VisibleIndex = 17;
            this.colMFD.Width = 41;
            // 
            // colOBS
            // 
            this.colOBS.FieldName = "OBS";
            this.colOBS.Name = "colOBS";
            this.colOBS.Visible = true;
            this.colOBS.VisibleIndex = 18;
            this.colOBS.Width = 109;
            // 
            // colTurmasID
            // 
            this.colTurmasID.Caption = "Turma";
            this.colTurmasID.FieldName = "Turmas.Descricao";
            this.colTurmasID.Name = "colTurmasID";
            this.colTurmasID.Visible = true;
            this.colTurmasID.VisibleIndex = 1;
            // 
            // Perfil
            // 
            this.Perfil.Caption = "Perfil";
            this.Perfil.ColumnEdit = this.repositoryItemPictureEdit1;
            this.Perfil.FieldName = "Estudantes.Imagens";
            this.Perfil.Name = "Perfil";
            this.Perfil.Visible = true;
            this.Perfil.VisibleIndex = 0;
            this.Perfil.Width = 44;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
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
            // frmMiniPautas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMiniPautas";
            this.Size = new System.Drawing.Size(903, 558);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniPautasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
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
        private System.Windows.Forms.BindingSource miniPautasBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPautasID;
        private DevExpress.XtraGrid.Columns.GridColumn colMAC;
        private DevExpress.XtraGrid.Columns.GridColumn colNPP;
        private DevExpress.XtraGrid.Columns.GridColumn colNPT;
        private DevExpress.XtraGrid.Columns.GridColumn colMT;
        private DevExpress.XtraGrid.Columns.GridColumn colMFD;
        private DevExpress.XtraGrid.Columns.GridColumn colOBS;
        private DevExpress.XtraGrid.Columns.GridColumn colPautas_TrimestresID;
        private DevExpress.XtraGrid.Columns.GridColumn colEstudantesID;
        private DevExpress.XtraGrid.Columns.GridColumn colMAC1;
        private DevExpress.XtraGrid.Columns.GridColumn colNPT1;
        private DevExpress.XtraGrid.Columns.GridColumn colNPP1;
        private DevExpress.XtraGrid.Columns.GridColumn colMT1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAC2;
        private DevExpress.XtraGrid.Columns.GridColumn colNPP2;
        private DevExpress.XtraGrid.Columns.GridColumn colMT2;
        private DevExpress.XtraGrid.Columns.GridColumn colNPT2;
        private DevExpress.XtraGrid.Columns.GridColumn colDivid1;
        private DevExpress.XtraGrid.Columns.GridColumn colDivid2;
        private DevExpress.XtraGrid.Columns.GridColumn colDivid3;
        private DevExpress.XtraGrid.Columns.GridColumn colTurmasID;
        private DevExpress.XtraGrid.Columns.GridColumn Perfil;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
    }
}
