using System;
using System.Drawing;
using System.Windows.Forms;


public partial class Form1 : Form
{
    Font oldFont;
    Font newFont;

    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Hello World", "Dangerous", MessageBoxButtons.OKCancel);
        MessageBox.Show(textBox1.Text);
    }

    private void buttonItalic_Click(object sender, EventArgs e)
    {
        oldFont = this.richTextBox1.SelectionFont;

        if (oldFont.Italic)
            newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Italic);
        else
            newFont = new Font(oldFont, oldFont.Style | FontStyle.Italic);

        this.richTextBox1.SelectionFont = newFont;
        this.richTextBox1.Focus();
    }

    private void buttonBold_Click(object sender, EventArgs e)
    {
        oldFont = this.richTextBox1.SelectionFont;

        if (oldFont.Bold)
            newFont = new Font(oldFont, oldFont.Style & ~FontStyle.Bold);
        else
            newFont = new Font(oldFont, oldFont.Style | FontStyle.Bold);

        this.richTextBox1.SelectionFont = newFont;
        this.richTextBox1.Focus();
    }

    private void buttonItems_Click(object sender, EventArgs e)
    {
        string items = string.Empty;

        if (checkBox1.Checked)
            items += "\nPencil";

        if (checkBox2.Checked)
            items += "\nSharpener";

        if (checkBox3.Checked)
            items += "\nPen";

        MessageBox.Show("You have bought: " + items);
    }

    private void buttonGender_Click(object sender, EventArgs e)
    {
        string gender = radioButton1.Checked ? "Male" : "Female";
        MessageBox.Show(gender);
    }

    private void buttonCalculate_Click(object sender, EventArgs e)
    {
        decimal price = numericUpDownPrice.Value;
        int quantity = (int)numericUpDownQuantity.Value;
        decimal total = price * quantity;

        MessageBox.Show(string.Format("The total price is {0:C}", total));
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        label1.Visible = false;

        OpenFileDialog o = new OpenFileDialog();
        if (o.ShowDialog() == DialogResult.OK)
        {
            pictureBox1.Image = new Bitmap(o.FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        string[] names = { "Punjab", "Sindh", "Kashmir", "Khyber", "NWFP" };
        foreach (string name in names)
        {
            comboBox1.Items.Add(name);
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBox2.Items.Clear();

        if (comboBox1.SelectedItem.ToString() == "Punjab")
        {
            comboBox2.Items.Add("Multan");
            comboBox2.Items.Add("Lahore");
            comboBox2.Items.Add("Islamabad");
            comboBox2.Items.Add("Sialkot");
            comboBox2.Items.Add("Rawalpindi");
        }
        else if (comboBox1.SelectedItem.ToString() == "Sindh")
        {
            comboBox2.Items.Add("Karachi");
            comboBox2.Items.Add("Hyderabad");
            comboBox2.Items.Add("Quetta");
        }
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        label2.Text = "DateTimePicker Date: " + dateTimePicker1.Text;
    }

    private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
    {
        label3.Text = "Month Calendar Date: " + monthCalendar1.SelectionStart.ToLongDateString();
    }
}