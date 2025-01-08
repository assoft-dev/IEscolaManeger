using Guna.UI2.WinForms;
using IEscolaDesktop.View.Helps;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Desktop
{
    public static class GlobalthemeConfig
    {
        public static ThemeEscolas themeEscolas1;
        public static bool Theme(Control control)
        {
            try
            {
                var painel = FindControls<Panel>(control);
                var painelGuna = FindControls<Guna2Panel>(control);

                var label = FindControls<Label>(control);

                var textbox = FindControls<TextBox>(control);
                var textboxGuna = FindControls<Guna2TextBox>(control);

                var buttom = FindControls<Button>(control);

                if (themeEscolas1 == ThemeEscolas.Escuro)
                {           
                    //Painel
                    foreach (var pan in painel)
                    {
                        pan.BackColor = Color.FromArgb(7, 18, 36);
                        pan.ForeColor = Color.Transparent;

                        if (pan.Name.Contains("Footer"))
                        {
                            pan.BackColor = Color.FromArgb(182, 0, 19);
                            pan.ForeColor = Color.Transparent;
                        }

                        if (pan.Name.Contains("Painelplace"))
                        {
                            pan.BackColor = Color.FromArgb(28, 36, 50);
                        }
                    }

                    //Painel-Guna
                    foreach (var pan in painelGuna)
                    {
                        pan.FillColor = Color.White;
                    }

                    //Label
                    foreach (var lbl in label)
                    {
                        lbl.ForeColor = Color.White;
                        lbl.BackColor = Color.Transparent;

                        if (lbl.Name.Contains("Place"))
                        {
                            lbl.ForeColor = Color.FromArgb(182, 0, 19);
                            lbl.BackColor = Color.FromArgb(28, 36, 50);
                        }
                        if (lbl.Name.Contains("DireitosReservados"))
                        {
                            lbl.ForeColor = Color.Transparent;
                            lbl.BackColor = Color.White;
                        }
                    }

                    //buttom
                    foreach (var lbl in buttom)
                    {
                        lbl.ForeColor = Color.White;
                        lbl.BackColor = Color.FromArgb(182, 0,19);

                        if (lbl.Name.Contains("PasswordView"))
                        {
                            lbl.ForeColor = Color.Transparent;
                            lbl.BackColor = Color.Transparent;
                        }

                        if (lbl.Name.Contains("EmailSend"))
                        {
                            lbl.BackColor = Color.Transparent;
                            lbl.ForeColor = Color.FromArgb(21, 127, 200);
                        }
                    }

                    //TextBox
                    foreach (var lbl in textbox)
                    {
                        lbl.ForeColor = Color.White;
                        lbl.BackColor = Color.FromArgb(28, 36, 50);
                    }

                    //TextBox Guna
                    foreach (var lbl in textboxGuna)
                    {
                        lbl.ForeColor = Color.Black;
                        lbl.FillColor = Color.White;
                        lbl.PlaceholderForeColor = Color.Silver;
                    }
                }
                else
                {
                    control.BackColor = Color.White;

                    //Painel
                    foreach (var pan in painel)
                    {
                        pan.BackColor = Color.White;
                        pan.ForeColor = Color.Transparent;

                        // Login
                        if (pan.Name.Contains("Footer"))
                        {
                            pan.BackColor = Color.FromArgb(182, 0, 19);
                            pan.ForeColor = Color.Transparent;
                        }

                        if (pan.Name.Contains("Painelplace"))
                        {
                            pan.BackColor = Color.FromArgb(28, 36, 50);
                        }
                    }

                    //Painel-Guna
                    foreach (var pan in painelGuna)
                    {
                        pan.FillColor = Color.White;
                    }

                    //Label
                    foreach (var lbl in label)
                    {
                        lbl.ForeColor = Color.Black;
                        lbl.BackColor = Color.Transparent;

                        if (lbl.Name.Contains("Place"))
                        {
                            lbl.ForeColor = Color.FromArgb(182, 0, 19);
                            lbl.BackColor = Color.FromArgb(28, 36, 50);
                        }

                        if (lbl.Name.Contains("DireitosReservados"))
                        {
                            lbl.ForeColor = Color.White;
                            lbl.BackColor = Color.Transparent;
                        }
                    }

                    //buttom
                    foreach (var lbl in buttom)
                    {
                        lbl.ForeColor = Color.White;
                        lbl.BackColor = Color.FromArgb(182, 0, 19);

                        if (lbl.Name.Contains("PasswordView"))
                        {
                            lbl.ForeColor = Color.Transparent;
                            lbl.BackColor = Color.Transparent;
                        }
                        if (lbl.Name.Contains("EmailSend"))
                        {
                            lbl.BackColor = Color.Transparent;
                            lbl.ForeColor = Color.FromArgb(21, 127, 200);
                        }
                    }

                    //TextBox
                    foreach (var lbl in textbox)
                    {
                        lbl.ForeColor = Color.White;
                        lbl.BackColor = Color.FromArgb(28, 36, 50);
                    }

                    //TextBox Guna
                    foreach (var lbl in textboxGuna)
                    {
                        lbl.ForeColor = Color.Black;
                        lbl.FillColor = Color.White;
                        lbl.PlaceholderForeColor = Color.Silver;
                    }
                }
                return true;
            }
            catch (System.Exception exe)
            {
                GlobalException.CapturarError(exe);
                return false;
            }
        }

        private static IEnumerable<T> FindControls<T>(Control control) where T : Control
        {
            // we can't cast here because some controls in here will most likely not be <T>
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => FindControls<T>(ctrl))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == typeof(T)).Cast<T>();
        }


       


    }

   
    public enum ThemeEscolas
    {
        Escuro = 1,
        Claro = 2,
    }

    
}
