using System.Windows.Forms;

namespace COIME
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
            suggestCollection = new SuggestCollection(textBox);
            autocompleteMenu.SetAutocompleteItems(suggestCollection);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
                autocompleteMenu.Show(textBox, true);
        }
    }
}
