//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace shopTests
//{
//    public interface IDialogService
//    {
//        void ShowMessageBox(...);

//        ...
//    }

//    public class FakeDialog
//    {
//        private IDialogService dialogService;

//        public FakeDialog(IDialogService dialogService)
//        {
//            this.dialogService = dialogService;
//        }

//        public void SomeLogic()
//        {
//            ...
//            if (ok)
//            {
//                this.dialogService.ShowMessageBox("SUCCESS", ...);
//            }
//            else
//            {
//                this.dialogService.ShowMessageBox("SHIT HAPPENS...", ...);
//            }
//        }
//    }
//}