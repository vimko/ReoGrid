using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;

namespace unvell.ReoGrid
{
    /// <summary>
    /// 扩展属性
    /// </summary>
    public partial class ReoGridControl
    {
        #region 依赖属性

        #region 是否只显示有数据的列

        /// <summary>
        /// 只显示有数据的列
        /// </summary>
        public static readonly DependencyProperty JustShowDataColumnProperty = DependencyProperty.Register(nameof(JustShowDataColumn), typeof(bool), typeof(ReoGridControl), new PropertyMetadata(default(bool)));


        /// <summary>
        /// 只显示有数据的列
        /// </summary>
        public bool JustShowDataColumn
        {
            get
            {
                return (bool)GetValue(JustShowDataColumnProperty);
            }
            set
            {
                SetValue(JustShowDataColumnProperty, value);
            }
        }
        #endregion

        #region 是否只显示有数据的行

        /// <summary>
        /// 只显示有数据的行
        /// </summary>
        public static readonly DependencyProperty JustShowDataRowProperty = DependencyProperty.Register(nameof(JustShowDataRow), typeof(bool), typeof(ReoGridControl), new PropertyMetadata(default(bool)));


        /// <summary>
        /// 只显示有数据的行
        /// </summary>
        public bool JustShowDataRow
        {
            get
            {
                return (bool)GetValue(JustShowDataRowProperty);
            }
            set
            {
                SetValue(JustShowDataRowProperty, value);
            }
        }
        #endregion

        #region 是否自动列宽

        /// <summary>
        /// 自动适应列宽的列
        /// </summary>
        public static readonly DependencyProperty AutoFitWidthColumnsProperty = DependencyProperty.Register(nameof(AutoFitWidthColumns), typeof(int[]), typeof(ReoGridControl), new PropertyMetadata(default(int[])));


        /// <summary>
        /// 自动适应列宽的列
        /// </summary>
        public int[] AutoFitWidthColumns
        {
            get
            {
                return (int[])GetValue(AutoFitWidthColumnsProperty);
            }
            set
            {
                SetValue(AutoFitWidthColumnsProperty, value);
            }
        }
        #endregion

        #region 当前选择的Sheet页签名称

        /// <summary>
        /// 当前选择的Sheet页签名称
        /// </summary>
        public static readonly DependencyProperty CurrentSelectedSheetNameProperty = DependencyProperty.Register(nameof(CurrentSelectedSheetName), typeof(string), typeof(ReoGridControl), new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(CurrentSelectedSheetNamePropertyChanged)));


        /// <summary>
        /// 当前选择的Sheet页签名称
        /// </summary>
        public string CurrentSelectedSheetName
        {
            get => (string)GetValue(CurrentSelectedSheetNameProperty);
            set => SetValue(CurrentSelectedSheetNameProperty, value);
        }

        private static void CurrentSelectedSheetNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = d as ReoGridControl;

            if (grid == null)
                return;

            var selectedSheetName = e.NewValue?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedSheetName))
            {
                var currentSheet = grid.CurrentWorksheet;
                if (currentSheet.Name != selectedSheetName)
                    grid.CurrentWorksheet = grid.GetWorksheetByName(selectedSheetName);
            }
        }
        #endregion

        #region Sheet页不能选择区域

        /// <summary>
        /// Sheet页不能选择区域
        /// </summary>
        public static readonly DependencyProperty DisabledSheetSelectRangeProperty = DependencyProperty.Register(nameof(DisabledSheetSelectRange), typeof(bool), typeof(ReoGridControl), new PropertyMetadata(default(bool)));


        /// <summary>
        /// Sheet页不能选择区域
        /// </summary>
        public bool DisabledSheetSelectRange
        {
            get
            {
                return (bool)GetValue(DisabledSheetSelectRangeProperty);
            }
            set
            {
                SetValue(DisabledSheetSelectRangeProperty, value);
            }
        }
        #endregion

        #endregion

    }
}
