#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

#endregion

namespace RAA_Level02_Module03_Skills
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // put any code needed for the form here

            List<SpatialElement> roomList = new List<SpatialElement>();

            FilteredElementCollector colRooms = new FilteredElementCollector(doc);
            colRooms.OfCategory(BuiltInCategory.OST_Rooms);

            roomList = colRooms.Cast<SpatialElement>().ToList();

            //List<DataClass2> dataList = new List<DataClass2>();
            //dataList.Add(new DataClass2("1111", "2222", true, "4444"));
            //dataList.Add(new DataClass2("1111", "2222", true, "4444"));
            //dataList.Add(new DataClass2("1111", "2222", true, "4444"));
            //dataList.Add(new DataClass2("1111", "2222", true, "4444"));
            //dataList.Add(new DataClass2("1111", "2222", true, "4444"));
            //dataList.Add(new DataClass2("1111", "2222", true, "4444"));

            // open form
            //MyForm curForm = new MyForm()
            //{
            //    Width = 800,
            //    Height = 450,
            //    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
            //    Topmost = true,
            //};

            MyForm2 curForm = new MyForm2(roomList)
            {
                Width = 800,
                Height = 450,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            curForm.ShowDialog();

            if(curForm.DialogResult == true)
            {
                List<SpatialElement> dataList2 = curForm.GetData();

                //foreach (DataClass2 curClass in dataList2)
                //{
                //    TaskDialog.Show("Test", curClass.Item1);
                //}
            }

            // get form data and do something

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}
