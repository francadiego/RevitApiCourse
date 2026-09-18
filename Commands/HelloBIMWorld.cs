using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;

namespace RevitApiCourse
{
    [Transaction(TransactionMode.Manual)]
    public class HelloBIMWorld : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Hello 2", "Hello BIM World 2026");

            return Result.Succeeded;
        }
    }
}
