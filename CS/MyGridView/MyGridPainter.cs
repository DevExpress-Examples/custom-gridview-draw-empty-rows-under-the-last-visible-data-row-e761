using System;
using System.Drawing;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace CustomGrid {
    public class MyGridPainter : GridPainter {
        public MyGridPainter(GridView view) : base(view) { }

        protected override void DrawRows(GridViewDrawArgs e) {
            base.DrawRows(e);
            DrawEmptyAreaLines(e);
        }
        protected virtual void DrawEmptyAreaLines(GridViewDrawArgs e) {
            GridViewRects rects = e.ViewInfo.ViewRects;
            Rectangle er = rects.EmptyRows;
            if(er.IsEmpty) return;

            Pen pen = SystemPens.ControlDark;
            if(View.OptionsView.ShowVerticalLines != DevExpress.Utils.DefaultBoolean.False) {
                foreach(GridColumnInfoArgs column in e.ViewInfo.ColumnsInfo) {
                    int x = column.Bounds.Right - 1;
                    if((column.Column != null && column.Column.Fixed != DevExpress.XtraGrid.Columns.FixedStyle.None) ||
                        ((rects.FixedLeft.IsEmpty || x > rects.FixedLeft.Right) &&
                        (rects.FixedRight.IsEmpty || x < rects.FixedRight.Left - 3)))
                        e.Graphics.DrawLine(pen, x, er.Top, x, er.Bottom);
                }
                if(!rects.FixedRight.IsEmpty)
                    e.Graphics.DrawLine(pen, rects.FixedRight.Left - 1, er.Top, rects.FixedRight.Left - 1, er.Bottom);
            }

            if(View.OptionsView.ShowHorizontalLines != DevExpress.Utils.DefaultBoolean.False) {
                int rowHeight = e.ViewInfo.MinRowHeight;
                for(int y = er.Top + rowHeight; y < er.Bottom; y += rowHeight)
                    e.Graphics.DrawLine(pen, er.Left, y, rects.DataRectRight.Right - 1, y);
            }
        }
    }
}
