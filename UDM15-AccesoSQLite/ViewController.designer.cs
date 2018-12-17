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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton btnFoto { get; set; }


        [Outlet]
        UIKit.UIButton btnGuardar { get; set; }


        [Outlet]
        UIKit.UIImageView Imagen { get; set; }


        [Outlet]
        UIKit.UITextField txtCorreo { get; set; }


        [Outlet]
        UIKit.UITextField txtEmpresa { get; set; }


        [Outlet]
        UIKit.UITextField txtNombre { get; set; }


        [Outlet]
        UIKit.UITextField txtPuesto { get; set; }


        [Outlet]
        UIKit.UITextView Visor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCelular { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLatitud { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLongitud { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnFoto != null) {
                btnFoto.Dispose ();
                btnFoto = null;
            }

            if (btnGuardar != null) {
                btnGuardar.Dispose ();
                btnGuardar = null;
            }

            if (Imagen != null) {
                Imagen.Dispose ();
                Imagen = null;
            }

            if (txtCelular != null) {
                txtCelular.Dispose ();
                txtCelular = null;
            }

            if (txtCorreo != null) {
                txtCorreo.Dispose ();
                txtCorreo = null;
            }

            if (txtEmpresa != null) {
                txtEmpresa.Dispose ();
                txtEmpresa = null;
            }

            if (txtLatitud != null) {
                txtLatitud.Dispose ();
                txtLatitud = null;
            }

            if (txtLongitud != null) {
                txtLongitud.Dispose ();
                txtLongitud = null;
            }

            if (txtNombre != null) {
                txtNombre.Dispose ();
                txtNombre = null;
            }

            if (txtPuesto != null) {
                txtPuesto.Dispose ();
                txtPuesto = null;
            }

            if (Visor != null) {
                Visor.Dispose ();
                Visor = null;
            }
        }
    }
}