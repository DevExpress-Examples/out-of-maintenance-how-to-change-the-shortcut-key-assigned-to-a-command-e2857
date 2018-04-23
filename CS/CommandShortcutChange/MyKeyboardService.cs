using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Services.Implementation;
using DevExpress.XtraRichEdit.Keyboard;

namespace CommandShortcutChange
{
    public class MyKeyboardService : RichEditKeyboardHandlerService
    {
        public MyKeyboardService(RichEditControl control)
            :base(control){
        }

        public NormalKeyboardHandler NormalKeyboardHandler
        {
            get
            {
                return Handler as NormalKeyboardHandler;
            }
        }
    }
}
