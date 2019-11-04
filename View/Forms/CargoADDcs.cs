using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentAnalyst.View.Forms
{
    public partial class CargoADDcs : Form
    {
        Repositório.CargoDAO cargoDAO = new Repositório.CargoDAO();
        public CargoADDcs()
        {
            InitializeComponent();
        }

        private void MinBTTN_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void CloseBTTN_Click(object sender, EventArgs e)
        {
            Nome.Text = "";
            View.UserControllers.CargosController.Up = false;
            View.UserControllers.CargosController.openform = false;
            Hide();
            
        }

        private void CargoADDcs_VisibleChanged(object sender, EventArgs e)
        {
            if(UserControllers.CargosController.Up == false)
            {
                button1.Text = "SALVAR";
            }
            else
            {
                Nome.Text = Objetos.objAtb.atb0;
                button1.Text = "ATUALIZAR";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Objetos.Cargo cargo = new Objetos.Cargo();
                cargo.Nome = Nome.Text;
                if (UserControllers.CargosController.Up == false)
                {
                    cargoDAO.Insert(cargo);
                }
                else
                {
                    cargoDAO.Update(cargo, Objetos.objAtb.atb0);
                }
                Nome.Text = "";
            }
            catch
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Text = "";
        }
        private bool mouseDown;
        private Point lastLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void CargoADDcs_Load(object sender, EventArgs e)
        {

        }
    }
}
