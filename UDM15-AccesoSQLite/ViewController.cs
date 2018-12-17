using System;
using System.IO;
using CoreLocation;
using Foundation;
using SQLite;
using UIKit;

namespace ProyectoFinal
{
    public partial class ViewController : UIViewController
    {
        string ArchivoImagen, ruta;
        UIAlertController Alerta;
        UIImagePickerController SeleccionadorImagen;


        protected ViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Visor.Text = "";
            var Carpeta = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            foreach(var archivos in Carpeta) {
                Visor.Text += archivos + Environment.NewLine;
            }

            SeleccionadorImagen = new UIImagePickerController();
            SeleccionadorImagen.FinishedPickingMedia += SeleccionImagen;
            SeleccionadorImagen.Canceled += ImagenCancelada;
            if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera)) {
                SeleccionadorImagen.SourceType = UIImagePickerControllerSourceType.Camera;
            } else {
				SeleccionadorImagen.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
            }
            btnFoto.TouchUpInside += delegate {
                PresentViewController(SeleccionadorImagen, true, null);    
            };

            // código de SQLite
            var rutabase = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            rutabase = Path.Combine(rutabase, "Base.db3");
            var conexion = new SQLiteConnection(rutabase);
            conexion.CreateTable<Alumno>();
            btnGuardar.TouchUpInside += delegate {
                try {
                    var Insertar = new Alumno();
                    Insertar.Nombre = txtNombre.Text;
                    Insertar.Puesto = txtPuesto.Text;
                    Insertar.Empresa = txtEmpresa.Text;
                    Insertar.Correo = txtCorreo.Text;
                    Insertar.Celular = txtCelular.Text;
                    Insertar.Fotografia = txtNombre.Text + ".jpg";

                    /* CLLocationManager locationManager = new CLLocationManager();
                    locationManager.RequestWhenInUseAuthorization();
                    var locator = CrossGeoLocator.current; */


                    conexion.Insert(Insertar);
                    txtNombre.Text = "";
                    txtPuesto.Text = "";
                    txtCorreo.Text = "";
                    txtEmpresa.Text = "";
                    txtCelular.Text = "";
                    Imagen.Image = null;

                    MessageBox("Guardado correctamente", "SQLite");
                } catch (Exception ex) {
					MessageBox("Error", ex.Message);
				}
            };
        }


        public void MessageBox(string titulo, string mensaje) {
            Alerta = UIAlertController.Create(titulo, mensaje, UIAlertControllerStyle.Alert);
            Alerta.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));
            PresentViewController(Alerta, true, null); 
        }


        public void SeleccionImagen(object sender, UIImagePickerMediaPickedEventArgs e) {
            try {
                var ImagenSeleccionada = e.Info[UIImagePickerController.OriginalImage] as UIImage;
                var rutaImagen = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), txtNombre.Text + ".jpg");

                if (File.Exists(rutaImagen)) {
                    MessageBox("Aviso:", "Imagen ya existente");
                } else {
                    ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    ArchivoImagen = Path.Combine(ruta, txtNombre.Text + ".jpg");
                    NSError error;
                    var DatosImagen = ImagenSeleccionada.AsJPEG();
                    DatosImagen.Save(ArchivoImagen, false, out error);
                    Imagen.Image = UIImage.FromFile(ArchivoImagen);
                    SeleccionadorImagen.DismissViewController(true, null);
                }
            } catch (Exception ex) {
                MessageBox("Error", ex.Message);
                SeleccionadorImagen.DismissViewController(true, null);
            }
        }


        public void ImagenCancelada(object sender, EventArgs e) {
            SeleccionadorImagen.DismissViewController(true, null); 
        }
    }
}
