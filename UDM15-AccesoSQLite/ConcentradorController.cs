using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Foundation;
using SQLite;
using UIKit;

namespace ProyectoFinal {
    
    public partial class ConcentradorController : UIViewController {

        /* partial void EliminarRegistro(UIButton sender)
        {
            // throw new NotImplementedException();
            try {
                conexion.Table<Alumno>().Delete(Alumno=>Alumno.Nombre == Nombre);
            } catch (Exception ex) {
                MessageBox("Error:", ex.Message);
            }
        } */

        List<Alumno> Lista = new List<Alumno>();
        UIAlertController Alerta;
        // string Nombre = "";


        public ConcentradorController() : base("ConcentradorController", null) {
        }


        protected ConcentradorController(IntPtr handle) : base(handle) {
        }


        public override void ViewDidLoad() {
            base.ViewDidLoad();
            LlenarTabla(); 
        }


        public void LlenarTabla() {
            Lista.Clear();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "Base.db3");
            var conexion = new SQLiteConnection(path);
            try {
                var elementos = from s in conexion.Table<Alumno>()
                                select s;
                foreach (var fila in elementos) {
                    Lista.Add(new Alumno {
                        Nombre = fila.Nombre,
                        Empresa = fila.Empresa,
                        Fotografia = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fila.Fotografia)
                    });
                }
            } catch (Exception ex) {
                MessageBox("Error:", ex.Message);
            }
            Tabla.Source = null;
            Tabla.Source = new OrigenTabla(Lista, this);
            Tabla.ReloadData(); 
        }


		public void MessageBox(string titulo, string mensaje) {
			Alerta = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
			Alerta.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));
			PresentViewController(Alerta, true, null);
        }
    }
}
