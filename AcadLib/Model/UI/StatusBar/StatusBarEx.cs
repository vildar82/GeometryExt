﻿using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.Windows;
using JetBrains.Annotations;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;
using StatusBarMenu = AcadLib.UI.StatusBar.View.StatusBarMenu;

namespace AcadLib.UI.StatusBar
{
    /// <summary>
    /// Статусная строка
    /// </summary>
    public static class StatusBarEx
    {
        /// <summary>
        /// Добавление панели с выпадающим списком значений.
        /// </summary>
        /// <param name="value">текщее знасчение</param>
        /// <param name="values">Значения</param>
        /// <param name="toolTip">Описание</param>
        /// <param name="selectValue">Действие при выборе значения</param>
        /// <param name="showMenu">Показ меню - текущее значение</param>
        /// <param name="minWidth"></param>
        /// <param name="maxWidth"></param>
        [NotNull]
        public static Pane AddMenuPane(string value, List<string> values, string toolTip, Action<string> selectValue,
            Func<string> showMenu, int minWidth =0, int maxWidth =0)
        {
            var pane = new Pane {Text = value, Style = PaneStyles.PopUp | PaneStyles.Normal, ToolTipText = toolTip};
            pane.MouseDown += (o, e) =>
            {
                new StatusBarMenu(showMenu(), values, selectValue).Show();
            };
            pane.Visible = false;
            Application.StatusBar.Panes.Insert(0, pane);
            if (minWidth != 0) pane.MinimumWidth = minWidth;
            if (maxWidth != 0) pane.MinimumWidth = maxWidth;
            pane.Visible = true;
            Application.StatusBar.Update();
            return pane;
        }
        
    }
}