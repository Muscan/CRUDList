using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CRUDList.Utils;

namespace CRUDList
{
    public partial class Form1 : Form
    {
        private List<Produs> produse = new List<Produs>();
        private string filePath = @"D:\C# Basics\CRUDList\CRUDList\Files\ListaProduse.txt";
        BindingSource listBinding = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            ReadFromFile(filePath, produse);
        }

        private void Produse_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            listBinding.DataSource = produse;
            Produse.DataSource = listBinding;
            Produse.DisplayMember = "Display";
            Produse.ValueMember = "Display";
            listBinding.ResetBindings(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ID =  int.Parse(txtBoxId.Text);
            string numeProdus = txtBoxNume.Text;
            double pretProdus = double.Parse(txtBoxPret.Text);
            Produs produs = new Produs(ID, numeProdus, pretProdus);//adaugare in lista
            produse.Add(produs);
            AddToFile(filePath, produs);
            listBinding.DataSource = produse;
            Produse.DataSource = listBinding;
            Produse.DisplayMember = "Display";
            Produse.ValueMember = "Display";
            listBinding.ResetBindings(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtBoxNume_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Produs produs = (Produs)Produse.SelectedItem;
            produse = produse.Where(x => x.IdProdus != produs.IdProdus).ToList();
            WriteInFile(filePath, produse);
            listBinding.DataSource = produse;
            Produse.DataSource = listBinding;
            Produse.DisplayMember = "Display";
            Produse.ValueMember = "Display";
            listBinding.ResetBindings(false);
        }

        private void txtBoxId_TextChanged(object sender, EventArgs e)
        {
            if(IsNumber(txtBoxId.Text) == false)
            {
                MessageBox.Show("enter a number");
            }
            
        }
    }
}
