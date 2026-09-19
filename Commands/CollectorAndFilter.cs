using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;

namespace RevitApiCourse
{
    [Transaction(TransactionMode.Manual)]
    internal class CollectorAndFilter : IExternalCommand
    {
        //Create global variables.
        UIApplication _uiapp;
        Application _app;
        UIDocument _uidoc;
        Document _doc;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Create App and doc objects.
            _uiapp = commandData.Application;
            _app = _uiapp.Application;
            _uidoc = _uiapp.ActiveUIDocument;
            _doc = _uidoc.Document;

            CountElements(FilterWalls());

            return Result.Succeeded;
        }

        #region FilterDoor
        /// <summary>
        /// Filter doors in the model
        /// </summary>
        /// <returns>List filtered doors.</returns>
        public IList<Element> FilterDoors()
        {
            //creat a collector -> collector and filter
            FilteredElementCollector collector = new FilteredElementCollector(_doc);

            //OST Category
            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Doors); 

            IList<Element> filteredDoors = collector
                .WherePasses(filter)
                .WhereElementIsNotElementType()
                .ToElements();
            
            return filteredDoors;
        }
        #endregion

        #region Elements
        /// <summary>
        /// Counts the elements.
        /// </summary>
        /// <param name="filteredElements">Elements amount</param>
        public void CountElements(IList<Element> elements)
        {
            TaskDialog.Show("Elements", $"Total Elements: {elements.Count}");
        }

        #endregion

        #region FilterWalls
        /// <summary>
        /// Filter Walls
        /// </summary>
        /// <returns>filtered walls</returns>
        public IList<Element> FilterWalls()
        {
            ElementId viewId = _doc.ActiveView.Id;
            //create a collector
            FilteredElementCollector collector = new FilteredElementCollector( _doc, viewId);

            //create a filter
            ElementClassFilter filter = new ElementClassFilter(typeof(Wall));

            //Narrow down the collector
            IList<Element> filteredWalls = collector
                .WherePasses(filter)
                .WhereElementIsNotElementType()
                .ToElements();

            return filteredWalls;


        }

        #endregion

    }
}
