// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ProyectoFinal
{
    [Register ("DetalleController")]
    partial class DetalleController
    {
        [Outlet]
        UIKit.UIImageView Imagen { get; set; }


        [Outlet]
        UIKit.UILabel lblCorreo { get; set; }


        [Outlet]
        UIKit.UILabel lblEmpresa { get; set; }


        [Outlet]
        UIKit.UILabel lblNombre { get; set; }


        [Outlet]
        UIKit.UILabel lblPuesto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnEliminar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCelular { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnEliminar != null) {
                btnEliminar.Dispose ();
                btnEliminar = null;
            }

            if (Imagen != null) {
                Imagen.Dispose ();
                Imagen = null;
            }

            if (lblCelular != null) {
                lblCelular.Dispose ();
                lblCelular = null;
            }

            if (lblCorreo != null) {
                lblCorreo.Dispose ();
                lblCorreo = null;
            }

            if (lblEmpresa != null) {
                lblEmpresa.Dispose ();
                lblEmpresa = null;
            }

            if (lblNombre != null) {
                lblNombre.Dispose ();
                lblNombre = null;
            }

            if (lblPuesto != null) {
                lblPuesto.Dispose ();
                lblPuesto = null;
            }
        }
    }
}