using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlServerCe;
using System.Collections;
using System.Diagnostics;
using ChartFX.WinForms;
using ChartFX.WinForms.Annotation;
using ChartFX.WinForms.Adornments;
using ChartFX.WinForms.Galleries;
using ChartFX.WinForms.Internal.UI;

using SoftwareFX.WinForms;
using SoftwareFX.WinForms.Data;
using SoftwareFX.WinForms.Data.Expressions;
using ChartFX.WinForms.Statistical;

namespace SoftwareFX.Samples._BoxPlot
{
    public partial class Form1 : Form
    {

        bool valueLegendVisible = false;
        Rectangle _defaultMinPos = Rectangle.Empty;
        public Form1()
        {
            InitializeComponent();

            //Cosmetic code
            new SampleTemplate.TemplateForm(this, "Box Plot", "%SampleDescription%");
            DoubleBuffered = true;
        }

        #region Data Population Functions
        public PlayerWeightBoxPlot[] PopulateWeightBoxPlot (Chart chart1) {
        	PlayerWeightBoxPlot[] data = new PlayerWeightBoxPlot[] {
        		new PlayerWeightBoxPlot{ Cowboys = 250, Packers = 260, Broncos = 270, Dolphins = 260, Giants = 247 },
        		new PlayerWeightBoxPlot{ Cowboys = 255, Packers = 271, Broncos = 250, Dolphins = 255, Giants = 249 },
        		new PlayerWeightBoxPlot{ Cowboys = 255, Packers = 258, Broncos = 281, Dolphins = 265, Giants = 255 },
        		new PlayerWeightBoxPlot{ Cowboys = 264, Packers = 263, Broncos = 273, Dolphins = 257, Giants = 247 },
        		new PlayerWeightBoxPlot{ Cowboys = 250, Packers = 267, Broncos = 257, Dolphins = 268, Giants = 244 },
        		new PlayerWeightBoxPlot{ Cowboys = 265, Packers = 254, Broncos = 264, Dolphins = 263, Giants = 245 },
        		new PlayerWeightBoxPlot{ Cowboys = 245, Packers = 255, Broncos = 233, Dolphins = 247, Giants = 249 },
        		new PlayerWeightBoxPlot{ Cowboys = 252, Packers = 250, Broncos = 254, Dolphins = 253, Giants = 260 },
        		new PlayerWeightBoxPlot{ Cowboys = 266, Packers = 248, Broncos = 268, Dolphins = 251, Giants = 217 },
        		new PlayerWeightBoxPlot{ Cowboys = 246, Packers = 240, Broncos = 252, Dolphins = 252, Giants = 208 },
        		new PlayerWeightBoxPlot{ Cowboys = 251, Packers = 254, Broncos = 256, Dolphins = 266, Giants = 228 },
        		new PlayerWeightBoxPlot{ Cowboys = 263, Packers = 275, Broncos = 265, Dolphins = 264, Giants = 253 },
        		new PlayerWeightBoxPlot{ Cowboys = 248, Packers = 270, Broncos = 252, Dolphins = 210, Giants = 249 },
        		new PlayerWeightBoxPlot{ Cowboys = 228, Packers = 225, Broncos = 256, Dolphins = 236, Giants = 223 },
        		new PlayerWeightBoxPlot{ Cowboys = 221, Packers = 222, Broncos = 235, Dolphins = 225, Giants = 221 },
        		new PlayerWeightBoxPlot{ Cowboys = 223, Packers = 230, Broncos = 216, Dolphins = 230, Giants = 228 },
        		new PlayerWeightBoxPlot{ Cowboys = 220, Packers = 225, Broncos = 241, Dolphins = 232, Giants = 271 }
        	};
            return data;
            chart1.DataSource = data;
            //                    chart1.DataSourceSettings.ReadData();
        }

        
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxSamples.Items.Clear();
            comboBoxSamples.Items.Add("BoxPlot");
            
            comboBoxSamples.SelectedIndex = 0;
        }

        private void comboBoxSamples_SelectedIndexChanged(object sender, EventArgs e)
        {
                        chart1.Reset();
            
            string sampleName = comboBoxSamples.Items[comboBoxSamples.SelectedIndex].ToString();
            string functionName = getFunctionName(sampleName);
            Type thisClass = typeof(Form1);
            thisClass.InvokeMember(functionName,BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,null,this,null);
        }

        private string getFunctionName(string sampleName)
        {
            string functionName = "";
            sampleName = sampleName.Replace("-", " ").Trim();
            string[] words = sampleName.Split(' ');
            foreach (string word in words)
                functionName += char.ToUpper(word[0]) + word.Substring(1);

            return functionName;
        }

