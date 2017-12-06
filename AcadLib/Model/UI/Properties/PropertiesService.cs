﻿using JetBrains.Annotations;
using System;
using System.Windows.Forms;

namespace AcadLib.UI.Properties
{
    public static class PropertiesService
    {
        public static bool? Show(object value, [CanBeNull] Func<object, object> reset = null)
        {
            var propVM = new PropertiesViewModel(value, reset);
            var propView = new PropertiesView(propVM);
            return propView.ShowDialog();
        }

        public static DialogResult ShowForm(object value)
        {
            var formProps = new FormProperties { propertyGrid1 = { SelectedObject = value } };
            return Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(formProps);
        }
    }
}
