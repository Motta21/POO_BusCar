using POO_Buscarr.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_Buscarr.view

{
    public partial class TelaPrincipalAdministrador : Form
    {
    private int _userId;
    public TelaPrincipalAdministrador(int userId)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        _userId = userId;

    }

}
}