        #region Customization Functions
        private void BoxPlot()
	{
            Statistics statistics1 = new Statistics();
            var data = PopulateWeightBoxPlot(chart1);
            chart1.DataSource = data;
            chart1.DataSourceSettings.ReadData();
            chart1.Titles.Add(new TitleDockable("The Weight of NFL Players per Team (lb)"));
            chart1.AxisY.Title.Text = "lb";
            chart1.AxisY.ForceBaseline = true; 
            chart1.AxisX.Title.Text = "Team";
            chart1.AxisX.ForceBaseline = true;
            chart1.LegendBox.Visible = true;
            chart1.LegendBox.Dock = DockArea.Bottom;
            chart1.AxisY.ForceBaseline = false;

            Annotations annots = new Annotations();
            chart1.Extensions.Add(annots);

            annots.EnableUI = true;
            annots.ToolBar.Visible = true;

            AnnotationText text = new AnnotationText("");
            //text.Attach(0.565, 187);
            text.Attach(0, 0);
            //text.Attach(GetXAxisPosition("Cowboys", chart1), 0);
            text.Width = 67;
            text.Height = 150;
            text.Anchor = (AnchorStyles.Bottom );
            text.Border.Color = Color.Transparent;
            text.AllowModify = false;
            text.PlotAreaOnly = false;
            //text.Color = Color.Red;
            text.AllowMove = false;
            annots.List.Add(text);

            chart1.ToolBar.Visible = true;
            Command command = new Command(1);
            command.Text = "Value Legend";
            // Assigns icon #6 to the new toolbar item. You could use your own images (see Adding Custom Commands)
            command.ImageIndex = 6;
            command.Style = CommandStyles.TwoState;
            chart1.Commands.Add(command);

            ToolBarItem tbItem = new ToolBarItem();
            tbItem.CommandId = 1;
            chart1.ToolBar.Insert(5, tbItem);

            //This function calls the event associated with the new command in the toolbar
            chart1.UserCommand += Chart1_UserCommand; ;

            chart1.DataGrid.ReadOnly = false;

            statistics1.Chart = chart1;
            //Relevant Code
            statistics1.Gallery.Current = Galleries.Gallery.BoxPlot;
            statistics1.Gallery.BoxPlot.Notched = false;

            if (((Rectangle)text.ObjectBounds).X != 26 || ((Rectangle)text.ObjectBounds).Y != 298)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    text.ObjectBounds = new Rectangle(40, 385, 150, 50);
                else
                    text.ObjectBounds = new Rectangle(40, 238, 67, 62);
            }
           
