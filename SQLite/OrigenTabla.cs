using System.Collections.Generic;
using System.Drawing;
// using System.IO;
using Foundation;
using SQLite;
using UIKit;
using System;
// namespace SQLite

namespace ProyectoFinal {
    
    public class OrigenTabla : UITableViewSource {
        public string Nombre;
        List<Alumno> ElementosTabla;
        string IDCelda = "Celda";
        UIViewController Controlador;


        public OrigenTabla(List<Alumno> elementos, UIViewController controlador) {
            ElementosTabla = elementos;
            Controlador = controlador;
        }


        public UIImage AjustarImagen(UIImage origenImagen, float ancho, float alto) {
            UIGraphics.BeginImageContext(new SizeF(ancho, alto));
            origenImagen.Draw(new RectangleF(0, 0, ancho, alto));
            var destinoImagen = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return destinoImagen;
        }


        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
            var celda = tableView.DequeueReusableCell(IDCelda);
            string elemento = ElementosTabla[indexPath.Row].Nombre;
            string detalle = ElementosTabla[indexPath.Row].Empresa;
            if (celda == null) {
                celda = new UITableViewCell(UITableViewCellStyle.Subtitle, IDCelda);
            }
            celda.TextLabel.Text = elemento;
            celda.DetailTextLabel.Text = detalle;
            celda.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            celda.ImageView.Image = AjustarImagen(UIImage.FromBundle(ElementosTabla[indexPath.Row].Fotografia), 80, 80);
            return celda;
        }


        public override nint RowsInSection(UITableView tableview, nint section) {
            return ElementosTabla.Count;
        }


        public override void RowSelected(UITableView tableView, NSIndexPath indexPath) {
            Nombre = ElementosTabla[indexPath.Row].Nombre;
            var detalle = Controlador.Storyboard.InstantiateViewController("DetalleController") as DetalleController;
            detalle.Indice = Nombre;
            Controlador.PresentViewControllerAsync(detalle, true);
        }
    }
}
