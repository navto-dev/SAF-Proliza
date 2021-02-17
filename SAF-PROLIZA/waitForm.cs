using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAF_PROLIZA
{
    public partial class waitForm : Form
    {
        public Action Worker { get; set; }
        public waitForm(Action worker, string titulo, string descripcion)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;
            lblDescription.Text = descripcion;
            lblTitulo.Text = titulo;
            lblDescription.SelectionStart = lblDescription.SelectionLength;
            this.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
