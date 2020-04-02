using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;

namespace unvell.ReoGrid
{
    /// <summary>
    /// 添加数据源绑定功能
    /// </summary>
    public partial class ReoGridControl
    {
        #region 依赖属性

        #region DataSource

        // IEnumerable<KeyValuePair<string, IEnumerable<object>>>
        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register(nameof(DataSource), typeof(ObservableCollection<KeyValuePair<string, ObservableCollection<ObservableCollection<object>>>>), typeof(ReoGridControl), new PropertyMetadata(default(ObservableCollection<KeyValuePair<string, ObservableCollection<ObservableCollection<object>>>>)));


        /// <summary>
        /// 是否显示汇总列
        /// </summary>
        public ObservableCollection<KeyValuePair<string, ObservableCollection<ObservableCollection<object>>>> DataSource
        {
            get
            {
                var a = GetValue(DataSourceProperty);
                return a as ObservableCollection<KeyValuePair<string, ObservableCollection<ObservableCollection<object>>>>;
            }
            set
            {
                SetValue(DataSourceProperty, value);
            }
        }
        #endregion


        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        protected void _InitDataSourceProperty()
        {
            this.Loaded += ReoGridControl_DataSource_Loaded;
        }


        #region 事件处理

        private void ReoGridControl_DataSource_Loaded(object sender, RoutedEventArgs e)
        {
            _ShowDataToGrid();
        }

        /// <summary>
        /// 展示数据
        /// </summary>
        private void _ShowDataToGrid()
        {
            this.workbook.ClearWorksheets();

            if (DataSource != null && DataSource.Any())
            {

                foreach (var sheetItem in DataSource)
                {
                    var sheet = this.CreateWorksheet(sheetItem.Key);
                    sheet.SetSettings(WorksheetSettings.Edit_Readonly, this.Readonly);


                    var sheetData = sheetItem.Value;

                    int rowIndex = 0;
                    if (sheetData != null && sheetData.Any())
                    {
                        foreach (var rowData in sheetData)
                        {
                            int colIndex = 0;
                            if (rowData != null && rowData.Any())
                                foreach (var cellItem in rowData)
                                {
                                    sheet[rowIndex, colIndex++] = cellItem;
                                }

                            rowIndex++;
                        }
                    }

                    if (this.JustShowDataColumn)
                    {
                        var max_cols = sheetData.Max(i => i.Count);
                        sheet.ColumnCount = max_cols;
                    }

                    if (this.JustShowDataRow)
                        sheet.RowCount = sheetData.Count;

                    if (this.AutoFitWidthColumns != null && this.AutoFitWidthColumns.Any())
                    {
                        foreach (var i in this.AutoFitWidthColumns)
                        {
                            if (i < sheet.ColumnCount)
                                sheet.AutoFitColumnWidth(i);
                        }
                    }

                    if (this.DisabledSheetSelectRange)
                    {
                        sheet.BeforeSelectionRangeChange += (object sender, Events.BeforeSelectionChangeEventArgs e) => { e.IsCancelled = true; };
                    }

                    this.Worksheets.Add(sheet);
                }
            }

            if (!this.Worksheets.Any())
            {
                var sheet = this.CreateWorksheet();
                this.Worksheets.Add(sheet);
            }
        }


        #endregion


    }
}
