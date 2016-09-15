using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CloseTruck
{
    public partial class Form : System.Windows.Forms.Form
    {
        ArrayList OrderList = new ArrayList();

        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        // Scanner Handler
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string trackingNo = txtTrackingNo.Text;
                
                //check tracking no already exist.
                for (int i = 0; i < OrderList.Count; i++)
                {
                    Order o = (Order)OrderList[i];
                    if(o.TrackingNo == trackingNo)
                    {
                        txtTrackingNo.Text = "";
                        MessageBox.Show("운송장번호가 이미 스캔 되었습니다." , "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Retrieve order from DB
                Order order = GetOrder(trackingNo);

                // If order does not exist then show error popup
                if(String.IsNullOrEmpty(order.TrackingNo))
                {
                    txtTrackingNo.Text = "";
                    MessageBox.Show("시스템에 운송장 번호가 존재하지 않습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // If terminal code does not exist then show error popup
                if (String.IsNullOrEmpty(order.TerminalCode))
                {
                    txtTrackingNo.Text = "";
                    MessageBox.Show("CJ에서 터미널 코드를 받아오지 못하였습니다." + trackingNo, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update Order status 9
                UpdateOrder(order.OrderId);

                // Add order to list 
                OrderList.Add(order);

                // Datagrid table setting
                DataTable dt = new DataTable();
                dt.Columns.Add("No");
                dt.Columns.Add("OrderId");
                dt.Columns.Add("Name");
                dt.Columns.Add("Mobile");
                dt.Columns.Add("ZipCode");
                dt.Columns.Add("Contents");
                dt.Columns.Add("TrackingNo");
                dt.Columns.Add("Address");

                for (int i=0;i< OrderList.Count;i++)
                {
                    DataRow dr = dt.NewRow();
                    Order o = (Order) OrderList[i];
                    dr[0] = i+1;
                    dr[1] = o.OrderId;
                    dr[2] = o.Name;
                    dr[3] = o.Mobile;
                    dr[4] = o.ZipCode;
                    dr[5] = "망고(의류)";
                    dr[6] = o.TrackingNo;
                    dr[7] = o.Address;

                    dt.Rows.Add(dr);
                }
                dataGridView.DataSource = dt;
                dataGridView.ReadOnly = false;
                labelCount.Text = dt.Rows.Count + " 개";
                if (dt.Rows.Count > 0) btnCloseTruck.Enabled = true;
                txtTrackingNo.Text = "";
            }
        }

        private void SaveDataGridViewToCSV(string filename)
        {
            // Save the current state of the clipboard so we can restore it after we are done
            IDataObject objectSave = Clipboard.GetDataObject();
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            dataGridView.SelectAll();
            // Copy (set clipboard)
            Clipboard.SetDataObject(dataGridView.GetClipboardContent());
            // Paste (get the clipboard and serialize it to a file)
            File.WriteAllText(filename, Clipboard.GetText(TextDataFormat.CommaSeparatedValue));
            // Restore the current state of the clipboard so the effect is seamless
            if (objectSave != null) // If we try to set the Clipboard to an object that is null, it will throw...
            {
                Clipboard.SetDataObject(objectSave);
            }
        }

        private Order GetOrder(string trackingNo)
        {
            var result = new Order();

            try
            {
                using (var conn = new SqlConnection(SQL.CONSTRING))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = SQL.SELECT_ORDER;
                    cmd.Parameters.AddWithValue("@trackingNo", trackingNo);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.OrderId = (reader["ID"] == null) ? "" : reader["ID"].ToString(); 
                            result.Name = (reader["NAME"] == null) ? "" : reader["NAME"].ToString(); 
                            result.ZipCode = (reader["ZIPCODE"] == null) ? "" : reader["ZIPCODE"].ToString(); 
                            result.Mobile = (reader["MOBILE"] == null) ? "" : reader["MOBILE"].ToString(); 
                            result.Address = (reader["ADDRESS1"] == null)? "" : reader["ADDRESS1"].ToString() + reader["ADDRESS2"].ToString();
                            result.TrackingNo = (reader["TRACKINGNO"] == null)? "" : reader["TRACKINGNO"].ToString();
                            result.TerminalCode = (reader["TerminalCode"] == null) ? "" : reader["TerminalCode"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void UpdateOrder(String externOrderKey)
        {
            try
            {
                using (var conn = new SqlConnection(SQL.CONSTRING))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = SQL.UPDATE_ORDER;
                    cmd.Parameters.AddWithValue("@externOrderKey", externOrderKey);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // When user clicks button, show the dialog.
            SaveDataGridViewToCSV("Manifest.csv");
            MessageBox.Show("Manifest.csv를 CNPLUS에 업로드 하세요.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDBCheck_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(SQL.CONSTRING))
                {
                    con.Open();
                    MessageBox.Show(SQL.CONSTRING, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Error.\n" + SQL.CONSTRING, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
