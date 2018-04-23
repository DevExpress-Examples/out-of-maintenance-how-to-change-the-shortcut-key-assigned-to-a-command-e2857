using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Keyboard;
using DevExpress.Services.Implementation;
using DevExpress.XtraRichEdit.Services.Implementation;
using DevExpress.Services;

namespace CommandShortcutChange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            #region #assignshortcutkey
            // Register a new shortcut for the RichEditControl without bars 
            richEditControl1.RemoveShortcutKey(Keys.Control | Keys.Shift, Keys.D8);
            richEditControl1.AssignShortcutKeyToCommand(Keys.Control, Keys.G, RichEditCommandId.ToggleShowWhitespace);

            // Register a new shortcut for the RichEditControl with bars
            richEditControl2.RemoveShortcutKey(Keys.Control | Keys.Shift, Keys.D8);
            foreach (DevExpress.XtraBars.BarItem item in barManager1.Items)
            {
                if (item.GetType() == typeof(DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem))
                    item.ItemShortcut = new DevExpress.XtraBars.BarShortcut((Keys.Control | Keys.G));
            }
            #endregion #assignshortcutkey

        }

        private void barManager1_ShortcutItemClick(object sender, DevExpress.XtraBars.ShortcutItemClickEventArgs e)
        {
            e.Cancel = !(FindForm().ActiveControl == richEditControl2);
        }
    }
}