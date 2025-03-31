using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomListView
{
    public class CustomListView : ListView
    {
        private const int WM_ERASEBKGND = 0x0014;
        private const int LVM_GETHEADER = 0x101F;

        private Color _columnHeaderAreaColor = Color.White;
        private Color _columnHeaderTextColor = Color.Black;
        private Color _columnHeaderBlankAreaColor = Color.White;
        private Color _columnHeaderBorderColor = Color.Black;

        private ColumnHeaderBorderStyle _columnHeaderBorderStyle = ColumnHeaderBorderStyle.SingleLine;

        private HeaderNativeWindow _headerWindow;
        private IntPtr _headerHandle;

        [Category("Column Header")]
        [DisplayName("Column Header Color")]
        [Description("Sets column header color")]
        public Color ColumnHeaderAreaColor
        {
            get => _columnHeaderAreaColor;
            set
            {
                _columnHeaderAreaColor = value;
                UpdateHeader();
                Invalidate();
            }
        }

        [Category("Column Header")]
        [DisplayName("Column Header Text Color")]
        [Description("Sets column header text color")]
        public Color ColumnHeaderTextColor
        {
            get => _columnHeaderTextColor;
            set
            {
                _columnHeaderTextColor = value;
                UpdateHeader();
                Invalidate();
            }
        }

        [Category("Column Header")]
        [DisplayName("Column Header Blank Area Color")]
        [Description("Sets column header blank area color")]
        public Color ColumnHeaderBlankAreaColor
        {
            get => _columnHeaderBlankAreaColor;
            set
            {
                _columnHeaderBlankAreaColor = value;
                UpdateHeader();
                Invalidate();
            }
        }

        [Category("Column Header")]
        [DisplayName("Column Header Border Color")]
        [Description("Sets column header border color")]
        public Color ColumnHeaderBorderColor
        {
            get => _columnHeaderBorderColor;
            set
            {
                _columnHeaderBorderColor = value;
                UpdateHeader();
                Invalidate();
            }
        }

        [Category("Column Header")]
        [DisplayName("Column Header Border Style")]
        [Description("Sets column header border style")]
        public ColumnHeaderBorderStyle ColumnHeaderBorderStyle
        {
            get => _columnHeaderBorderStyle;
            set
            {
                _columnHeaderBorderStyle = value;
                UpdateHeader();
                Invalidate();
            }
        }

        public CustomListView()
        {
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void UpdateHeader()
        {
            _headerWindow?.UpdateColors(_columnHeaderBlankAreaColor, _columnHeaderAreaColor, _columnHeaderTextColor, _columnHeaderBorderColor, _columnHeaderBorderStyle);
            Invalidate();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            _headerHandle = Win32.SendMessage(this.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);

            if (_headerWindow == null)
            {
                _headerWindow = new HeaderNativeWindow(
                    _headerHandle,
                    this,
                    _columnHeaderBlankAreaColor,
                    _columnHeaderAreaColor,
                    _columnHeaderTextColor,
                    _columnHeaderBorderColor,
                    _columnHeaderBorderStyle
                );
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_ERASEBKGND)
                return;

            base.WndProc(ref m);
        }
    }
}
