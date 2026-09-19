using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace RevitApiCourse
{
    [Transaction(TransactionMode.Manual)]
    internal class TemplateClass : IExternalCommand
    {
        UIDocument _uidoc;
        UIApplication _uiapp;
        Application _app;
        Document _doc;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            _uiapp = commandData.Application;
            _app = _uiapp.Application;
            _uidoc = _uiapp.ActiveUIDocument;
            _doc = _uidoc.Document;

            return Result.Succeeded;
        }

        #region function1

        public void function()
        {

        }

        #endregion
    }
}
