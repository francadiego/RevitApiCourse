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
    internal class GetElementLocation : IExternalCommand
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

            //GetLocationPoint(PickObject_Method());
            GetLocationCurve(PickObject_Method());

            return Result.Succeeded;
        }

        #region function1
        /// <summary>
        /// Prompt the user to select an element and retrieve this element.
        /// </summary>
        /// <returns>Element picked</returns>

        public Element PickObject_Method()
        {
            Reference reference = _uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Select an element:");

            Element pickElement = _uidoc.Document.GetElement(reference);

            return pickElement;
        }

        #endregion

        #region
        /// <summary>
        /// Retrieve element XYZ cordinate.
        /// </summary>
        /// <param name="e">Picked Element</param>
        public void GetLocationPoint(Element e)
        {
            Location element = e.Location;
            LocationPoint elementPoint = (LocationPoint)element;
            XYZ coordElement = elementPoint.Point;

            TaskDialog.Show("Coordenadas", $"Coord X:{coordElement.X}\nCoord Y:{coordElement.Y}\nCoord Z:{coordElement.Z}\n ");
        }

        #endregion

        #region GetLocationCurve
        /// <summary>
        /// Get picked element curve
        /// </summary>
        /// <param name="e">Picked element</param>
        public void GetLocationCurve (Element e)
        {
            string s = string.Empty;

            Location element = e.Location;
            LocationCurve locationCurve = (LocationCurve)element;
            Curve crv = locationCurve.Curve;

            s += $"StartPoint X: {crv.GetEndPoint(0).X}\n";
            s += $"StartPoint Y: {crv.GetEndPoint(0).Y}\n";
            s += $"StartPoint Z: {crv.GetEndPoint(0).Z}\n";
            s += $"EndPoint X: {crv.GetEndPoint(1).X}\n";
            s += $"EndPoint Y: {crv.GetEndPoint(1).Y}\n";
            s += $"EndPoint Z: {crv.GetEndPoint(1).Z}\n";

            TaskDialog.Show("Curves", s);
        }
        #endregion
    }
}
