using DevExpress.XtraBars.Docking2010;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository.Biblioteca;
using IEscolaEntity.Models.Biblioteca;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmBiblioteca_PedidosBuscar : DevExpress.XtraEditors.XtraUserControl
    {
        ILivros livros;
        List<Livros> DataOriginalList;
        Livros Livros;

        public frmBiblioteca_PedidosBuscar()
        {
            InitializeComponent();
            livros = new LivrosRepository();
            Livros = new Livros();

            txtPesquisar.EditValueChanged += delegate { LeituraFilter(); };
            txtPesquisar.ButtonClick += delegate { LeituraInicial(); };

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            btnClose.Click += BtnClose_Click;

            LeituraInicial();
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            GetLivros();
        }

        public Livros GetLivros() {

            Livros = livrosBindingSource.Current as Livros;
            return Livros;
        }

        private void WindowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            button1.DialogResult = DialogResult.OK;
        }

        private void LeituraFilter()
        {
            var data = DataOriginalList.FindAll(x => x.Descricao.ToUpper().Contains(txtPesquisar.Text.ToUpper()));
            livrosBindingSource.DataSource = data;
        }

        private async void LeituraInicial()
        {
            DataOriginalList = await livros.GetAll();
            livrosBindingSource.DataSource = DataOriginalList;
        }
    }
}
