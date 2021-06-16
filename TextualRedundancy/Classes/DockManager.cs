using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TextualRedundancy.Controls;

namespace TextualRedundancy.Classes
{
    public interface IDockWindow
    {
        void OnDock();
    }

    public class DockHost
    {
        public DockManager Manager = null;
        public TabControl DockControl;
        private Window Window;

        public DockHost(DockManager mngr, Window wnd, TabControl ctrl)
        {
            Manager = mngr;
            DockControl = ctrl;
            Window = wnd;
        }

        public void Dock()
        {
            if (Window.Height <= 110)
            {
                Window.Height = UI.screen_height / 2;
                Window.Width = UI.screen_width / 2;
            }
        }

        public void DockAll()
        {
            Window.Height = UI.Rasterize(UI.screen_height / 2, UI.RASTER);
            Window.Width = UI.Rasterize(UI.screen_width / 2, UI.RASTER);

        }
    }
    public class DockManager
    {
        public List<DockPane> Docks;
        public DockHost DockHost = null;
        private IDockWindow Window = null;

        public DockManager(IDockWindow wnd, TabControl ctrl)
        {
            DockHost = new DockHost(this, (Window)wnd, ctrl);
            Docks = new List<DockPane>();
            Window = wnd;
        }

        public DockPane Undock(TabItem item)
        {
            double screen_width = SystemParameters.WorkArea.Width;
            double screen_height = SystemParameters.WorkArea.Height;

            DockPane pane = new DockPane(DockHost);
            if (item.Name == "TabItemStatistics")
            {
                StatisticsControl ctrl = UI.FindChild<StatisticsControl>(item, "StatisticsControl");
                if (ctrl != null)
                    ctrl.DockHost = pane;
            }

            try
            {
                DockHost.DockControl.Items.Remove(item);
                pane.MainTab.Items.Add(item);
                pane.Title.Text = item.Header.ToString();
                pane.Show();
            }
            catch { }



            if (item.Name == "TabItemStatistics")
            {
                StatisticsControl ctrl = UI.FindChild<StatisticsControl>(item, "StatisticsControl");
                if (ctrl != null)
                    pane.Width = ctrl.lvStatisticValues.ActualWidth * 1.4;
                pane.Height = screen_height - 200;

            }
            else
            {
                pane.Width = screen_width / 2;
                pane.Height = screen_height / 2;
            }

            pane.Left = Math.Max(pane.Left, 0);
            pane.Top = Math.Max(pane.Top, 0);

            pane.Name = item.Name;
            pane.Item = item;

            if (!Docks.Any(d => d.Name == pane.Name))
                Docks.Add(pane);

            return pane;

        }

        public void Dock(TabItem item)
        {
            bool new_windows = DockHost.DockControl.Items.Count == 0;

            DockPane dock = Docks.FirstOrDefault(d => d.Name == item.Name);
            Docks.RemoveAll(d => d.Name == dock.Name);

            int insert_pos = Convert.ToInt16(item.Tag);
            int current_pos = 0;

            if (DockHost.DockControl.Items.Count == 0)
                DockHost.DockControl.Items.Add(item);

            else
            {
                if (DockHost.DockControl.Items.Count == 0)
                {
                    DockHost.DockControl.Items.Add(item);
                }
                else
                {

                    bool found = false;
                    List<TabItem> tabs = new List<TabItem>();
                    foreach (TabItem itm in DockHost.DockControl.Items)
                        tabs.Add(itm);

                    tabs = tabs.OrderBy(t => Convert.ToInt16(t.Tag)).ToList();

                    foreach (TabItem itm in tabs)
                    {
                        int compare_pos = Convert.ToInt16(itm.Tag);
                        if (insert_pos < compare_pos)
                        {
                            DockHost.DockControl.Items.Insert(current_pos, item);
                            found = true;
                            break;
                        }
                        current_pos++;
                    }

                    if (!found)
                        DockHost.DockControl.Items.Add(item);
                }
            }

            DockHost.Dock();
            Window.OnDock();
        }

        public void DockAll()
        {
            List<DockPane> docks = new List<DockPane>();
            docks.AddRange(Docks);

            foreach (DockPane pane in docks)
            {
                pane.DockAndClose(null);
            }

            Docks.Clear();
            DockHost.DockAll();
        }

        public void CloseAll()
        {
            List<DockPane> panes = new List<DockPane>();

            panes.AddRange(Docks);

            foreach (DockPane pane in panes)
                pane.Close();


        }
    }
}
