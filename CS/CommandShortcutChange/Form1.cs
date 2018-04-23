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
            
            // Register a new shortcut for the RichEditControl without bars 
            NormalKeyboardHandler handler1 = GetKeyboardHandler(richEditControl1);
            if (handler1 != null){
                RemoveOldShortcut(handler1);
                AssignNewShortcut(handler1);
            }
 
            // Register a new shortcut for the RichEditControl with bars
            NormalKeyboardHandler handler2 = GetKeyboardHandler(richEditControl2);
            if (handler2 != null)
                RemoveOldShortcut(handler2);

            foreach (DevExpress.XtraBars.BarItem item in barManager1.Items){
                if (item.GetType() == typeof(DevExpress.XtraRichEdit.UI.ToggleShowWhitespaceItem))
                    item.ItemShortcut = new DevExpress.XtraBars.BarShortcut((Keys.Control | Keys.G));            
            }
        }

        #region KeyboardHandlers
        private NormalKeyboardHandler GetKeyboardHandler(RichEditControl control)
        {
            MyKeyboardService myKeyboardService = new MyKeyboardService(control);
            return myKeyboardService.NormalKeyboardHandler;
        }
        
        public void AssignNewShortcut(NormalKeyboardHandler handler)
        {
            AssignNewShortcut(new RichEditKeyHashProvider(RichEditViewType.PrintLayout), handler);
            AssignNewShortcut(new RichEditKeyHashProvider(RichEditViewType.Draft), handler);
            AssignNewShortcut(new RichEditKeyHashProvider(RichEditViewType.Simple), handler);
        }

        public void RemoveOldShortcut(NormalKeyboardHandler handler)
        {
            RemoveOldShortcut(new RichEditKeyHashProvider(RichEditViewType.PrintLayout), handler);
            RemoveOldShortcut(new RichEditKeyHashProvider(RichEditViewType.Draft), handler);
            RemoveOldShortcut(new RichEditKeyHashProvider(RichEditViewType.Simple), handler);
        }
        public void AssignNewShortcut(RichEditKeyHashProvider hashProvider, NormalKeyboardHandler normalHandler)
        {
            normalHandler.RegisterKeyHandler(hashProvider, Keys.G, Keys.Control, RichEditCommandId.ToggleShowWhitespace);
        }

        public void RemoveOldShortcut(RichEditKeyHashProvider hashProvider, NormalKeyboardHandler normalHandler)
        {
            normalHandler.UnregisterKeyHandler(hashProvider, Keys.D8, Keys.Control | Keys.Shift);
        }
        #endregion KeyboardHandlers
        
        // Prevent BarManager from capturing shortcut keys when its RichEditControl is not active
        private void barManager1_ShortcutItemClick(object sender, DevExpress.XtraBars.ShortcutItemClickEventArgs e)
        {
            e.Cancel = !(FindForm().ActiveControl == richEditControl2);
        }
    }
}