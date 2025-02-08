namespace IEscolaDesktop.View.Forms
{
    partial class frmBiblioteca_PedidosBuscar
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiblioteca_PedidosBuscar));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.livrosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLivrosID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubTitulo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEdicao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComentarios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLancamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalLancamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodBar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsValidade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPratileira = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPratileiraPosicao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRating = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFavoritar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuantidade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrecoUnitario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalGeral = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEditorasID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEditores = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutoresID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutores = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoriasID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategorias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImagemFrente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImagemVerso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisponibilidade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalGeral1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtTitulo = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPesquisar = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livrosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Controls.Add(this.windowsUIButtonPanel1);
            this.tablePanel1.Controls.Add(this.gridControl1);
            this.tablePanel1.Controls.Add(this.panelControl2);
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 65F)});
            this.tablePanel1.Size = new System.Drawing.Size(638, 563);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // windowsUIButtonPanel1
            // 
            windowsUIButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions3.Image")));
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Selecionar", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, ((short)(1)), -1, false)});
            this.tablePanel1.SetColumn(this.windowsUIButtonPanel1, 0);
            this.windowsUIButtonPanel1.ContentAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.windowsUIButtonPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowsUIButtonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(14, 489);
            this.windowsUIButtonPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.tablePanel1.SetRow(this.windowsUIButtonPanel1, 3);
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(610, 61);
            this.windowsUIButtonPanel1.TabIndex = 9;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            // 
            // gridControl1
            // 
            this.tablePanel1.SetColumn(this.gridControl1, 0);
            this.gridControl1.DataSource = this.livrosBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(13, 73);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.tablePanel1.SetRow(this.gridControl1, 2);
            this.gridControl1.Size = new System.Drawing.Size(612, 412);
            this.gridControl1.TabIndex = 0;
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
            this.colEdicao,
            this.colDescricao,
            this.colComentarios,
            this.colLancamento,
            this.colLocalLancamento,
            this.colCodBar,
            this.colIsValidade,
            this.colPratileira,
            this.colPratileiraPosicao,
            this.colRating,
            this.colFavoritar,
            this.colAno,
            this.colQuantidade,
            this.colPrecoUnitario,
            this.colTotalGeral,
            this.colEditorasID,
            this.colEditores,
            this.colAutoresID,
            this.colAutores,
            this.colCategoriasID,
            this.colCategorias,
            this.colImagemFrente,
            this.colImagemVerso,
            this.colDisponibilidade,
            this.colTotalGeral1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colLivrosID
            // 
            this.colLivrosID.Caption = "Código";
            this.colLivrosID.FieldName = "LivrosID";
            this.colLivrosID.Name = "colLivrosID";
            this.colLivrosID.Visible = true;
            this.colLivrosID.VisibleIndex = 0;
            this.colLivrosID.Width = 62;
            // 
            // colTitulo
            // 
            this.colTitulo.FieldName = "Titulo";
            this.colTitulo.Name = "colTitulo";
            this.colTitulo.Visible = true;
            this.colTitulo.VisibleIndex = 1;
            this.colTitulo.Width = 88;
            // 
            // colSubTitulo
            // 
            this.colSubTitulo.FieldName = "SubTitulo";
            this.colSubTitulo.Name = "colSubTitulo";
            this.colSubTitulo.Visible = true;
            this.colSubTitulo.VisibleIndex = 2;
            this.colSubTitulo.Width = 87;
            // 
            // colISBN
            // 
            this.colISBN.FieldName = "ISBN";
            this.colISBN.Name = "colISBN";
            this.colISBN.Visible = true;
            this.colISBN.VisibleIndex = 3;
            this.colISBN.Width = 44;
            // 
            // colEdicao
            // 
            this.colEdicao.FieldName = "Edicao";
            this.colEdicao.Name = "colEdicao";
            this.colEdicao.Width = 56;
            // 
            // colDescricao
            // 
            this.colDescricao.Caption = "Descrição";
            this.colDescricao.FieldName = "Descricao";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.Visible = true;
            this.colDescricao.VisibleIndex = 4;
            this.colDescricao.Width = 77;
            // 
            // colComentarios
            // 
            this.colComentarios.FieldName = "Comentarios";
            this.colComentarios.Name = "colComentarios";
            // 
            // colLancamento
            // 
            this.colLancamento.FieldName = "Lancamento";
            this.colLancamento.Name = "colLancamento";
            this.colLancamento.Width = 57;
            // 
            // colLocalLancamento
            // 
            this.colLocalLancamento.FieldName = "LocalLancamento";
            this.colLocalLancamento.Name = "colLocalLancamento";
            // 
            // colCodBar
            // 
            this.colCodBar.FieldName = "CodBar";
            this.colCodBar.Name = "colCodBar";
            // 
            // colIsValidade
            // 
            this.colIsValidade.FieldName = "IsValidade";
            this.colIsValidade.Name = "colIsValidade";
            // 
            // colPratileira
            // 
            this.colPratileira.FieldName = "Pratileira";
            this.colPratileira.Name = "colPratileira";
            // 
            // colPratileiraPosicao
            // 
            this.colPratileiraPosicao.FieldName = "PratileiraPosicao";
            this.colPratileiraPosicao.Name = "colPratileiraPosicao";
            // 
            // colRating
            // 
            this.colRating.FieldName = "Rating";
            this.colRating.Name = "colRating";
            // 
            // colFavoritar
            // 
            this.colFavoritar.FieldName = "Favoritar";
            this.colFavoritar.Name = "colFavoritar";
            // 
            // colAno
            // 
            this.colAno.FieldName = "Ano";
            this.colAno.Name = "colAno";
            // 
            // colQuantidade
            // 
            this.colQuantidade.DisplayFormat.FormatString = "n";
            this.colQuantidade.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQuantidade.FieldName = "Quantidade";
            this.colQuantidade.Name = "colQuantidade";
            this.colQuantidade.Visible = true;
            this.colQuantidade.VisibleIndex = 5;
            this.colQuantidade.Width = 62;
            // 
            // colPrecoUnitario
            // 
            this.colPrecoUnitario.Caption = "P. Unitário";
            this.colPrecoUnitario.FieldName = "PrecoUnitario";
            this.colPrecoUnitario.Name = "colPrecoUnitario";
            this.colPrecoUnitario.Visible = true;
            this.colPrecoUnitario.VisibleIndex = 6;
            this.colPrecoUnitario.Width = 76;
            // 
            // colTotalGeral
            // 
            this.colTotalGeral.FieldName = "TotalGeral";
            this.colTotalGeral.Name = "colTotalGeral";
            this.colTotalGeral.OptionsColumn.ReadOnly = true;
            // 
            // colEditorasID
            // 
            this.colEditorasID.FieldName = "EditorasID";
            this.colEditorasID.Name = "colEditorasID";
            // 
            // colEditores
            // 
            this.colEditores.FieldName = "Editores";
            this.colEditores.Name = "colEditores";
            // 
            // colAutoresID
            // 
            this.colAutoresID.FieldName = "AutoresID";
            this.colAutoresID.Name = "colAutoresID";
            // 
            // colAutores
            // 
            this.colAutores.FieldName = "Autores";
            this.colAutores.Name = "colAutores";
            // 
            // colCategoriasID
            // 
            this.colCategoriasID.FieldName = "CategoriasID";
            this.colCategoriasID.Name = "colCategoriasID";
            // 
            // colCategorias
            // 
            this.colCategorias.FieldName = "Categorias";
            this.colCategorias.Name = "colCategorias";
            // 
            // colImagemFrente
            // 
            this.colImagemFrente.FieldName = "ImagemFrente";
            this.colImagemFrente.Name = "colImagemFrente";
            // 
            // colImagemVerso
            // 
            this.colImagemVerso.FieldName = "ImagemVerso";
            this.colImagemVerso.Name = "colImagemVerso";
            // 
            // colDisponibilidade
            // 
            this.colDisponibilidade.FieldName = "Disponibilidade";
            this.colDisponibilidade.Name = "colDisponibilidade";
            // 
            // colTotalGeral1
            // 
            this.colTotalGeral1.Caption = "Total";
            this.colTotalGeral1.DisplayFormat.FormatString = "n";
            this.colTotalGeral1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalGeral1.FieldName = "TotalGeral";
            this.colTotalGeral1.Name = "colTotalGeral1";
            this.colTotalGeral1.Visible = true;
            this.colTotalGeral1.VisibleIndex = 7;
            this.colTotalGeral1.Width = 88;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl2, 0);
            this.panelControl2.Controls.Add(this.txtTitulo);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(13, 12);
            this.panelControl2.Name = "panelControl2";
            this.tablePanel1.SetRow(this.panelControl2, 0);
            this.panelControl2.Size = new System.Drawing.Size(612, 22);
            this.panelControl2.TabIndex = 1;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(59, 5);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(80, 13);
            this.txtTitulo.TabIndex = 3;
            this.txtTitulo.Text = "Selecionar Livro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pedidos: ";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.IconColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(562, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(48, 18);
            this.btnClose.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Controls.Add(this.txtPesquisar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(13, 38);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 1);
            this.panelControl1.Size = new System.Drawing.Size(612, 31);
            this.panelControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(392, 4);
            this.txtPesquisar.Name = "txtPesquisar";
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.txtPesquisar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtPesquisar.Properties.NullValuePrompt = "Pesquise aqui";
            this.txtPesquisar.Size = new System.Drawing.Size(214, 22);
            this.txtPesquisar.TabIndex = 0;
            // 
            // frmBiblioteca_PedidosBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmBiblioteca_PedidosBuscar";
            this.Size = new System.Drawing.Size(638, 563);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livrosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPesquisar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn colLivrosID;
        private DevExpress.XtraGrid.Columns.GridColumn colTitulo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubTitulo;
        private DevExpress.XtraGrid.Columns.GridColumn colISBN;
        private DevExpress.XtraGrid.Columns.GridColumn colEdicao;
        private DevExpress.XtraGrid.Columns.GridColumn colDescricao;
        private DevExpress.XtraGrid.Columns.GridColumn colComentarios;
        private DevExpress.XtraGrid.Columns.GridColumn colLancamento;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalLancamento;
        private DevExpress.XtraGrid.Columns.GridColumn colCodBar;
        private DevExpress.XtraGrid.Columns.GridColumn colIsValidade;
        private DevExpress.XtraGrid.Columns.GridColumn colPratileira;
        private DevExpress.XtraGrid.Columns.GridColumn colPratileiraPosicao;
        private DevExpress.XtraGrid.Columns.GridColumn colRating;
        private DevExpress.XtraGrid.Columns.GridColumn colFavoritar;
        private DevExpress.XtraGrid.Columns.GridColumn colAno;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantidade;
        private DevExpress.XtraGrid.Columns.GridColumn colPrecoUnitario;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalGeral;
        private DevExpress.XtraGrid.Columns.GridColumn colEditorasID;
        private DevExpress.XtraGrid.Columns.GridColumn colEditores;
        private DevExpress.XtraGrid.Columns.GridColumn colAutoresID;
        private DevExpress.XtraGrid.Columns.GridColumn colAutores;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoriasID;
        private DevExpress.XtraGrid.Columns.GridColumn colCategorias;
        private DevExpress.XtraGrid.Columns.GridColumn colImagemFrente;
        private DevExpress.XtraGrid.Columns.GridColumn colImagemVerso;
        private DevExpress.XtraGrid.Columns.GridColumn colDisponibilidade;
        private DevExpress.XtraEditors.LabelControl txtTitulo;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ButtonEdit txtPesquisar;
        public System.Windows.Forms.BindingSource livrosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalGeral1;
        private System.Windows.Forms.Button button1;
    }
}
