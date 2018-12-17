using System;
using System.IO;
using SQLite;
using UIKit;

namespace ProyectoFinal
{
    public partial class DetalleController : UIViewController
    {
        public string Indice { get; set; }
        SQLiteConnection conexion;
        UIAlertController Alerta;


        public DetalleController(string indice) : base("DetalleController", null) {
            Indice = indice;
        }


		protected DetalleController(IntPtr handle) : base(handle) {
		}


        public override void ViewDidLoad() {
            base.ViewDidLoad();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "Base.db3");
            // var conexion = new SQLiteConnection(path);
            conexion = new SQLiteConnection(path);
            var elementos = from s in conexion.Table<Alumno>()
                            where s.Nombre == Indice
                            select s;
            foreach (var fila in elementos) {
                lblNombre.Text = fila.Nombre;
                lblPuesto.Text = fila.Puesto;
                lblEmpresa.Text = fila.Empresa;
                lblCorreo.Text = fila.Correo;
                lblCelular.Text = fila.Celular;
                Imagen.Image = UIImage.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fila.Fotografia));
            }

            btnEliminar.TouchUpInside += delegate {
                try {
                    conexion.Table<Alumno>().Delete(Alumno => Alumno.Nombre == lblNombre.Text);
                } catch (Exception ex) {
                    MessageBox("Error:", ex.Message);
                }
            };
        }


        public void MessageBox(string titulo, string mensaje) {
            Alerta = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
            Alerta.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));
            PresentViewController(Alerta, true, null);
        }
    }
}