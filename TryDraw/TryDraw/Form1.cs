using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace TryDraw
{
    public partial class Form1 : Form
    {
        GraphPane graphPane;
        public Form1()
        {
            InitializeComponent();
            graphPane = zedGraphControl1.GraphPane;
            draw();
        }
        private void draw()
        {
            graphPane.Title.Text = "Неровность";
            graphPane.XAxis.Title.Text = "oX";
            graphPane.YAxis.Title.Text = "oY";
            ReadData obj = new ReadData();
            PointPairList _pointPairList = new PointPairList();
            List<Pair> list = new List<Pair>();
            list = obj.WriteList();
            foreach (Pair temp in list)
            {
                double x = temp.X;   
                double y = temp.Y;
                PointPair point_pair = new PointPair(x, y);
                _pointPairList.Add(point_pair);
            }
            LineItem li = graphPane.AddCurve("Проекция неровностей", _pointPairList, Color.Red, SymbolType.None);

            zedGraphControl1.AxisChange();

        }
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
 
        }
    }
}
