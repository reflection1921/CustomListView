using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomListView
{
    public class HeaderNativeWindow : NativeWindow
    {
        private ListView listView;

        private Color _blankAreaColor;
        private Color _areaColor;
        private Color _textColor;
        private Color _borderColor;
        private ColumnHeaderBorderStyle _borderStyle;
        public HeaderNativeWindow(IntPtr handle, ListView listView, Color emptyAreaColor, Color columnAreaColor, Color textColor, Color borderColor, ColumnHeaderBorderStyle borderStyle)
        {
            _blankAreaColor = emptyAreaColor;
            _areaColor = columnAreaColor;
            _textColor = textColor;
            _borderColor = borderColor;
            _borderStyle = borderStyle;

            this.listView = listView;
            this.AssignHandle(handle);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x000F) // WM_PAINT
            {
                Win32.PAINTSTRUCT ps;
                IntPtr hdc = Win32.BeginPaint(m.HWnd, out ps);

                using (Graphics g = Graphics.FromHdc(hdc))
                {
                    Rectangle rect;
                    Rectangle columnRect = listView.ClientRectangle;

                    using (Brush emptyBrush = new SolidBrush(_blankAreaColor))
                        g.FillRectangle(emptyBrush, columnRect);

                    using (Pen columnBorderPen = new Pen(_borderColor))
                    using (Brush columnBrush = new SolidBrush(_areaColor))
                    {
                        for (int i = 0; i < listView.Columns.Count; i++)
                        {
                            rect = GetHeaderRect(i);
                            g.FillRectangle(columnBrush, rect);
                            switch (_borderStyle)
                            {
                                case ColumnHeaderBorderStyle.SingleLine:
                                    if (i != listView.Columns.Count - 1)
                                    {
                                        g.DrawLine(columnBorderPen, rect.X + rect.Width - 1, rect.Y, rect.X + rect.Width - 1, rect.Height - 1);
                                    }
                                    break;
                                case ColumnHeaderBorderStyle.Rectangle:
                                    g.DrawRectangle(columnBorderPen, rect.X, rect.Y, rect.Width - 1, rect.Height - 1);
                                    break;
                            }

                            string headerText = listView.Columns[i].Text;
                            TextRenderer.DrawText(
                                g,
                                headerText,
                                listView.Font,
                                rect,
                                _textColor,
                                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis
                            );
                        }
                    }
                }

                Win32.EndPaint(m.HWnd, ref ps);
                return;
            }

            base.WndProc(ref m);
        }

        public void UpdateColors(Color blankAreaColor, Color areaColor, Color textColor, Color borderColor, ColumnHeaderBorderStyle borderStyle)
        {
            _blankAreaColor = blankAreaColor;
            _areaColor = areaColor;
            _textColor = textColor;
            _borderColor = borderColor;
            _borderStyle = borderStyle;

            Win32.RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, Win32.RDW_INVALIDATE | Win32.RDW_UPDATENOW);
        }

        private Rectangle GetHeaderRect(int index)
        {
            IntPtr headerHandle = this.Handle;
            Win32.RECT rect;
            Win32.SendMessage(headerHandle, Win32.HDM_GETITEMRECT, new IntPtr(index), out rect);
            return Rectangle.FromLTRB(rect.left, rect.top, rect.right, rect.bottom);
        }
    }
}
