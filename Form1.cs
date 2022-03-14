using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LaboratorioNo7
{
    public partial class Form1 : Form
    {

        List<CasasPropietario> regis = new List<CasasPropietario>();
       
        List<Propietario> pers = new List<Propietario>();
       
        List<Propiedad> Casa = new List<Propiedad>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pers.Count; ++i)
            {
                CasasPropietario registro2 = new CasasPropietario();

                for (int j = 0; j < Casa.Count; j++)
                {
                    if (pers[i].dpi == Casa[j].dpi)
                    {
                        registro2.Nombre = pers[i].Nombre;
                        registro2.Apellido= pers[i].Apellido;
                        registro2.NumeroCasa = Casa[j].NumeroCasa;
                        registro2.Cuota= Casa[j].Cuota;
                    }

                }
                regis.Add(registro2);
               
                dgtPropietario.DataSource = null;
                
                dgtPropietario.Refresh();

                dgtPropietario.DataSource = regis;
               
                dgtPropietario.Refresh();
            }
        }

        private void LeerCliente()
        {
            FileStream stream = new FileStream("ArchivoPropietario.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1) 
            {
               Propietario persona1 = new Propietario();
                persona1.dpi = reader.ReadLine();
                persona1.Nombre = reader.ReadLine();
                persona1.Apellido = reader.ReadLine();

                pers.Add(persona1);
            }

            reader.Close();
        }

        private void LeerPropiedad()
        {
            FileStream stream = new FileStream("ArchivoPropiedad.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1) 
            {
                Propiedad casa1 = new Propiedad();
                casa1.NumeroCasa = reader.ReadLine();
                casa1.dpi = reader.ReadLine();
                casa1.Cuota = Convert.ToInt32(reader.ReadLine());

                Casa.Add(casa1);
            }

            reader.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LeerCliente();
            LeerPropiedad();
        }

        private void btnOrdenarCuota_Click(object sender, EventArgs e)
        {
            regis = regis.OrderByDescending(n => n.Cuota).ToList();
           
            dgtPropietario.DataSource = null;
           
            dgtPropietario.Refresh();

            dgtPropietario.DataSource = regis;
            dgtPropietario.Refresh();
        }

        private void btnCuotas3_Click(object sender, EventArgs e)
        {
            int registrosOrden = regis.Count();
  
           label4.Text = "Cuotas más bajas: " + regis[registrosOrden - 1].Cuota.ToString() + " , " + regis[registrosOrden - 2].Cuota.ToString() + " , " + regis[registrosOrden - 3].Cuota.ToString();

            label6.Text = "Cuotas más altas: " + regis[0].Cuota.ToString() + " , " + regis[1].Cuota.ToString() + " , " + regis[2].Cuota.ToString();

        }

        private void btnPropAlto_Click(object sender, EventArgs e)
        {

           CasasPropietario mostrar2 = new CasasPropietario();
          
                for (int j = 0; j < regis.Count; j++)
                {
                    int mayorCuota = regis.Max(u => u.Cuota);
                    label8.Text = "La mayor cuota es de:  " + mayorCuota.ToString();
                    if (mayorCuota == regis[j].Cuota)
                    {
                        label9.Text = "del propietario:  " +  regis[j].Nombre;
                    }
                }
               
              
        }
    }
}
