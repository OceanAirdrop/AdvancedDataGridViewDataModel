using AdvancedDataGridViewDataTable.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Dynamic;

namespace AdvancedDataGridViewDataTable
{
    public partial class Form1 : Form
    {
        List<DataModel> m_dataGridBindingList = new List<DataModel>();
        List<DataModel> m_filteredList = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StyleDataGridView(dataGridView1, true);
            AddTestData();
            SetupDataBinding();
        }

        private void SetupDataBinding()
        {
            m_filteredList = m_dataGridBindingList;

            dataGridView1.DataBindings.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = m_dataGridBindingList;
            dataGridView1.AutoResizeRows();
        }

        public static void StyleDataGridView(DataGridView dgv, bool isReadonly = true)
        {
            try
            {
                // Setting the style of the DataGridView control
                dgv.RowHeadersVisible = true;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
                dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                dgv.DefaultCellStyle.BackColor = Color.Empty;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dgv.AllowUserToAddRows = false;
                dgv.ReadOnly = isReadonly;
                dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle1.BackColor = Color.LightBlue;
                dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            }
            catch (Exception ex)
            {
            }
        }


        private void AddTestData()
        {
            Random r = new Random();

            List<string> words = new List<string>();
            words.Add("seemly");
            words.Add("puncture");
            words.Add("puntastic");
            words.Add("imaginary");
            words.Add("absent");
            words.Add("discover");
            words.Add("spiteful");
            words.Add("seen");
            words.Add("paint");
            words.Add("oceanic");
            words.Add("ignorant");

            for (int i = 0; i <= 10; i++)
            {
                DataModel d = new DataModel();
                d.DataPointId = i;

                d.Description = words[i];
                d.InAlarm = i % 2 == 0 ? true : false;
                d.LastUpdate = DateTime.Today.AddHours(i * 2).AddHours(i % 2 == 0 ? i * 10 + 1 : 0).AddMinutes(i % 2 == 0 ? i * 10 + 1 : 0).AddSeconds(i % 2 == 0 ? i * 10 + 1 : 0).AddMilliseconds(i % 2 == 0 ? i * 10 + 1 : 0);
                d.ScalingMultiplier = (double)i * 6 / 3;
                d.Price = (decimal)i * 7 / 3;

                m_dataGridBindingList.Add(d);
            }

           
        }

        private void advancedDataGridView1_EnabledChanged(object sender, EventArgs e)
        {
           
        }

        private void advancedDataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dataGridView1.SortString) == true)
                    return;

                var sortStr = dataGridView1.SortString.Replace("[", "").Replace("]", "");

                if (string.IsNullOrEmpty(dataGridView1.FilterString) == true)
                {
                    // the grid is not filtered!
                    m_dataGridBindingList = m_dataGridBindingList.OrderBy(sortStr).ToList();
                    dataGridView1.DataSource = m_dataGridBindingList;
                }
                else
                {
                    // the grid is filtered!
                    m_filteredList = m_filteredList.OrderBy(sortStr).ToList();
                    dataGridView1.DataSource = m_filteredList;
                }

                textBox_sort.Text = sortStr;
            }
            catch (Exception ex)
            {
            }
        }

        private string FilterStringConverter(string filter)
        {
            string newColFilter = "";

            filter = filter.Replace("(", "").Replace(")", "");

            var colFilterList = filter.Split(new string[] { "AND" }, StringSplitOptions.None);

            string andOperator = "";

            foreach (var colFilter in colFilterList)
            {
                newColFilter += andOperator;

                var colName = "";

                // Step 1: BOOLEAN Check 
                if (colFilter.Contains(" IN ") == false && colFilter.Split('=').Length == 2)
                {
                    // if the filter string is in the form "ColumnName=value". example = "(InAlarm != null && (InAlarm == true))";
                    colName = colFilter.Split('=')[0];
                    var booleanVal = colFilter.Split('=')[1];

                    newColFilter += $"({colName} != null && ({colName} == {booleanVal}))";

                    continue;
                }

                // Step 2: NUMBER (int/decimal/double/etc) and STRING Check
                if (colFilter.Contains(" IN ") == true )
                {
                    var temp1 = colFilter.Trim().Split(new string[] { "IN" }, StringSplitOptions.None);

                    colName = GetStringBetweenChars(temp1[0], '[', ']');

                    var filterValsList = temp1[1].Split(',');

                    newColFilter += string.Format("({0} != null && (", colName);

                    string orOperator = "";

                    foreach (var filterVal in filterValsList)
                    {
                        double tempNum = 0;
                        if (Double.TryParse(filterVal, out tempNum))
                            newColFilter += string.Format("{0} {1} = {2}", orOperator, colName, filterVal.Trim());
                        else
                            newColFilter += string.Format("{0} {1}.Contains({2})", orOperator, colName, filterVal.Trim());

                        orOperator = " OR ";
                    }

                    newColFilter += "))";
                }

                // Step 3: DATETIME Check
                if (colFilter.Contains(" LIKE ") == true && colFilter.Contains("Convert[") == true)
                {
                    // first of all remove the cast
                    var colFilterNoCast = colFilter.Replace("Convert", "").Replace(", 'System.String'", "");

                    var filterValsList = colFilterNoCast.Trim().Split(new string[] { "OR" }, StringSplitOptions.None);

                    colName = GetStringBetweenChars(filterValsList[0], '[', ']');

                    newColFilter += string.Format("({0} != null && (", colName);

                    string orOperator = "";

                    foreach (var filterVal in filterValsList)
                    {
                        var v = GetStringBetweenChars(filterVal, '%', '%');

                        newColFilter += string.Format("{0} {1}.Date = DateTime.Parse('{2}')", orOperator, colName, v.Trim());

                        orOperator = " OR ";
                    }

                    newColFilter += "))";
                }

                andOperator = " AND ";
            }

            return newColFilter.Replace("'", "\"");
        }

        private string GetStringBetweenChars(string input, char startChar, char endChar)
        {
            string output = input.Split(startChar, endChar)[1];
            return output;
        }

        private void dataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dataGridView1.FilterString) == true)
                {
                    dataGridView1.DataSource = m_dataGridBindingList;
                    m_filteredList = m_dataGridBindingList;
                }
                else
                {
                    var listfilter = FilterStringConverter(dataGridView1.FilterString);

                    m_filteredList = m_filteredList.Where(listfilter).ToList();

                    dataGridView1.DataSource = m_filteredList;

                    textBox_filter.Text = listfilter;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_unloadfilters_Click(object sender, EventArgs e)
        {
            dataGridView1.CleanFilterAndSort();

            textBox_filter.Text = "";
            textBox_sort.Text = "";
        }
    }
}