            //End Relevant Code


        }

        private double GetXAxisPosition(string name, Chart chart1)
        {
            //DataUnit data = DateTime.Parse(name);
            for (int i = 0; i < chart1.Data.Points; i++)
            {
                if (chart1.Data.X[i] == null)
                    return i;
            }

            return 0;
        }

        private void Chart1_UserCommand(object sender, CommandUIEventArgs e)
        {
            List<string> selectedParams = listBox1.SelectedItems.Cast<string>().ToList();
            List<string> paramList = listBox1.Items.Cast<string>().ToList();
            Command command = chart1.Commands.Where(x => x.Text == "Value Legend").FirstOrDefault();
            if (command != null)
            {
                valueLegendVisible = !valueLegendVisible;
                command.Checked = valueLegendVisible;
            }
            else return;
            var xaxis = chart1.AxesX[0];
            xaxis.Labels[0] = "Cowboys";
            xaxis.Labels[1] = "Packers";
            xaxis.Labels[2] = "Broncos";
            xaxis.Labels[3] = "Dolphins";
            xaxis.Labels[4] = "Giants";
            var annot = chart1.Extensions[0] as Annotations;
            var text = annot.List[0] as AnnotationText;
            if (_defaultMinPos.IsEmpty)
                _defaultMinPos = text.ObjectBounds;

            if (valueLegendVisible)
            {
                var data = PopulateWeightBoxPlot(chart1);
                chart1.DataSource = data;
                chart1.DataSourceSettings.ReadData();
                double CowboysAverage = (double)data.Sum(x => x.Cowboys) / (double)data.Count();
                int cowboysMaxWeight = data.Select(x => x.Cowboys).Max();
                int cowboysMinWeight = data.Select(x => x.Cowboys).Min();
                double PackersAverage = (double)data.Sum(x => x.Packers) / (double)data.Count();
                int packersMaxWeight = data.Select(x => x.Packers).Max();
                int packersMinWeight = data.Select(x => x.Packers).Min();
                double BroncosAverage = (double)data.Sum(x => x.Broncos) / (double)data.Count();
                int broncosMaxWeight = data.Select(x => x.Broncos).Max();
                int broncosMinWeight = data.Select(x => x.Broncos).Min();
                double DolphinsAverage = (double)data.Sum(x => x.Dolphins) / (double)data.Count();
                int dolphinsMaxWeight = data.Select(x => x.Dolphins).Max();
                int dolphinsMinWeight = data.Select(x => x.Dolphins).Min();
                double GiantsAverage = (double)data.Sum(x => x.Giants) / (double)data.Count();
                int giantsMaxWeight = data.Select(x => x.Giants).Max();
                int giantsMinWeight = data.Select(x => x.Giants).Min();
                xaxis.Labels[0] = xaxis.Labels[0] + (selectedParams.Contains("Average") ? Environment.NewLine + CowboysAverage.Display2Decimals() : "") +
                    (selectedParams.Contains("Max Weight") ? Environment.NewLine + cowboysMaxWeight.ToString() : "") +
                    (selectedParams.Contains("Min Weight") ? Environment.NewLine + cowboysMinWeight.ToString() : "") +
                    (selectedParams.Contains("Range") ? Environment.NewLine + cowboysMinWeight.ToString() + " - " + cowboysMaxWeight.ToString() : "");
                xaxis.Labels[1] = xaxis.Labels[1] + (selectedParams.Contains("Average") ? Environment.NewLine + PackersAverage.Display2Decimals() : "") +
                    (selectedParams.Contains("Max Weight") ? Environment.NewLine + packersMaxWeight.ToString() : "") +
                    (selectedParams.Contains("Min Weight") ? Environment.NewLine + packersMinWeight.ToString() : "") +
                    (selectedParams.Contains("Range") ? Environment.NewLine + packersMinWeight.ToString() + " - " + packersMaxWeight.ToString() : "");
                xaxis.Labels[2] = xaxis.Labels[2] + (selectedParams.Contains("Average") ? Environment.NewLine + BroncosAverage.Display2Decimals() : "") +
                    (selectedParams.Contains("Max Weight") ? Environment.NewLine + broncosMaxWeight.ToString() : "") +
                    (selectedParams.Contains("Min Weight") ? Environment.NewLine + broncosMinWeight.ToString() : "") +
                    (selectedParams.Contains("Range") ? Environment.NewLine + broncosMinWeight.ToString() + " - " + broncosMaxWeight.ToString() : "");
                xaxis.Labels[3] = xaxis.Labels[3] + (selectedParams.Contains("Average") ? Environment.NewLine + DolphinsAverage.Display2Decimals() : "") +
                    (selectedParams.Contains("Max Weight") ? Environment.NewLine + dolphinsMaxWeight.ToString() : "") +
                    (selectedParams.Contains("Min Weight") ? Environment.NewLine + dolphinsMinWeight.ToString() : "") +
                    (selectedParams.Contains("Range") ? Environment.NewLine + dolphinsMinWeight.ToString() + " - " + dolphinsMaxWeight.ToString() : "");
                xaxis.Labels[4] = xaxis.Labels[4] + (selectedParams.Contains("Average") ? Environment.NewLine + GiantsAverage.Display2Decimals() : "") +
                    (selectedParams.Contains("Max Weight") ? Environment.NewLine + giantsMaxWeight.ToString() : "") +
                    (selectedParams.Contains("Min Weight") ? Environment.NewLine + giantsMinWeight.ToString() : "") +
                    (selectedParams.Contains("Range") ? Environment.NewLine + giantsMinWeight.ToString() + " - " + giantsMaxWeight.ToString() : "");

                text.TextColor = Color.Black;
                text.Text = "";
                text.Text = text.Text + (selectedParams.Contains("Average") ? "Average" + Environment.NewLine : "");
                text.Text = text.Text + (selectedParams.Contains("Max Weight") ? "Max Weight" + Environment.NewLine : "");
                text.Text = text.Text + (selectedParams.Contains("Min Weight") ? "Min Weight" + Environment.NewLine : "");
                text.Text = text.Text + (selectedParams.Contains("Range") ? "Range" + Environment.NewLine : "");
                text.ObjectBounds = new Rectangle(_defaultMinPos.X, _defaultMinPos.Y - (selectedParams.Count * 15), _defaultMinPos.Width, _defaultMinPos.Height);

            }
            else
            {
                text.TextColor = Color.Transparent;
                    if (this.WindowState == FormWindowState.Maximized)
                        text.ObjectBounds = new Rectangle(40, 390, 67, 62);
                    else
                        text.ObjectBounds = new Rectangle(26, 298, 67, 62);
                _defaultMinPos = text.ObjectBounds;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var annot = chart1.Extensions[0] as Annotations;
            var text = annot.List[0] as AnnotationText;
            if (((Rectangle)text.ObjectBounds).X != 26 || ((Rectangle)text.ObjectBounds).Y != 298)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    text.ObjectBounds = new Rectangle(40, 385, 100, 50);
                else
                    text.ObjectBounds = new Rectangle(33, 156, 67, 62);
            }


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void chart1_SizeChanged(object sender, EventArgs e)
        {
           
        }

        private void chart1_ClientSizeChanged(object sender, EventArgs e)
        {
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
        }
    }
    public static class Conversion
    {
        public static string Display2Decimals(this double val)
        {
            return Math.Round(val,2).ToString();
        }
    }

    #region Data Classes
    public class PlayerWeightBoxPlot
    {
        public int Cowboys { get; set; }
        public int Packers{ get; set; }
        public int Broncos { get; set; }
        public int Dolphins { get; set; }
        public int Giants { get; set; }
    }
    #endregion
}