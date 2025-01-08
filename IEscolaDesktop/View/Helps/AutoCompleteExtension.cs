using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Helps
{
    public static class AutoCompleteExtension
    {
        public static void Autocomplete(TextEdit edit, List<string> listF)
        {
            if (listF.Count == 0)
                return;
            else
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                foreach (var item in listF)
                {
                    collection.Add(item.ToString());
                }

                edit.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
                edit.Properties.AdvancedModeOptions.AutoCompleteMode = TextEditAutoCompleteMode.SuggestAppend;
                edit.Properties.AdvancedModeOptions.AutoCompleteSource = AutoCompleteSource.CustomSource;
                edit.Properties.AdvancedModeOptions.AutoCompleteCustomSource = collection;
            }
        }

        public static void Autocomplete(ButtonEdit edit, List<string> listF)
        {
            if (listF.Count == 0)
                return;
            else
            {
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

                foreach (var item in listF)
                {
                    collection.Add(item.ToString());
                }

                edit.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
                edit.Properties.AdvancedModeOptions.AutoCompleteMode = TextEditAutoCompleteMode.SuggestAppend;
                edit.Properties.AdvancedModeOptions.AutoCompleteSource = AutoCompleteSource.CustomSource;
                edit.Properties.AdvancedModeOptions.AutoCompleteCustomSource = collection;
            }
        }
    }
}
